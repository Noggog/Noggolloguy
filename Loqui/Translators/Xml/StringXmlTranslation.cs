﻿using Loqui.Internal;
using Noggog;
using Noggog.Notifying;
using Noggog.Xml;
using System;
using System.Xml;
using System.Xml.Linq;

namespace Loqui.Xml
{
    public class StringXmlTranslation : IXmlTranslation<string>
    {
        public string ElementName => "String";

        public readonly static StringXmlTranslation Instance = new StringXmlTranslation();

        public TryGet<string> Parse(XElement root)
        {
            if (!root.Name.LocalName.Equals(ElementName))
            {
                throw new ArgumentException($"Skipping field Version that did not match proper type. Type: {root.Name.LocalName}, expected: {ElementName}.");
            }
            if (root.TryGetAttribute(XmlConstants.VALUE_ATTRIBUTE, out XAttribute val))
            {
                return TryGet<string>.Succeed(val.Value);
            }
            return TryGet<string>.Succeed(null);
        }

        public bool Parse(
            XElement root,
            out string item,
            ErrorMaskBuilder errorMask)
        {
            if (root.TryGetAttribute(XmlConstants.VALUE_ATTRIBUTE, out XAttribute val))
            {
                item = val.Value;
                return true;
            }
            item = null;
            return false;
        }

        public bool Parse(
            XElement root,
            out string item,
            ErrorMaskBuilder errorMask,
            TranslationCrystal translationMask)
        {
            return this.Parse(
                root: root,
                item: out item,
                errorMask: errorMask);
        }

        public void ParseInto(XElement root, IHasItem<string> item, int fieldIndex, ErrorMaskBuilder errorMask)
        {
            using (errorMask?.PushIndex(fieldIndex))
            {
                try
                {
                    if (Parse(root, out var val, errorMask))
                    {
                        item.Item = val;
                    }
                    else
                    {
                        item.Unset();
                    }
                }
                catch (Exception ex)
                when (errorMask != null)
                {
                    errorMask.ReportException(ex);
                }
            }
        }

        public void Write(
            XElement node,
            string name,
            string item)
        {
            var elem = new XElement(name);
            node.Add(elem);
            if (item != null)
            {
                elem.SetAttributeValue(XmlConstants.VALUE_ATTRIBUTE, item);
            }
        }

        public void Write(
            XElement node,
            string name,
            string item,
            ErrorMaskBuilder errorMask)
        {
            this.Write(node, name, item);
        }

        public void Write(
            XElement node,
            string name,
            string item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            errorMask.WrapAction(fieldIndex, () =>
            {
                this.Write(
                    node: node,
                    name: name,
                    item: item);
            });
        }

        public void Write(
            XElement node,
            string name,
            IHasItemGetter<string> item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            using (errorMask?.PushIndex(fieldIndex))
            {
                try
                {
                    this.Write(
                        node: node,
                        name: name,
                        item: item.Item);
                }
                catch (Exception ex)
                when (errorMask != null)
                {
                    errorMask.ReportException(ex);
                }
            }
        }

        public void Write(
            XElement node,
            string name,
            IHasBeenSetItemGetter<string> item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            if (!item.HasBeenSet) return;
            this.Write(
                node: node,
                name: name,
                item: item.Item,
                fieldIndex: fieldIndex,
                errorMask: errorMask);
        }

        void IXmlTranslation<string>.Write(XElement node, string name, string item, ErrorMaskBuilder errorMask, TranslationCrystal translationMask)
        {
            this.Write(
                node: node,
                name: name,
                item: item);
        }

        bool IXmlTranslation<string>.Parse(XElement root, out string item, ErrorMaskBuilder errorMask, TranslationCrystal translationMask)
        {
            return this.Parse(
                root: root,
                item: out item,
                errorMask: errorMask);
        }
    }
}
