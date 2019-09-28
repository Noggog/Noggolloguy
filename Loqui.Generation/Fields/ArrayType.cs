﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Noggog;

namespace Loqui.Generation
{
    public class ArrayType : ListType
    {
        public override bool CopyNeedsTryCatch => false;
        public override bool IsClass => false;
        public override bool HasDefault => true;
        public override string TypeName(bool getter)
        {
            if (getter)
            {
                return $"ReadOnlyMemorySlice<{this.ItemTypeName(getter)}>{(this.Nullable ? "?" : null)}";
            }
            else
            {
                return $"{this.ItemTypeName(getter)}[]";
            }
        }

        public bool Nullable;
        public int? FixedSize;

        public override async Task Load(XElement node, bool requireName = true)
        {
            this.Nullable = node.GetAttribute(Constants.NULLABLE, true);
            this.FixedSize = node.GetAttribute(Constants.FIXED_SIZE, default(int?));
            await base.Load(node, requireName);
        }

        protected override string GetActualItemClass(bool getter, bool ctor = false)
        {
            if (this.NotifyingType == NotifyingType.ReactiveUI)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (this.HasBeenSet)
                {
                    throw new NotImplementedException();
                }
                if (!ctor)
                {
                    return $"{this.ItemTypeName(getter)}[]";
                }
                if (this.Nullable)
                {
                    return $"default";
                }
                else if (this.FixedSize.HasValue)
                {
                    return $"{this.ItemTypeName(getter)}[{this.FixedSize}]";
                }
                else
                {
                    return $"{this.ItemTypeName(getter)}[0]";
                }
            }
        }

        public override string Interface(bool getter)
        {
            string itemTypeName = this.ItemTypeName(getter: getter);
            if (this.SingleTypeGen is LoquiType loqui)
            {
                itemTypeName = loqui.TypeName(getter: getter);
            }
            if (getter)
            {
                return $"ReadOnlyMemorySlice<{itemTypeName}>{(this.Nullable ? "?" : null)}";
            }
            else
            {
                return $"{itemTypeName}[]";
            }
        }

        public override void GenerateClear(FileGeneration fg, Accessor accessorPrefix)
        {
            if (this.HasBeenSet)
            {
                fg.AppendLine($"{accessorPrefix.PropertyAccess}.Unset();");
            }
            else
            {
                fg.AppendLine($"{accessorPrefix.PropertyAccess}.Clear();");
            }
        }

        public override void GenerateForEquals(FileGeneration fg, Accessor accessor, Accessor rhsAccessor)
        {
            if (this.SingleTypeGen.IsIEquatable)
            {
                fg.AppendLine($"if (!MemoryExtensions.SequenceEqual({accessor.DirectAccess}.Span, {rhsAccessor.DirectAccess}.Span)) return false;");
            }
            else
            {
                fg.AppendLine($"if (!{accessor.DirectAccess}.SequenceEqual({rhsAccessor.DirectAccess})) return false;");
            }
        }

        public override void GenerateForEqualsMask(FileGeneration fg, Accessor accessor, Accessor rhsAccessor, string retAccessor)
        {
            string funcStr;
            if (this.SubTypeGeneration is LoquiType loqui)
            {
                funcStr = $"(loqLhs, loqRhs) => loqLhs.{(loqui.TargetObjectGeneration == null ? nameof(IEqualsMask.GetEqualsIMask) : "GetEqualsMask")}(loqRhs, include)";
            }
            else
            {
                funcStr = $"(l, r) => {this.SubTypeGeneration.GenerateEqualsSnippet(new Accessor("l"), new Accessor("r"))}";
            }
            using (var args = new ArgsWrapper(fg,
                $"ret.{this.Name} = item.{this.Name}.SpanEqualsHelper"))
            {
                args.Add($"rhs.{this.Name}");
                args.Add(funcStr);
                args.Add($"include");
            }
        }
    }
}
