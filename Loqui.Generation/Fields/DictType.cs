using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Loqui.Generation
{
    public interface IDictType
    {
        TypeGeneration KeyTypeGen { get; }
        TypeGeneration ValueTypeGen { get; }
        DictMode Mode { get; }
        void AddMaskException(FileGeneration fg, string errorMaskMemberAccessor, string exception, bool key);
    }

    public enum DictMode
    {
        KeyValue,
        KeyedValue
    }

    public class DictType : TypeGeneration, IDictType
    {
        private TypeGeneration subGenerator;
        private IDictType subDictGenerator;
        public DictMode Mode => subDictGenerator.Mode;
        public override bool CopyNeedsTryCatch => subGenerator.CopyNeedsTryCatch;
        public TypeGeneration KeyTypeGen => subDictGenerator.KeyTypeGen;
        public TypeGeneration ValueTypeGen => subDictGenerator.ValueTypeGen;
        public override string ProtectedName => subGenerator.ProtectedName;
        public override string TypeName(bool getter, bool needsCovariance = false) => subGenerator.TypeName(getter, needsCovariance);
        public override bool IsEnumerable => true;
        public override bool IsClass => true;
        public override bool HasDefault => false;

        public override string SkipCheck(Accessor copyMaskAccessor, bool deepCopy) => subGenerator.SkipCheck(copyMaskAccessor, deepCopy);

        public override string GetName(bool internalUse)
        {
            return subGenerator.GetName(internalUse);
        }

        public void AddMaskException(FileGeneration fg, string errorMaskMemberAccessor, string exception, bool key)
        {
            subDictGenerator.AddMaskException(fg, errorMaskMemberAccessor, exception, key);
        }

        public override async Task Load(XElement node, bool requireName = true)
        {
            await base.Load(node, requireName);

            var keyedValueNode = node.Element(XName.Get("KeyedValue", LoquiGenerator.Namespace));
            if (keyedValueNode != null)
            {
                var dictType = new DictType_KeyedValue();
                dictType.SetObjectGeneration(this.ObjectGen, setDefaults: false);
                subGenerator = dictType;
                await subGenerator.Load(node, requireName);
                subDictGenerator = dictType;
            }
            else
            {
                var dictType = new DictType_Typical();
                dictType.SetObjectGeneration(this.ObjectGen, setDefaults: false);
                subGenerator = dictType;
                await subGenerator.Load(node, requireName);
                subDictGenerator = dictType;
            }
        }

        public override void GenerateUnsetNth(FileGeneration fg, Accessor identifier)
        {
            subGenerator.GenerateUnsetNth(fg, identifier);
        }

        public override void GenerateForClass(FileGeneration fg)
        {
            subGenerator.GenerateForClass(fg);
        }

        public override void GenerateForInterface(FileGeneration fg, bool getter, bool internalInterface)
        {
            subGenerator.GenerateForInterface(fg, getter, internalInterface);
        }

        public override void GenerateForCopy(
            FileGeneration fg,
            Accessor accessor,
            Accessor rhs, 
            Accessor copyMaskAccessor,
            bool protectedMembers,
            bool deepCopy)
        {
            subGenerator.GenerateForCopy(fg, accessor, rhs, copyMaskAccessor, protectedMembers, deepCopy);
        }

        public override void GenerateSetNth(FileGeneration fg, Accessor accessor, Accessor rhs, bool internalUse)
        {
            subGenerator.GenerateSetNth(fg, accessor, rhs, internalUse);
        }

        public override string NullableAccessor(bool getter, Accessor accessor = null)
        {
            return subGenerator.NullableAccessor(getter, accessor);
        }

        public override void GenerateGetNth(FileGeneration fg, Accessor identifier)
        {
            subGenerator.GenerateGetNth(fg, identifier);
        }

        public override void GenerateClear(FileGeneration fg, Accessor accessorPrefix)
        {
            subGenerator.GenerateClear(fg, accessorPrefix);
        }

        public override string GenerateACopy(string rhsAccessor)
        {
            return subGenerator.GenerateACopy(rhsAccessor);
        }

        public override async Task Resolve()
        {
            await subGenerator.Resolve();
        }

        public override string GenerateEqualsSnippet(Accessor accessor, Accessor rhsAccessor, bool negate = false)
        {
            return subGenerator.GenerateEqualsSnippet(accessor, rhsAccessor, negate);
        }

        public override void GenerateForEquals(FileGeneration fg, Accessor accessor, Accessor rhsAccessor, Accessor maskAccessor)
        {
            subGenerator.GenerateForEquals(fg, accessor, rhsAccessor, maskAccessor);
        }

        public override void GenerateForEqualsMask(FileGeneration fg, Accessor accessor, Accessor rhsAccessor, string retAccessor)
        {
            subGenerator.GenerateForEqualsMask(fg, accessor, rhsAccessor, retAccessor);
        }

        public override void GenerateForHash(FileGeneration fg, Accessor accessor, string hashResultAccessor)
        {
            subGenerator.GenerateForHash(fg, accessor, hashResultAccessor);
        }

        public override void GenerateToString(FileGeneration fg, string name, Accessor accessor, string fgAccessor)
        {
            subGenerator.GenerateToString(fg, name, accessor, fgAccessor);
        }

        public override void GenerateForNullableCheck(FileGeneration fg, Accessor accessor, string checkMaskAccessor)
        {
            subGenerator.GenerateForNullableCheck(fg, accessor, checkMaskAccessor);
        }

        public override string GetDuplicate(Accessor accessor)
        {
            throw new NotImplementedException();
        }
    }
}
