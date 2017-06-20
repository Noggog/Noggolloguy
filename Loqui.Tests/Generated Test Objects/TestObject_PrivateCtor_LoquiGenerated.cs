/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loqui;
using Noggog;
using Noggog.Notifying;
using Loqui.Tests.Internals;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Loqui.Xml;

namespace Loqui.Tests
{
    #region Class
    public partial class TestObject_PrivateCtor : ITestObject_PrivateCtor, ILoquiObjectSetter, IEquatable<TestObject_PrivateCtor>
    {
        ILoquiRegistration ILoquiObject.Registration => TestObject_PrivateCtor_Registration.Instance;
        public static TestObject_PrivateCtor_Registration Registration => TestObject_PrivateCtor_Registration.Instance;

        #region Ctor
        protected TestObject_PrivateCtor()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region BoolN
        public Boolean? BoolN { get; set; }
        #endregion

        #region Loqui Getter Interface

        protected object GetNthObject(ushort index) => TestObject_PrivateCtorCommon.GetNthObject(index, this);
        object ILoquiObjectGetter.GetNthObject(ushort index) => this.GetNthObject(index);

        protected bool GetNthObjectHasBeenSet(ushort index) => TestObject_PrivateCtorCommon.GetNthObjectHasBeenSet(index, this);
        bool ILoquiObjectGetter.GetNthObjectHasBeenSet(ushort index) => this.GetNthObjectHasBeenSet(index);

        protected void UnsetNthObject(ushort index, NotifyingUnsetParameters? cmds) => TestObject_PrivateCtorCommon.UnsetNthObject(index, this, cmds);
        void ILoquiObjectSetter.UnsetNthObject(ushort index, NotifyingUnsetParameters? cmds) => this.UnsetNthObject(index, cmds);

        #endregion

        #region Loqui Interface
        protected void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            TestObject_PrivateCtorCommon.SetNthObjectHasBeenSet(index, on, this);
        }
        void ILoquiObjectSetter.SetNthObjectHasBeenSet(ushort index, bool on) => this.SetNthObjectHasBeenSet(index, on);

        #endregion

        #region To String
        public override string ToString()
        {
            return TestObject_PrivateCtorCommon.ToString(this, printMask: null);
        }

        public string ToString(
            string name = null,
            TestObject_PrivateCtor_Mask<bool> printMask = null)
        {
            return TestObject_PrivateCtorCommon.ToString(this, name: name, printMask: printMask);
        }

        public void ToString(
            FileGeneration fg,
            string name = null)
        {
            TestObject_PrivateCtorCommon.ToString(this, fg, name: name, printMask: null);
        }

        #endregion

        public TestObject_PrivateCtor_Mask<bool> GetHasBeenSetMask()
        {
            return TestObject_PrivateCtorCommon.GetHasBeenSetMask(this);
        }
        #region Equals and Hash
        public override bool Equals(object obj)
        {
            if (!(obj is TestObject_PrivateCtor rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(TestObject_PrivateCtor rhs)
        {
            if (BoolN != rhs.BoolN) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int ret = 0;
            ret = HashHelper.GetHashCode(BoolN).CombineHashCode(ret);
            return ret;
        }

        #endregion


        #region XML Translation
        public static TestObject_PrivateCtor Create_XML(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return Create_XML(XElement.Parse(reader.ReadToEnd()));
            }
        }

        public static TestObject_PrivateCtor Create_XML(XElement root)
        {
            return Create_XML(
                root: root,
                doMasks: false,
                errorMask: out var errorMask);
        }

        public static TestObject_PrivateCtor Create_XML(
            XElement root,
            out TestObject_PrivateCtor_ErrorMask errorMask)
        {
            return Create_XML(
                root: root,
                doMasks: true,
                errorMask: out errorMask);
        }

        public static TestObject_PrivateCtor Create_XML(
            XElement root,
            bool doMasks,
            out TestObject_PrivateCtor_ErrorMask errorMask)
        {
            TestObject_PrivateCtor_ErrorMask errMaskRet = null;
            var ret = Create_XML_Internal(
                root: root,
                doMasks: doMasks,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new TestObject_PrivateCtor_ErrorMask()) : default(Func<TestObject_PrivateCtor_ErrorMask>));
            errorMask = errMaskRet;
            return ret;
        }

        private static TestObject_PrivateCtor Create_XML_Internal(
            XElement root,
            bool doMasks,
            Func<TestObject_PrivateCtor_ErrorMask> errorMask)
        {
            if (!root.Name.LocalName.Equals("Loqui.Tests.TestObject_PrivateCtor"))
            {
                var ex = new ArgumentException($"Skipping field that did not match proper type. Type: {root.Name.LocalName}, expected: Loqui.Tests.TestObject_PrivateCtor.");
                if (!doMasks) throw ex;
                errorMask().Overall = ex;
                return null;
            }
            var ret = new TestObject_PrivateCtor();
            try
            {
                foreach (var elem in root.Elements())
                {
                    if (!elem.TryGetAttribute("name", out XAttribute name)) continue;
                    Fill_XML_Internal(
                        item: ret,
                        root: elem,
                        name: name.Value,
                        doMasks: doMasks,
                        errorMask: errorMask);
                }
            }
            catch (Exception ex)
            {
                if (!doMasks) throw;
                errorMask().Overall = ex;
            }
            return ret;
        }

        protected static void Fill_XML_Internal(
            TestObject_PrivateCtor item,
            XElement root,
            string name,
            bool doMasks,
            Func<TestObject_PrivateCtor_ErrorMask> errorMask)
        {
            switch (name)
            {
                case "BoolN":
                    {
                        Exception subMask;
                        var tryGet = BooleanXmlTranslation.Instance.Parse(
                            root,
                            nullable: true,
                            doMasks: doMasks,
                            errorMask: out subMask);
                        if (tryGet.Succeeded)
                        {
                            item.BoolN = tryGet.Value;
                        }
                        if (subMask != null)
                        {
                            errorMask().BoolN = subMask;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void CopyIn_XML(XElement root, NotifyingFireParameters? cmds = null)
        {
            LoquiXmlTranslation<TestObject_PrivateCtor, TestObject_PrivateCtor_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipProtected: true,
                doMasks: false,
                mask: out TestObject_PrivateCtor_ErrorMask errorMask,
                cmds: cmds);
        }

        public virtual void CopyIn_XML(XElement root, out TestObject_PrivateCtor_ErrorMask errorMask, NotifyingFireParameters? cmds = null)
        {
            LoquiXmlTranslation<TestObject_PrivateCtor, TestObject_PrivateCtor_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipProtected: true,
                doMasks: true,
                mask: out errorMask,
                cmds: cmds);
        }

        public void Write_XML(Stream stream)
        {
            TestObject_PrivateCtorCommon.Write_XML(
                this,
                stream);
        }

        public void Write_XML(Stream stream, out TestObject_PrivateCtor_ErrorMask errorMask)
        {
            TestObject_PrivateCtorCommon.Write_XML(
                this,
                stream,
                out errorMask);
        }

        public void Write_XML(XmlWriter writer, out TestObject_PrivateCtor_ErrorMask errorMask, string name = null)
        {
            TestObject_PrivateCtorCommon.Write_XML(
                writer: writer,
                name: name,
                item: this,
                doMasks: true,
                errorMask: out errorMask);
        }

        public void Write_XML(XmlWriter writer, string name = null)
        {
            TestObject_PrivateCtorCommon.Write_XML(
                writer: writer,
                name: name,
                item: this,
                doMasks: false,
                errorMask: out TestObject_PrivateCtor_ErrorMask errorMask);
        }

        #endregion

        public TestObject_PrivateCtor Copy(
            TestObject_PrivateCtor_CopyMask copyMask = null,
            ITestObject_PrivateCtorGetter def = null)
        {
            return TestObject_PrivateCtor.Copy(
                this,
                copyMask: copyMask,
                def: def);
        }

        public static TestObject_PrivateCtor Copy(
            ITestObject_PrivateCtor item,
            TestObject_PrivateCtor_CopyMask copyMask = null,
            ITestObject_PrivateCtorGetter def = null)
        {
            TestObject_PrivateCtor ret;
            if (item.GetType().Equals(typeof(TestObject_PrivateCtor)))
            {
                ret = new TestObject_PrivateCtor();
            }
            else
            {
                ret = (TestObject_PrivateCtor)Activator.CreateInstance(item.GetType());
            }
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        public static CopyType Copy<CopyType>(
            CopyType item,
            TestObject_PrivateCtor_CopyMask copyMask = null,
            ITestObject_PrivateCtorGetter def = null)
            where CopyType : class, ITestObject_PrivateCtor
        {
            CopyType ret;
            if (item.GetType().Equals(typeof(TestObject_PrivateCtor)))
            {
                ret = new TestObject_PrivateCtor() as CopyType;
            }
            else
            {
                ret = (CopyType)Activator.CreateInstance(item.GetType());
            }
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                doErrorMask: false,
                errorMask: null,
                cmds: null,
                def: def);
            return ret;
        }

        public static TestObject_PrivateCtor Copy_ToLoqui(
            ITestObject_PrivateCtorGetter item,
            TestObject_PrivateCtor_CopyMask copyMask = null,
            ITestObject_PrivateCtorGetter def = null)
        {
            var ret = new TestObject_PrivateCtor();
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        void ILoquiObjectSetter.SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds) => this.SetNthObject(index, obj, cmds);
        protected void SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds = null)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    this.BoolN = (Boolean?)obj;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        partial void ClearPartial(NotifyingUnsetParameters? cmds);

        protected void CallClearPartial_Internal(NotifyingUnsetParameters? cmds)
        {
            ClearPartial(cmds);
        }

        public void Clear(NotifyingUnsetParameters? cmds = null)
        {
            CallClearPartial_Internal(cmds);
            TestObject_PrivateCtorCommon.Clear(this, cmds);
        }


        public static TestObject_PrivateCtor Create(IEnumerable<KeyValuePair<ushort, object>> fields)
        {
            var ret = new TestObject_PrivateCtor();
            ILoquiObjectExt.CopyFieldsIn(ret, fields, def: null, skipProtected: false, cmds: null);
            return ret;
        }

        public static void CopyIn(IEnumerable<KeyValuePair<ushort, object>> fields, TestObject_PrivateCtor obj)
        {
            ILoquiObjectExt.CopyFieldsIn(obj, fields, def: null, skipProtected: false, cmds: null);
        }

    }
    #endregion

    #region Interface
    public interface ITestObject_PrivateCtor : ITestObject_PrivateCtorGetter, ILoquiClass<ITestObject_PrivateCtor, ITestObject_PrivateCtorGetter>, ILoquiClass<TestObject_PrivateCtor, ITestObject_PrivateCtorGetter>
    {
        new Boolean? BoolN { get; set; }

    }

    public interface ITestObject_PrivateCtorGetter : ILoquiObject
    {
        #region BoolN
        Boolean? BoolN { get; }

        #endregion

    }

    #endregion

}

namespace Loqui.Tests.Internals
{
    #region Field Index
    public enum TestObject_PrivateCtor_FieldIndex
    {
        BoolN = 0,
    }
    #endregion

    #region Registration
    public class TestObject_PrivateCtor_Registration : ILoquiRegistration
    {
        public static readonly TestObject_PrivateCtor_Registration Instance = new TestObject_PrivateCtor_Registration();

        public static ProtocolDefinition ProtocolDefinition => ProtocolDefinition_LoquiTests.Definition;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_LoquiTests.ProtocolKey,
            msgID: 15,
            version: 0);

        public const string GUID = "0df474a0-c6b4-4df1-9b98-311fbbe8414d";

        public const ushort FieldCount = 1;

        public static readonly Type MaskType = typeof(TestObject_PrivateCtor_Mask<>);

        public static readonly Type ErrorMaskType = typeof(TestObject_PrivateCtor_ErrorMask);

        public static readonly Type ClassType = typeof(TestObject_PrivateCtor);

        public static readonly Type CommonType = typeof(TestObject_PrivateCtorCommon);

        public const string FullName = "Loqui.Tests.TestObject_PrivateCtor";

        public const string Name = "TestObject_PrivateCtor";

        public const byte GenericCount = 0;

        public static readonly Type GenericRegistrationType = null;

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                case "BOOLN":
                    return (ushort)TestObject_PrivateCtor_FieldIndex.BoolN;
                default:
                    return null;
            }
        }

        public static bool GetNthIsEnumerable(ushort index)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsLoqui(ushort index)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsSingleton(ushort index)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static string GetNthName(ushort index)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return "BoolN";
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsNthDerivative(ushort index)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsProtected(ushort index)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static Type GetNthType(ushort index)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return typeof(Boolean?);
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        #region Interface
        ProtocolDefinition ILoquiRegistration.ProtocolDefinition => ProtocolDefinition;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        int ILoquiRegistration.FieldCount => FieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.CommonType => CommonType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => GetNameIndex(name);
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => GetNthIsEnumerable(index);
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => GetNthIsLoqui(index);
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => GetNthIsSingleton(index);
        string ILoquiRegistration.GetNthName(ushort index) => GetNthName(index);
        bool ILoquiRegistration.IsNthDerivative(ushort index) => IsNthDerivative(index);
        bool ILoquiRegistration.IsProtected(ushort index) => IsProtected(index);
        Type ILoquiRegistration.GetNthType(ushort index) => GetNthType(index);
        #endregion

    }
    #endregion

    #region Extensions
    public static class TestObject_PrivateCtorCommon
    {
        #region Copy Fields From
        public static void CopyFieldsFrom(
            this ITestObject_PrivateCtor item,
            ITestObject_PrivateCtorGetter rhs,
            TestObject_PrivateCtor_CopyMask copyMask = null,
            ITestObject_PrivateCtorGetter def = null,
            NotifyingFireParameters? cmds = null)
        {
            TestObject_PrivateCtorCommon.CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doErrorMask: false,
                errorMask: null,
                copyMask: copyMask,
                cmds: cmds);
        }

        public static void CopyFieldsFrom(
            this ITestObject_PrivateCtor item,
            ITestObject_PrivateCtorGetter rhs,
            out TestObject_PrivateCtor_ErrorMask errorMask,
            TestObject_PrivateCtor_CopyMask copyMask = null,
            ITestObject_PrivateCtorGetter def = null,
            NotifyingFireParameters? cmds = null)
        {
            TestObject_PrivateCtorCommon.CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doErrorMask: true,
                errorMask: out errorMask,
                copyMask: copyMask,
                cmds: cmds);
        }

        public static void CopyFieldsFrom(
            this ITestObject_PrivateCtor item,
            ITestObject_PrivateCtorGetter rhs,
            ITestObject_PrivateCtorGetter def,
            bool doErrorMask,
            out TestObject_PrivateCtor_ErrorMask errorMask,
            TestObject_PrivateCtor_CopyMask copyMask,
            NotifyingFireParameters? cmds)
        {
            TestObject_PrivateCtor_ErrorMask retErrorMask = null;
            Func<TestObject_PrivateCtor_ErrorMask> maskGetter = () =>
            {
                if (retErrorMask == null)
                {
                    retErrorMask = new TestObject_PrivateCtor_ErrorMask();
                }
                return retErrorMask;
            };
            CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doErrorMask: true,
                errorMask: maskGetter,
                copyMask: copyMask,
                cmds: cmds);
            errorMask = retErrorMask;
        }

        public static void CopyFieldsFrom(
            this ITestObject_PrivateCtor item,
            ITestObject_PrivateCtorGetter rhs,
            ITestObject_PrivateCtorGetter def,
            bool doErrorMask,
            Func<TestObject_PrivateCtor_ErrorMask> errorMask,
            TestObject_PrivateCtor_CopyMask copyMask,
            NotifyingFireParameters? cmds)
        {
            if (copyMask?.BoolN ?? true)
            {
                item.BoolN = rhs.BoolN;
            }
        }

        #endregion

        public static void SetNthObjectHasBeenSet(
            ushort index,
            bool on,
            ITestObject_PrivateCtor obj,
            NotifyingFireParameters? cmds = null)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static void UnsetNthObject(
            ushort index,
            ITestObject_PrivateCtor obj,
            NotifyingUnsetParameters? cmds = null)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    obj.BoolN = default(Boolean?);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthObjectHasBeenSet(
            ushort index,
            ITestObject_PrivateCtor obj)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return true;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static object GetNthObject(
            ushort index,
            ITestObject_PrivateCtorGetter obj)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    return obj.BoolN;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static void Clear(
            ITestObject_PrivateCtor item,
            NotifyingUnsetParameters? cmds = null)
        {
            item.BoolN = default(Boolean?);
        }

        public static TestObject_PrivateCtor_Mask<bool> GetEqualsMask(
            this ITestObject_PrivateCtorGetter item,
            ITestObject_PrivateCtorGetter rhs)
        {
            var ret = new TestObject_PrivateCtor_Mask<bool>();
            FillEqualsMask(item, rhs, ret);
            return ret;
        }

        public static void FillEqualsMask(
            ITestObject_PrivateCtorGetter item,
            ITestObject_PrivateCtorGetter rhs,
            TestObject_PrivateCtor_Mask<bool> ret)
        {
            ret.BoolN = item.BoolN == rhs.BoolN;
        }

        public static string ToString(
            this ITestObject_PrivateCtorGetter item,
            string name = null,
            TestObject_PrivateCtor_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            item.ToString(fg, name, printMask);
            return fg.ToString();
        }

        public static void ToString(
            this ITestObject_PrivateCtorGetter item,
            FileGeneration fg,
            string name = null,
            TestObject_PrivateCtor_Mask<bool> printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"{nameof(TestObject_PrivateCtor)} =>");
            }
            else
            {
                fg.AppendLine($"{name} ({nameof(TestObject_PrivateCtor)}) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (printMask?.BoolN ?? true)
                {
                    fg.AppendLine($"BoolN => {item.BoolN}");
                }
            }
            fg.AppendLine("]");
        }

        public static bool HasBeenSet(
            this ITestObject_PrivateCtorGetter item,
            TestObject_PrivateCtor_Mask<bool?> checkMask)
        {
            return true;
        }

        public static TestObject_PrivateCtor_Mask<bool> GetHasBeenSetMask(ITestObject_PrivateCtorGetter item)
        {
            var ret = new TestObject_PrivateCtor_Mask<bool>();
            ret.BoolN = true;
            return ret;
        }

        #region XML Translation
        #region XML Write
        public static void Write_XML(
            ITestObject_PrivateCtorGetter item,
            Stream stream)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: null,
                    item: item,
                    doMasks: false,
                    errorMask: out TestObject_PrivateCtor_ErrorMask errorMask);
            }
        }

        public static void Write_XML(
            ITestObject_PrivateCtorGetter item,
            Stream stream,
            out TestObject_PrivateCtor_ErrorMask errorMask)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: null,
                    item: item,
                    doMasks: true,
                    errorMask: out errorMask);
            }
        }

        public static void Write_XML(
            XmlWriter writer,
            string name,
            ITestObject_PrivateCtorGetter item,
            bool doMasks,
            out TestObject_PrivateCtor_ErrorMask errorMask)
        {
            TestObject_PrivateCtor_ErrorMask errMaskRet = null;
            Write_XML_Internal(
                writer: writer,
                name: name,
                item: item,
                doMasks: doMasks,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new TestObject_PrivateCtor_ErrorMask()) : default(Func<TestObject_PrivateCtor_ErrorMask>));
            errorMask = errMaskRet;
        }

        private static void Write_XML_Internal(
            XmlWriter writer,
            string name,
            ITestObject_PrivateCtorGetter item,
            bool doMasks,
            Func<TestObject_PrivateCtor_ErrorMask> errorMask)
        {
            try
            {
                using (new ElementWrapper(writer, "Loqui.Tests.TestObject_PrivateCtor"))
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        writer.WriteAttributeString("name", name);
                    }
                    {
                        Exception subMask;
                        BooleanXmlTranslation.Instance.Write(
                            writer,
                            nameof(item.BoolN),
                            item.BoolN,
                            doMasks: doMasks,
                            errorMask: out subMask);
                        if (subMask != null)
                        {
                            errorMask().BoolN = subMask;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!doMasks) throw;
                errorMask().Overall = ex;
            }
        }
        #endregion

        #endregion

    }
    #endregion

    #region Modules

    #region Mask
    public class TestObject_PrivateCtor_Mask<T> : IMask<T>
    {
        #region Ctors
        public TestObject_PrivateCtor_Mask()
        {
        }

        public TestObject_PrivateCtor_Mask(T initialValue)
        {
            this.BoolN = initialValue;
        }
        #endregion

        #region Members
        public T BoolN;
        #endregion

        #region All Equal
        public bool AllEqual(Func<T, bool> eval)
        {
            if (!eval(this.BoolN)) return false;
            return true;
        }
        #endregion

        #region Translate
        public TestObject_PrivateCtor_Mask<R> Translate<R>(Func<T, R> eval)
        {
            var ret = new TestObject_PrivateCtor_Mask<R>();
            ret.BoolN = eval(this.BoolN);
            return ret;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return ToString(printMask: null);
        }

        public string ToString(TestObject_PrivateCtor_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            ToString(fg, printMask);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg, TestObject_PrivateCtor_Mask<bool> printMask = null)
        {
            fg.AppendLine($"{nameof(TestObject_PrivateCtor_Mask<T>)} =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (printMask?.BoolN ?? true)
                {
                    fg.AppendLine($"BoolN => {BoolN.ToStringSafe()}");
                }
            }
            fg.AppendLine("]");
        }
        #endregion

    }

    public class TestObject_PrivateCtor_ErrorMask : IErrorMask
    {
        #region Members
        public Exception Overall { get; set; }
        private List<string> _warnings;
        public List<string> Warnings
        {
            get
            {
                if (_warnings == null)
                {
                    _warnings = new List<string>();
                }
                return _warnings;
            }
        }
        public Exception BoolN;
        #endregion

        #region IErrorMask
        public void SetNthException(ushort index, Exception ex)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    this.BoolN = ex;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public void SetNthMask(ushort index, object obj)
        {
            TestObject_PrivateCtor_FieldIndex enu = (TestObject_PrivateCtor_FieldIndex)index;
            switch (enu)
            {
                case TestObject_PrivateCtor_FieldIndex.BoolN:
                    this.BoolN = (Exception)obj;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }
        #endregion

        #region To String
        public override string ToString()
        {
            var fg = new FileGeneration();
            ToString(fg);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg)
        {
            fg.AppendLine("TestObject_PrivateCtor_ErrorMask =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (BoolN != null)
                {
                    fg.AppendLine($"BoolN => {BoolN.ToStringSafe()}");
                }
            }
            fg.AppendLine("]");
        }
        #endregion

        #region Combine
        public TestObject_PrivateCtor_ErrorMask Combine(TestObject_PrivateCtor_ErrorMask rhs)
        {
            var ret = new TestObject_PrivateCtor_ErrorMask();
            ret.BoolN = this.BoolN.Combine(rhs.BoolN);
            return ret;
        }
        public static TestObject_PrivateCtor_ErrorMask Combine(TestObject_PrivateCtor_ErrorMask lhs, TestObject_PrivateCtor_ErrorMask rhs)
        {
            if (lhs != null && rhs != null) return lhs.Combine(rhs);
            return lhs ?? rhs;
        }
        #endregion

    }
    public class TestObject_PrivateCtor_CopyMask
    {
        #region Members
        public bool BoolN;
        #endregion

    }
    #endregion


    #endregion

}
