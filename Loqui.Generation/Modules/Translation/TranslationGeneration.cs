﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loqui.Generation
{
    public abstract class TranslationGeneration
    {
        public MaskModule MaskModule;
        public virtual bool ShouldGenerateCopyIn(TypeGeneration typeGen) => typeGen.IntegrateField;
        public virtual bool ShouldGenerateWrite(TypeGeneration typeGen) => !typeGen.Derivative && typeGen.IntegrateField;
        public virtual string GetTranslationIfAccessor(TypeGeneration typeGen, string translationAccessor)
        {
            return $"({translationAccessor}?.GetShouldTranslate({typeGen.IndexEnumInt}) ?? true)";
        }

        public static bool IsParseInto(
            TypeGeneration typeGen,
            Accessor itemAccessor)
        {
            return itemAccessor != null
                && typeGen.PrefersProperty
                && itemAccessor.PropertyAccess != null;
        }

        public static void WrapParseCall(TranslationWrapParseArgs param)
        {
            MaskGenerationUtility.WrapErrorFieldIndexPush(param.FG,
                () =>
                {
                    ArgsWrapper args;
                    bool parseInto = IsParseInto(param.TypeGen, param.ItemAccessor);
                    args = new ArgsWrapper(param.FG,
                       $"{(parseInto ? null : "if (")}{param.TranslatorLine}.{(parseInto ? "ParseInto" : "Parse")}",
                       suffixLine: (parseInto ? null : ")"))
                    {
                        SemiColon = parseInto,
                    };
                    using (args)
                    {
                        if (param.ExtraArgs != null)
                        {
                            foreach (var extra in param.ExtraArgs)
                            {
                                args.Add(extra);
                            }
                        }
                        if (parseInto)
                        {
                            args.Add($"item: {param.ItemAccessor.PropertyAccess}");
                            if (param.IndexAccessor != null && !param.SkipErrorMask)
                            {
                                args.Add($"fieldIndex: {param.IndexAccessor}");
                            }
                        }
                        else
                        {
                            args.Add($"item: out {param.TypeGen.TypeName} {param.TypeGen.Name}Parse");
                        }
                        if (!param.SkipErrorMask)
                        {
                            args.Add($"errorMask: {param.MaskAccessor}");
                        }
                        if (param.TranslationMaskAccessor != null)
                        {
                            args.Add($"translationMask: {param.TranslationMaskAccessor}");
                        }
                    }
                    if (!parseInto)
                    {
                        using (new BraceWrapper(param.FG))
                        {
                            param.FG.AppendLine($"{param.ItemAccessor.DirectAccess} = {param.TypeGen.Name}Parse;");
                        }
                        param.FG.AppendLine("else");
                        using (new BraceWrapper(param.FG))
                        {
                            if (param.UnsetCall != null)
                            {
                                param.UnsetCall(param.FG);
                            }
                            else
                            {
                                param.FG.AppendLine($"{param.ItemAccessor.DirectAccess} = default({param.TypeGen.TypeName});");
                            }
                        }
                    }
                },
                errorMaskAccessor: param.MaskAccessor,
                indexAccessor: param.IndexAccessor,
                doIt: !param.SkipErrorMask
                    && param.IndexAccessor != null 
                    && !IsParseInto(param.TypeGen, param.ItemAccessor));
        }
        
        public class TranslationWrapParseArgs
        {
            public FileGeneration FG;
            public TypeGeneration TypeGen;
            public string TranslatorLine;
            public Accessor MaskAccessor;
            public Accessor TranslationMaskAccessor;
            public Accessor ItemAccessor;
            public Accessor IndexAccessor;
            public Action<FileGeneration> UnsetCall;
            public IEnumerable<string> ExtraArgs;
            public bool SkipErrorMask;
        }
    }
}
