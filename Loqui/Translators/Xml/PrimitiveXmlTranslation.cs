﻿using Loqui.Internal;
using Noggog;
using Noggog.Xml;
using System;
using System.Xml;
using System.Xml.Linq;

namespace Loqui.Xml
{
    public abstract class PrimitiveXmlTranslation<T> : IXmlTranslation<T>
        where T : struct
    {
        string IXmlTranslation<T>.ElementName => ElementName;
        public virtual string ElementName => typeof(T).GetName();

        protected virtual string GetItemStr(T item)
        {
            return item.ToString();
        }

        protected abstract bool ParseNonNullString(string str, out T value, ErrorMaskBuilder errorMask);

        public void ParseInto(XElement node, int fieldIndex, IHasItem<T> item, ErrorMaskBuilder errorMask)
        {
            using (errorMask.PushIndex(fieldIndex))
            {
                try
                {
                    if (Parse(node, out T val, errorMask))
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

        public void ParseInto(XElement root, int fieldIndex, IHasItem<T?> item, ErrorMaskBuilder errorMask)
        {
            using (errorMask?.PushIndex(fieldIndex))
            {
                try
                {
                    if (Parse(root, out T? val, errorMask))
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

        public bool Parse(
            XElement node,
            out T item,
            ErrorMaskBuilder errorMask)
        {
            if (this.Parse(
                node: node,
                nullable: false,
                item: out var nullItem,
                errorMask: errorMask))
            {
                item = nullItem.Value;
                return true;
            }
            item = default(T);
            return false;
        }

        public T Parse(
            XElement node,
            ErrorMaskBuilder errorMask,
            T defaultVal = default)
        {
            if (this.Parse(
                node: node,
                nullable: false,
                item: out var nullItem,
                errorMask: errorMask))
            {
                return nullItem.Value;
            }
            return defaultVal;
        }

        public bool Parse(
            XElement node,
            out T item,
            ErrorMaskBuilder errorMask,
            TranslationCrystal translationMask)
        {
            return this.Parse(
                node: node,
                item: out item,
                errorMask: errorMask);
        }

        public bool Parse(
            XElement node,
            out T? item, 
            ErrorMaskBuilder errorMask)
        {
            return this.Parse(
                node: node, 
                nullable: true, 
                item: out item,
                errorMask: errorMask);
        }

        public bool Parse(
            XElement node, 
            int fieldIndex,
            out T item,
            ErrorMaskBuilder errorMask)
        {
            using (errorMask.PushIndex(fieldIndex))
            {
                try
                {
                    return Parse(node, out item, errorMask);
                }
                catch (Exception ex)
                when (errorMask != null)
                {
                    errorMask.ReportException(ex);
                }
            }
            item = default(T);
            return false;
        }

        public bool Parse(
            XElement node, 
            int fieldIndex, 
            out T? item, 
            ErrorMaskBuilder errorMask)
        {
            using (errorMask.PushIndex(fieldIndex))
            {
                try
                {
                    return Parse(node, out item, errorMask);
                }
                catch (Exception ex)
                when (errorMask != null)
                {
                    errorMask.ReportException(ex);
                }
            }
            item = null;
            return false;
        }

        protected virtual bool ParseValue(XElement node, out T? value, ErrorMaskBuilder errorMask)
        {
            if (!node.TryGetAttribute(XmlConstants.VALUE_ATTRIBUTE, out XAttribute val)
                || string.IsNullOrEmpty(val.Value))
            {
                value = null;
                return true;
            }
            if (ParseNonNullString(val.Value, out var nonNullVal, errorMask))
            {
                value = nonNullVal;
                return true;
            }
            value = null;
            return false;
        }

        public bool Parse(
            XElement node,
            bool nullable, 
            out T? item, 
            ErrorMaskBuilder errorMask)
        {
            if (!ParseValue(node, out item, errorMask))
            {
                return false;
            }
            if (!nullable && !item.HasValue)
            {
                errorMask.ReportExceptionOrThrow(new ArgumentException("Value was unexpectedly null."));
            }
            return true;
        }

        protected virtual void WriteValue(XElement node, T? item)
        {
            node.SetAttributeValue(
                XmlConstants.VALUE_ATTRIBUTE,
                item.HasValue ? GetItemStr(item.Value) : string.Empty);
        }

        public void Write(
            XElement node,
            string name,
            T? item)
        {
            Write_Internal(
                node,
                name,
                item,
                nullable: true);
        }

        public void Write(
            XElement node,
            string name,
            T? item,
            ErrorMaskBuilder errorMask)
        {
            Write_Internal(
                node,
                name,
                item,
                nullable: true);
        }

        private void Write_Internal(
            XElement node, 
            string name, 
            T? item,
            bool nullable)
        {
            var elem = new XElement(name ?? ElementName);
            node.Add(elem);
            WriteValue(elem, item);
        }

        public void Write(
            XElement node, 
            string name,
            T item)
        {
            Write_Internal(node, name, (T?)item, nullable: false);
        }

        public void Write(
            XElement node,
            string name,
            T? item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            using (errorMask?.PushIndex(fieldIndex))
            {
                try
                {
                    this.Write(
                        node,
                        name,
                        item);
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
            IHasItemGetter<T> item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            using (errorMask?.PushIndex(fieldIndex))
            {
                try
                {
                    this.Write(
                        node,
                        name,
                        item.Item);
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
            IHasItemGetter<T?> item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            using (errorMask?.PushIndex(fieldIndex))
            {
                try
                {
                    this.Write(
                        node,
                        name,
                        item.Item);
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
            IHasBeenSetItemGetter<T?> item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            if (!item.HasBeenSet) return;
            this.Write(
                node,
                name,
                item.Item,
                fieldIndex,
                errorMask);
        }

        public void Write(
            XElement node,
            string name,
            IHasBeenSetItemGetter<T> item,
            int fieldIndex,
            ErrorMaskBuilder errorMask)
        {
            if (!item.HasBeenSet) return;
            this.Write(
                node,
                name,
                item.Item,
                fieldIndex,
                errorMask);
        }

        void IXmlTranslation<T>.Write(XElement node, string name, T item, ErrorMaskBuilder errorMask, TranslationCrystal translationMask)
        {
            this.Write(
                node: node,
                name: name,
                item: item);
        }

        bool IXmlTranslation<T>.Parse(XElement node, out T item, ErrorMaskBuilder errorMask, TranslationCrystal translationMask)
        {
            return this.Parse(
                node: node,
                item: out item,
                errorMask: errorMask);
        }
    }
}
