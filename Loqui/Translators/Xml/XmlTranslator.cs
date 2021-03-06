using Loqui.Internal;
using Loqui.Translators;
using Noggog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Loqui.Xml
{
    public class XmlTranslator : Translator<IXmlTranslation<object>>
    {
        public readonly static XmlTranslator Instance = new XmlTranslator();

        public Dictionary<string, Type?> elementNameTypeDict = new Dictionary<string, Type?>();

        private XmlTranslator()
            : base (
                  typeof(NullXmlTranslation),
                  typeof(XmlTranslationCaster<>),
                  typeof(LoquiXmlTranslation<>),
                  typeof(EnumXmlTranslation<>))
        {
            elementNameTypeDict["Null"] = NullType;
        }

        public bool TranslateElementName(string elementName, [MaybeNullWhen(false)] out Type t)
        {
            var ret = elementNameTypeDict.TryGetValue(elementName, out t!);
            if (!ret)
            {
                var regis = LoquiRegistration.GetRegisterByFullName(elementName);
                if (regis != null)
                {
                    t = elementNameTypeDict.GetOrAdd(elementName, () => regis.ClassType)!;
                    return t != null;
                }
                else
                {
                    elementNameTypeDict[elementName] = null;
                }
            }
            return ret && t != null;
        }

        protected override GetResponse<IXmlTranslation<object>> SetTranslator_Internal(IXmlTranslation<object> transl, Type t)
        {
            var resp = base.SetTranslator_Internal(transl, t);
            if (string.IsNullOrEmpty(transl.ElementName)) return resp;
            elementNameTypeDict.GetOrAdd(transl.ElementName, () => t);
            return resp;
        }
    }

    public class XmlTranslator<T>
    {
        private static GetResponse<IXmlTranslation<T>?> _translator;
        public static GetResponse<IXmlTranslation<T>?> Translator => _translator;
        public delegate T CREATE_FUNC(XElement root, ErrorMaskBuilder errorMask);

        static XmlTranslator()
        {
            var transl = XmlTranslator.Instance.GetTranslator(typeof(T));
            if (transl.Failed)
            {
                _translator = transl.BubbleFailure<IXmlTranslation<T>?>();
                return;
            }
            var caster = transl.Value as XmlTranslationCaster<T>;
            _translator = GetResponse<IXmlTranslation<T>?>.Create(successful: caster != null, caster?.Source);
        }
    }
}
