﻿using Loqui.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Loqui.Tests.XML
{
    public class DoubleXmlTranslation_Test : TypicalXmlTranslation_Test<double, Exception, DoubleXmlTranslation_Test>
    {
        public const double TYPICAL_VALUE = 4.56;
        public override double TypicalValue => TYPICAL_VALUE;
        public const double NEGATIVE_VALUE = -4.56;
        public const double MIN_VALUE = double.MinValue;
        public const double MAX_VALUE = double.MaxValue;

        public override string ExpectedName => "Double";

        public override IXmlTranslation<double, Exception> GetTranslation()
        {
            return new DoubleXmlTranslation();
        }

        #region Parse - Typical
        [Fact]
        public void Parse_NoMask()
        {
            var transl = GetTranslation();
            var elem = GetTypicalElement(TYPICAL_VALUE);
            var ret = transl.Parse(
                elem,
                doMasks: false,
                maskObj: out var maskObj);
            Assert.True(ret.Succeeded);
            Assert.Null(maskObj);
            Assert.Equal(TYPICAL_VALUE, ret.Value);
        }

        [Fact]
        public void Parse_Mask()
        {
            var transl = GetTranslation();
            var elem = GetTypicalElement(TYPICAL_VALUE);
            var ret = transl.Parse(
                elem,
                doMasks: true,
                maskObj: out var maskObj);
            Assert.True(ret.Succeeded);
            Assert.Null(maskObj);
            Assert.Equal(TYPICAL_VALUE, ret.Value);
        }
        #endregion

        #region Parse - No Value
        [Fact]
        public void Parse_NoValue_NoMask()
        {
            var transl = GetTranslation();
            var elem = GetElementNoValue();
            Assert.Throws(
                typeof(ArgumentException),
                () => transl.Parse(
                    elem,
                    doMasks: false,
                    maskObj: out var maskObj));
        }

        [Fact]
        public void Parse_NoValue_Mask()
        {
            var transl = GetTranslation();
            var elem = GetElementNoValue();
            var ret = transl.Parse(
                elem,
                doMasks: true,
                maskObj: out var maskObj);
            Assert.True(ret.Failed);
            Assert.NotNull(maskObj);
            Assert.IsType(typeof(ArgumentException), maskObj);
        }
        #endregion

        #region Parse - Empty Value
        [Fact]
        public void Parse_EmptyValue_NoMask()
        {
            var transl = GetTranslation();
            var elem = GetElementNoValue();
            elem.SetAttributeValue(XName.Get(XmlConstants.VALUE_ATTRIBUTE), string.Empty);
            Assert.Throws(
                typeof(ArgumentException),
                () => transl.Parse(
                    elem,
                    doMasks: false,
                    maskObj: out var maskObj));
        }

        [Fact]
        public void Parse_EmptyValue_Mask()
        {
            var transl = GetTranslation();
            var elem = GetElementNoValue();
            elem.SetAttributeValue(XName.Get(XmlConstants.VALUE_ATTRIBUTE), string.Empty);
            var ret = transl.Parse(
                elem,
                doMasks: true,
                maskObj: out var maskObj);
            Assert.True(ret.Failed);
            Assert.NotNull(maskObj);
            Assert.IsType(typeof(ArgumentException), maskObj);
        }
        #endregion

        #region Write - Typical
        [Fact]
        public void Write_NoMask()
        {
            var transl = GetTranslation();
            var writer = XmlUtility.GetWriteBundle();
            transl.Write(
                writer: writer.Writer,
                name: XmlUtility.TYPICAL_NAME,
                item: TYPICAL_VALUE,
                doMasks: false,
                maskObj: out var maskObj);
            Assert.Null(maskObj);
            XElement elem = writer.Resolve();
            Assert.Null(elem.Attribute(XName.Get(XmlConstants.NAME_ATTRIBUTE)));
            var valAttr = elem.Attribute(XName.Get(XmlConstants.VALUE_ATTRIBUTE));
            Assert.NotNull(valAttr);
            Assert.Equal(StringConverter(TYPICAL_VALUE), valAttr.Value);
        }

        [Fact]
        public void Write_Mask()
        {
            var transl = GetTranslation();
            var writer = XmlUtility.GetWriteBundle();
            transl.Write(
                writer: writer.Writer,
                name: XmlUtility.TYPICAL_NAME,
                item: TYPICAL_VALUE,
                doMasks: true,
                maskObj: out var maskObj);
            Assert.Null(maskObj);
            XElement elem = writer.Resolve();
            Assert.Equal(XmlUtility.TYPICAL_NAME, elem.Name.LocalName);
            var valAttr = elem.Attribute(XName.Get(XmlConstants.VALUE_ATTRIBUTE));
            Assert.NotNull(valAttr);
            Assert.Equal(StringConverter(TYPICAL_VALUE), valAttr.Value);
        }
        #endregion

        #region Reimport
        [Fact]
        public void Reimport_Typical()
        {
            var transl = GetTranslation();
            var writer = XmlUtility.GetWriteBundle();
            transl.Write(
                writer: writer.Writer,
                name: XmlUtility.TYPICAL_NAME,
                item: TYPICAL_VALUE,
                doMasks: false,
                maskObj: out var maskObj);
            var readResp = transl.Parse(
                writer.Resolve(),
                doMasks: false,
                maskObj: out var readMaskObj);
            Assert.True(readResp.Succeeded);
            Assert.True(TYPICAL_VALUE.EqualsWithin(readResp.Value));
        }

        [Fact]
        public void Reimport_Zero()
        {
            var transl = GetTranslation();
            var writer = XmlUtility.GetWriteBundle();
            transl.Write(
                writer: writer.Writer,
                name: XmlUtility.TYPICAL_NAME,
                item: 0,
                doMasks: false,
                maskObj: out var maskObj);
            var readResp = transl.Parse(
                writer.Resolve(),
                doMasks: false,
                maskObj: out var readMaskObj);
            Assert.True(readResp.Succeeded);
            Assert.Equal<double?>(0d, readResp.Value);
        }

        [Fact]
        public void Reimport_Negative()
        {
            var transl = GetTranslation();
            var writer = XmlUtility.GetWriteBundle();
            transl.Write(
                writer: writer.Writer,
                name: XmlUtility.TYPICAL_NAME,
                item: NEGATIVE_VALUE,
                doMasks: false,
                maskObj: out var maskObj);
            var readResp = transl.Parse(
                writer.Resolve(),
                doMasks: false,
                maskObj: out var readMaskObj);
            Assert.True(readResp.Succeeded);
            Assert.True(NEGATIVE_VALUE.EqualsWithin(readResp.Value));
        }

        [Fact]
        public void Reimport_Min()
        {
            var transl = GetTranslation();
            var writer = XmlUtility.GetWriteBundle();
            transl.Write(
                writer: writer.Writer,
                name: XmlUtility.TYPICAL_NAME,
                item: MIN_VALUE,
                doMasks: false,
                maskObj: out var maskObj);
            var readResp = transl.Parse(
                writer.Resolve(),
                doMasks: false,
                maskObj: out var readMaskObj);
            Assert.True(readResp.Succeeded);
            Assert.True(MIN_VALUE.EqualsWithin(readResp.Value));
        }

        [Fact]
        public void Reimport_Max()
        {
            var transl = GetTranslation();
            var writer = XmlUtility.GetWriteBundle();
            transl.Write(
                writer: writer.Writer,
                name: XmlUtility.TYPICAL_NAME,
                item: MAX_VALUE,
                doMasks: false,
                maskObj: out var maskObj);
            var readResp = transl.Parse(
                writer.Resolve(),
                doMasks: false,
                maskObj: out var readMaskObj);
            Assert.True(readResp.Succeeded);
            Assert.True(MAX_VALUE.EqualsWithin(readResp.Value));
        }
        #endregion
    }
}
