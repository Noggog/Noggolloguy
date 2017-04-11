/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Noggolloquy.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noggolloquy;
using Noggog;
using Noggog.Notifying;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Noggolloquy.Xml;

namespace Noggolloquy.Tests
{
    #region Class
    public partial class TestGenericObject<T, R> : ITestGenericObject<T, R>, INoggolloquySerializer, IEquatable<TestGenericObject<T, R>>
        where R : ObjectToRef, INoggolloquyReaderSerializer
    {
        public TestGenericObject()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #region Ref
        private readonly INotifyingItem<R> _Ref = new NotifyingItem<R>();
        public INotifyingItem<R> Ref_Property => this._Ref;
        R ITestGenericObjectGetter<T, R>.Ref => this.Ref;
        public R Ref { get { return _Ref.Value; } set { _Ref.Value = value; } }
        INotifyingItem<R> ITestGenericObject<T, R>.Ref_Property => this.Ref_Property;
        INotifyingItemGetter<R> ITestGenericObjectGetter<T, R>.Ref_Property => this.Ref_Property;
        #endregion


        #region Noggolloquy Getter Interface

        public static string NoggolloquyName => "TestGenericObject";
        string INoggolloquyObjectGetter.NoggolloquyName => "TestGenericObject";
        public static string NoggolloquyFullName => "Noggolloquy.Tests.TestGenericObject";
        string INoggolloquyObjectGetter.NoggolloquyFullName => "Noggolloquy.Tests.TestGenericObject";
        public static ProtocolKey Noggolloquy_ProtocolKey_Static => new ProtocolKey(1);
        public ProtocolKey Noggolloquy_ProtocolKey => Noggolloquy_ProtocolKey_Static;
        public static ProtocolDefinition Noggolloquy_ProtocolDefinition_Static => new ProtocolDefinition(
            key: Noggolloquy_ProtocolKey_Static,
            nickname: "NoggolloquyTests");
        public ProtocolDefinition Noggolloquy_ProtocolDefinition => Noggolloquy_ProtocolDefinition_Static;
        public static ObjectKey Noggolloquy_ObjectKey_Static => new ObjectKey(protocolKey: Noggolloquy_ProtocolKey_Static, msgID: 1, version: 0);
        public ObjectKey Noggolloquy_ObjectKey => Noggolloquy_ObjectKey_Static;
        public int FieldCount => 1;

        public string Noggolloquy_GUID => "c0c6b45b-906e-4a34-8e26-13ac0f04e3f8";

        public static object GetNthObject(ushort index, ITestGenericObjectGetter<T, R> obj)
        {
            switch (index)
            {
                case 0:
                    return obj.Ref;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthObjectHasBeenSet(ushort index, ITestGenericObject<T, R> obj)
        {
            switch (index)
            {
                case 0:
                    return obj.Ref_Property.HasBeenSet;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public Type GetNthType(ushort index) => TestGenericObjectCommon<T, R>.GetNthType(index);

        public string GetNthName(ushort index) => TestGenericObjectCommon<T, R>.GetNthName(index);

        public object GetNthObject(ushort index) => TestGenericObjectCommon<T, R>.GetNthObject(index, this);

        public bool GetNthObjectHasBeenSet(ushort index) => TestGenericObjectCommon<T, R>.GetNthObjectHasBeenSet(index, this);

        public ushort? GetNameIndex(StringCaseAgnostic str) => TestGenericObjectCommon<T, R>.GetNameIndex(str);

        public bool IsNthDerivative(ushort index) => TestGenericObjectCommon<T, R>.IsNthDerivative(index);

        public bool IsReadOnly(ushort index) => TestGenericObjectCommon<T, R>.IsReadOnly(index);

        public bool GetNthIsEnumerable(ushort index) => TestGenericObjectCommon<T, R>.GetNthIsEnumerable(index);

        public bool GetNthIsNoggolloquy(ushort index) => TestGenericObjectCommon<T, R>.GetNthIsNoggolloquy(index);

        public bool GetNthIsSingleton(ushort index) => TestGenericObjectCommon<T, R>.GetNthIsSingleton(index);

        public void SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds) => TestGenericObjectCommon<T, R>.SetNthObject(this, index, obj, cmds);

        public Type GetMaskType() => typeof(TestGenericObject_Mask<>);

        public Type GetErrorMaskType() => typeof(TestGenericObject_ErrorMask);

        #endregion

        #region Noggolloquy Interface
        public void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            TestGenericObjectCommon<T, R>.SetNthObjectHasBeenSet(index, on, this);
        }

        public void SetNthObjectHasBeenSet_Internal(ushort index, bool on, TestGenericObject<T, R> obj)
        {
            switch (index)
            {
                case 0:
                    obj._Ref.SetHasBeenSet(on);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public void CopyFieldsFrom(ITestGenericObjectGetter<T, R> rhs, ITestGenericObjectGetter<T, R> def = null, NotifyingFireParameters? cmds = null)
        {
            TestGenericObjectCommon<T, R>.CopyFieldsFrom(this, rhs, def, null, cmds);
        }

        public void CopyFieldsFrom(ITestGenericObjectGetter<T, R> rhs, out TestGenericObject_ErrorMask errorMask, ITestGenericObjectGetter<T, R> def = null, NotifyingFireParameters? cmds = null)
        {
            var retErrorMask = new TestGenericObject_ErrorMask();
            errorMask = retErrorMask;
            TestGenericObjectCommon<T, R>.CopyFieldsFrom(this, rhs, def, retErrorMask, cmds);
        }

        #endregion

        #region To String
        public override string ToString()
        {
            return this.PrintPretty();
        }
        #endregion

        #region Equals and Hash
        public override bool Equals(object obj)
        {
            TestGenericObject<T, R> rhs = obj as TestGenericObject<T, R>;
            if (rhs == null) return false;
            return Equals(obj);
        }

        public bool Equals(TestGenericObject<T, R> rhs)
        {
            if (!object.Equals(this.Ref, rhs.Ref)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return 
            HashHelper.GetHashCode(Ref)
            ;
        }

        #endregion

        #region Set To
        public void SetTo(TestGenericObject<T, R> rhs, ITestGenericObject<T, R> def = null, NotifyingFireParameters? cmds = null)
        {
            SetTo_Internal(rhs, def, null, cmds);
        }

        public void SetTo(TestGenericObject<T, R> rhs, ITestGenericObject<T, R> def, out TestGenericObject_ErrorMask errorMask, NotifyingFireParameters? cmds = null)
        {
            var retErrorMask = new TestGenericObject_ErrorMask();
            errorMask = retErrorMask;
            SetTo_Internal(rhs, def, retErrorMask, cmds);
        }

        private void SetTo_Internal(TestGenericObject<T, R> rhs, ITestGenericObject<T, R> def, TestGenericObject_ErrorMask errorMask, NotifyingFireParameters? cmds)
        {
            try
            {
                if (rhs.Ref_Property.HasBeenSet)
                {
                    this.Ref_Property.Set(
                        rhs.Ref,
                        cmds);
                }
                else
                {
                    if (def == null)
                    {
                        this.Ref_Property.Unset(cmds.ToUnsetParams());
                    }
                    else
                    {
                        this.Ref_Property.Set(
                            def.Ref,
                            cmds);
                    }
                }

            }
            catch (Exception ex)
            {
                if (errorMask != null)
                {
                    errorMask.SetNthException(0, ex);
                }
            }
        }
        #endregion
        #region XML Translation
        public static TestGenericObject<T, R> CreateFromXML(XElement root)
        {
            var ret = new TestGenericObject<T, R>();
            NoggXmlTranslation<TestGenericObject<T, R>, TestGenericObject_ErrorMask>.Instance.CopyIn(
                root: root,
                item: ret,
                doMasks: false,
                mask: out TestGenericObject_ErrorMask errorMask,
                cmds: null);
            return ret;
        }

        public static TestGenericObject<T, R> CreateFromXML(XElement root, out TestGenericObject_ErrorMask errorMask)
        {
            var ret = new TestGenericObject<T, R>();
            NoggXmlTranslation<TestGenericObject<T, R>, TestGenericObject_ErrorMask>.Instance.CopyIn(
                root: root,
                item: ret,
                doMasks: true,
                mask: out errorMask,
                cmds: null);
            return ret;
        }

        public void CopyInFromXML(XElement root, NotifyingFireParameters? cmds = null)
        {
            NoggXmlTranslation<TestGenericObject<T, R>, TestGenericObject_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                doMasks: false,
                mask: out TestGenericObject_ErrorMask errorMask,
                cmds: cmds);
        }

        public virtual void CopyInFromXML(XElement root, out TestGenericObject_ErrorMask errorMask, NotifyingFireParameters? cmds = null)
        {
            NoggXmlTranslation<TestGenericObject<T, R>, TestGenericObject_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                doMasks: true,
                mask: out errorMask,
                cmds: cmds);
        }

        public void WriteXMLToStream(Stream stream)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                WriteXML(writer);
            }
        }

        public void WriteXML(XmlWriter writer, out TestGenericObject_ErrorMask errorMask, string name = null)
        {
            NoggXmlTranslation<TestGenericObject<T, R>, TestGenericObject_ErrorMask>.Instance.Write(
                writer: writer,
                name: name,
                item: this,
                doMasks: true,
                mask: out errorMask);
        }

        public void WriteXML(XmlWriter writer, string name)
        {
            NoggXmlTranslation<TestGenericObject<T, R>, TestGenericObject_ErrorMask>.Instance.Write(
                writer: writer,
                name: name,
                item: this,
                doMasks: false,
                mask: out TestGenericObject_ErrorMask errorMask);
        }

        public void WriteXML(XmlWriter writer)
        {
            NoggXmlTranslation<TestGenericObject<T, R>, TestGenericObject_ErrorMask>.Instance.Write(
                writer: writer,
                name: null,
                item: this,
                doMasks: false,
                mask: out TestGenericObject_ErrorMask errorMask);
        }

        #endregion
        #region Mask
        #endregion
        object ICopyable.Copy()
        {
            return this.Copy_ToObject(def: null);
        }

        protected object Copy_ToObject(object def = null)
        {
            var ret = new TestGenericObject<T, R>();
            ret.CopyFieldsFrom_Generic(this, def: def, cmds: null);
            return ret;
        }

        void ICopyInAble.CopyFieldsFrom(object rhs, object def, NotifyingFireParameters? cmds)
        {
            this.CopyFieldsFrom_Generic(rhs, def, cmds);
        }

        protected void CopyFieldsFrom_Generic(object rhs, object def, NotifyingFireParameters? cmds)
        {
            if (rhs is TestGenericObject<T, R> rhsCast)
            {
                this.CopyFieldsFrom(rhsCast, def as TestGenericObject<T, R>, cmds);
            }
        }

        public TestGenericObject<T, R> Copy(ITestGenericObjectGetter<T, R> def = null)
        {
            return (TestGenericObject<T, R>)this.Copy_ToObject(def: def);
        }

        public static TestGenericObject<T, R> Copy(ITestGenericObjectGetter<T, R> item, ITestGenericObjectGetter<T, R> def = null)
        {
            var ret = new TestGenericObject<T, R>();
            ret.CopyFieldsFrom(item, def);
            return ret;
        }

        partial void ClearPartial(NotifyingUnsetParameters? cmds);

        public void Clear(NotifyingUnsetParameters? cmds = null)
        {
            ClearPartial(cmds);
            this.Ref_Property.Unset(cmds.ToUnsetParams());
        }

    }
    #endregion

    #region Interface
    public interface ITestGenericObject<T, R> : ITestGenericObjectGetter<T, R>, INoggolloquyClass<ITestGenericObject<T, R>, ITestGenericObjectGetter<T, R>>, INoggolloquyClass<TestGenericObject<T, R>, ITestGenericObjectGetter<T, R>>
        where R : ObjectToRef, INoggolloquyReaderSerializer
    {
        new R Ref { get; set; }
        new INotifyingItem<R> Ref_Property { get; }

    }

    public interface ITestGenericObjectGetter<T, R> : INoggolloquyObjectGetter
        where R : ObjectToRef, INoggolloquyReaderSerializer
    {
        #region Ref
        R Ref { get; }
        INotifyingItemGetter<R> Ref_Property { get; }

        #endregion


        #region XML Translation
        #endregion
        #region Mask
        #endregion
    }

    #endregion

    #region Extensions
    public static class TestGenericObjectCommon<T, R>
        where R : ObjectToRef, INoggolloquyReaderSerializer
    {
        public static Type GetNthType(ushort index)
        {
            switch (index)
            {
                case 0:
                    return typeof(R);
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsNthDerivative(ushort index)
        {
            switch (index)
            {
                case 0:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static object GetNthObject(ushort index, ITestGenericObjectGetter<T, R> obj)
        {
            switch (index)
            {
                case 0:
                    return obj.Ref;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static string GetNthName(ushort index)
        {
            switch (index)
            {
                case 0:
                    return "Ref";
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsSingleton(ushort index)
        {
            switch (index)
            {
                case 0:
                    return false;
                default:
                    return false;
            }
        }

        #region Copy Fields From
        public static void CopyFieldsFrom(ITestGenericObject<T, R> item, ITestGenericObjectGetter<T, R> rhs, ITestGenericObjectGetter<T, R> def, TestGenericObject_ErrorMask errorMask, NotifyingFireParameters? cmds)
        {
            try
            {
                if (rhs.Ref_Property.HasBeenSet)
                {
                    if (rhs.Ref == null)
                    {
                        item.Ref = null;
                    }
                    else
                    {
                        if (item.Ref == null)
                        {
                            item.Ref = (R)rhs.Ref.Copy();
                        }
                        else
                        {
                            item.Ref.CopyFieldsFrom(rhs.Ref, def: def?.Ref, cmds: cmds);
                        }
                    }
                }
                else
                {
                    if (def == null)
                    {
                        item.Ref_Property.Unset(cmds.ToUnsetParams());
                    }
                    else
                    {
                        if (rhs.Ref == null)
                        {
                            item.Ref = null;
                        }
                        else
                        {
                            if (item.Ref == null)
                            {
                                item.Ref = (R)def.Ref.Copy();
                            }
                            else
                            {
                                item.Ref.CopyFieldsFrom(def.Ref, null, cmds: cmds);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (errorMask != null)
                {
                    errorMask.SetNthException(0, ex);
                }
            }
        }

        #endregion

        public static void SetNthObjectHasBeenSet(ushort index, bool on, ITestGenericObject<T, R> obj)
        {
            switch (index)
            {
                case 0:
                    obj.Ref_Property.SetHasBeenSet(on);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                case "REF":
                    return 0;
                default:
                    throw new ArgumentException($"Queried unknown field: {{str}}");
            }
        }

        public static bool IsReadOnly(ushort index)
        {
            switch (index)
            {
                case 0:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsEnumerable(ushort index)
        {
            switch (index)
            {
                case 0:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsNoggolloquy(ushort index)
        {
            switch (index)
            {
                case 0:
                    return true;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthObjectHasBeenSet(ushort index, ITestGenericObject<T, R> obj)
        {
            switch (index)
            {
                case 0:
                    return obj.Ref_Property.HasBeenSet;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static void SetNthObject(ITestGenericObject<T, R> nog, ushort index, object obj, NotifyingFireParameters? cmds = null)
        {
            switch (index)
            {
                case 0:
                    nog.Ref_Property.Set(
                        ((R)obj),
                        cmds);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

    }
    public static class TestGenericObjectExt
    {
        public static TestGenericObject<T, R> Copy_ToNoggolloquy<T, R>(this ITestGenericObjectGetter<T, R> item)
            where R : ObjectToRef, INoggolloquyReaderSerializer
        {
            return TestGenericObject<T, R>.Copy(item, def: null);
        }

    }
    #endregion

    #region Modules
    #region XML Translation
    #endregion

    #region Mask
    public class TestGenericObject_Mask<T> 
    {
        public MaskItem<T, object> Ref { get; set; }
    }

    public class TestGenericObject_ErrorMask : IErrorMask
    {
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
        public MaskItem<Exception, object> Ref;

        public void SetNthException(ushort index, Exception ex)
        {
            switch (index)
            {
                case 0:
                    this.Ref = new MaskItem<Exception, object>(ex, null);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public void SetNthMask(ushort index, object obj)
        {
            switch (index)
            {
                case 0:
                    this.Ref = (MaskItem<Exception, object>)obj;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }
    }
    #endregion

    #endregion

    #region Noggolloquy Interfaces
    #endregion

}
