using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace BetterDDSec.Models
{
    /// <summary>
    /// Overkill version of string mocking.
    /// </summary>
    [ComVisible(true)]
    public class Name : IComparable, ICloneable, IConvertible, IEnumerable, IComparable<String>, IEnumerable<char>, IEquatable<String>
    {
        private string _value;

        public Name()
        {   
        }
        public Name(string value)
        {
            //Validation go here.
            //What is a resonable name?
            //Minimum length?
            //Maximum length?
            //Disallowed characters?
            //Are the rules the same for all names?
            //Use culture invariants?
            _value = value;
        }

        /// <summary>
        /// Auto instantiate a new Name object as if it were a regular String through
        /// Name name = "the name" instead of Name name = new Name("the name").
        /// </summary>
        /// <param name="name">Value to give to the name</param>
        public static implicit operator Name(string name)
        {
            return (name == null) ? null : new Name(name);
        }
        

        public static implicit operator string(Name self)
        {
            return self._value;
        }

        #region Interface implementations

        public int CompareTo(object obj)
        {
            return _value.CompareTo(obj.ToString());
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public TypeCode GetTypeCode()
        {
            return _value.GetTypeCode();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToBoolean(provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToChar(provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToSByte(provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToByte(provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToInt16(provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToUInt16(provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToInt32(provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToUInt32(provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToInt64(provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToUInt64(provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToSingle(provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToDouble(provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToDecimal(provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToDateTime(provider);
        }

        public string ToString(IFormatProvider provider)
        {
            return _value.ToString(provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)_value).ToType(conversionType, provider);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_value).GetEnumerator();
        }

        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            return ((IEnumerable<char>)_value).GetEnumerator();
        }

        public int CompareTo(string other)
        {
            return _value.CompareTo(other);
        }

        public bool Equals(string other)
        {
            return _value.Equals(other);
        }

        #endregion
        #region String mock functionality
        public Name Empty => string.Empty;

        public Name(char[] value) : this(new string(value))
        {
        }

        public Name(char c, int count) : this(new string(c, count))
        {
        }

        public Name(char[] value, int startIndex, int length) : this(new string(value, startIndex, length))
        {
        }

        public char this[int index]
        {
            get
            {
                return _value[index];
            }
        }
        public int Length
        {
            get
            {
                return _value.Length;
            }
        }

        public static int Compare(Name nameA, Name nameB, bool ignoreCase)
        {
            return string.Compare(nameA.ToString(), nameB.ToString(), ignoreCase);
        }
        [SecuritySafeCritical]
        public static int Compare(Name nameA, int indexA, Name nameB, int indexB, int length, StringComparison comparisonType)
        {
            return string.Compare(nameA.ToString(), indexA, nameB.ToString(), indexB, length, comparisonType);
        }
        public static int Compare(Name nameA, int indexA, Name nameB, int indexB, int length, CultureInfo culture, CompareOptions options)
        {
            return string.Compare(nameA.ToString(), indexA, nameB.ToString(), indexB, length, culture, options);
        }
        public static int Compare(Name nameA, int indexA, Name nameB, int indexB, int length, bool ignoreCase, CultureInfo culture)
        {
            return string.Compare(nameA.ToString(), indexA, nameB.ToString(), indexB, length, ignoreCase, culture);
        }
        public static int Compare(Name nameA, int indexA, Name nameB, int indexB, int length, bool ignoreCase)
        {
            return string.Compare(nameA.ToString(), indexA, nameB.ToString(), indexB, length, ignoreCase);
        }
        public static int Compare(Name nameA, int indexA, Name nameB, int indexB, int length)
        {
            return string.Compare(nameA.ToString(), indexA, nameB.ToString(), indexB, length);
        }
        public static int Compare(Name nameA, Name nameB, bool ignoreCase, CultureInfo culture)
        {
            return string.Compare(nameA.ToString(), nameB.ToString(), ignoreCase, culture);
        }
        public static int Compare(Name nameA, Name nameB, CultureInfo culture, CompareOptions options)
        {
            return string.Compare(nameA.ToString(), nameB.ToString(), culture, options);
        }
        [SecuritySafeCritical]
        public static int Compare(Name nameA, Name nameB, StringComparison comparisonType)
        {
            return string.Compare(nameA.ToString(), nameB.ToString(), comparisonType);
        }
        public static int Compare(Name nameA, Name nameB)
        {
            return string.Compare(nameA.ToString(), nameB.ToString());
        }
        [SecuritySafeCritical]
        public static int CompareOrdinal(Name nameA, int indexA, Name nameB, int indexB, int length)
        {
            return string.CompareOrdinal(nameA.ToString(), indexA, nameB.ToString(), indexB, length);
        }
        public static int CompareOrdinal(Name nameA, Name nameB)
        {
            return string.CompareOrdinal(nameA.ToString(), nameB.ToString());
        }
        [SecuritySafeCritical]
        public static Name Concat(Name name0, Name name1)
        {
            return new Name(string.Concat(name0, name1));
        }
        [SecuritySafeCritical]
        public static Name Concat(Name name0, Name name1, Name name2)
        {
            return new Name(string.Concat(name0, name1, name2));
        }
        public static Name Concat(object arg0)
        {
            return new Name(string.Concat(arg0));
        }
        [SecuritySafeCritical]
        public static Name Concat(Name name0, Name name1, Name name2, Name name3)
        {
            return new Name(string.Concat(name0, name1, name2, name3));
        }
        public static Name Concat(object arg0, object arg1)
        {
            return new Name(string.Concat(arg0, arg1));
        }
        public static Name Concat(params Name[] values)
        {
            List<string> strValues = new List<string>();
            foreach (Name name in values)
            {
                strValues.Add(name.ToString());
            }

            return new Name(string.Concat(strValues.ToArray()));
        }
        [CLSCompliant(false)]
#pragma warning disable CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute
        public static Name Concat(object arg0, object arg1, object arg2, object arg3)
#pragma warning restore CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute
        {
            return new Name(string.Concat(arg0, arg1, arg2, arg3));
        }

        public static Name Concat(params object[] args)
        {
            return new Name(string.Concat(args));
        }
        [ComVisible(false)]
        public static Name Concat<T>(IEnumerable<T> values)
        {
            return new Name(string.Concat(values));
        }
        [ComVisible(false)]
        public static Name Concat(IEnumerable<Name> values)
        {
            return new Name(string.Concat(values));
        }
        public static Name Concat(object arg0, object arg1, object arg2)
        {
            return new Name(string.Concat(arg0, arg1, arg2));
        }
        [SecuritySafeCritical]
        public static Name Copy(Name name)
        {
            return new Name(name.ToString());
        }
        public static bool Equals(Name a, Name b)
        {
            return string.Equals(a.ToString(), b.ToString());
        }
        [SecuritySafeCritical]
        public static bool Equals(Name a, Name b, StringComparison comparisonType)
        {
            return string.Equals(a.ToString(), b.ToString(), comparisonType);
        }
        public static Name Format(string format, object arg0)
        {
            return new Name(string.Format(format, arg0));
        }
        public static Name Format(string format, object arg0, object arg1, object arg2)
        {
            return new Name(string.Format(format, arg0, arg1, arg2));
        }
        public static Name Format(string format, params object[] args)
        {
            return new Name(string.Format(format, args));
        }
        public static Name Format(string format, object arg0, object arg1)
        {
            return new Name(string.Format(format, arg0, arg1));
        }
        public static Name Format(IFormatProvider provider, string format, object arg0, object arg1, object arg2)
        {
            return new Name(string.Format(provider, format, arg0, arg1, arg2));
        }
        public static Name Format(IFormatProvider provider, string format, params object[] args)
        {
            return new Name(string.Format(provider, format, args));
        }
        public static Name Format(IFormatProvider provider, string format, object arg0, object arg1)
        {
            return new Name(string.Format(provider, format, arg0, arg1));
        }
        public static Name Format(IFormatProvider provider, string format, object arg0)
        {
            return new Name(string.Format(provider, format, arg0));
        }

        public static bool IsNullOrEmpty(Name value)
        {
            return string.IsNullOrEmpty(value.ToString());
        }
        public static bool IsNullOrWhiteSpace(Name value)
        {
            return string.IsNullOrWhiteSpace(value.ToString());
        }
        
        public int CompareTo(Name nameB)
        {
            return CompareTo((object)nameB);
        }
        public bool Contains(string value)
        {
            return _value.Contains(value);
        }
        public bool EndsWith(string value)
        {
            return _value.EndsWith(value);
        }
        [ComVisible(false)]
        [SecuritySafeCritical]
        public bool EndsWith(string value, StringComparison comparisonType)
        {
            return _value.EndsWith(value, comparisonType);
        }
        public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
        {
            return _value.EndsWith(value, ignoreCase, culture);
        }
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public bool Equals(Name value)
        {
            return _value.Equals(value.ToString());
        }
        [SecuritySafeCritical]
        public bool Equals(Name value, StringComparison comparisonType)
        {
            return _value.Equals(value.ToString(), comparisonType);
        }
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public override bool Equals(object obj)
        {
            return _value.Equals(obj);
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [SecuritySafeCritical]
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        [SecuritySafeCritical]
        public int IndexOf(char value, int startIndex, int count)
        {
            return _value.IndexOf(value, startIndex, count);
        }
        public int IndexOf(char value, int startIndex)
        {
            return _value.IndexOf(value, startIndex);
        }
        public int IndexOf(string value)
        {
            return _value.IndexOf(value);
        }
        public int IndexOf(string value, int startIndex)
        {
            return _value.IndexOf(value, startIndex);
        }
        public int IndexOf(string value, int startIndex, int count)
        {
            return _value.IndexOf(value, startIndex, count);
        }
        public int IndexOf(string value, StringComparison comparisonType)
        {
            return _value.IndexOf(value, comparisonType);
        }
        public int IndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            return _value.IndexOf(value, startIndex, comparisonType);
        }
        public int IndexOf(char value)
        {
            return _value.IndexOf(value);
        }
        [SecuritySafeCritical]
        public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            return _value.IndexOf(value, startIndex, count, comparisonType);
        }
        [SecuritySafeCritical]
        public int IndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return _value.IndexOfAny(anyOf, startIndex, count);
        }
        public int IndexOfAny(char[] anyOf, int startIndex)
        {
            return _value.IndexOfAny(anyOf, startIndex);
        }
        public int IndexOfAny(char[] anyOf)
        {
            return _value.IndexOfAny(anyOf);
        }
        [SecuritySafeCritical]
        public Name Insert(int startIndex, string value)
        {
            return new Name(_value.Insert(startIndex, value));
        }
        public bool IsNormalized()
        {
            return _value.IsNormalized();
        }
        [SecuritySafeCritical]
        public bool IsNormalized(NormalizationForm normalizationForm)
        {
            return _value.IsNormalized(normalizationForm);
        }
        [SecuritySafeCritical]
        public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            return _value.LastIndexOf(value, startIndex, count, comparisonType);
        }
        [SecuritySafeCritical]
        public int LastIndexOf(char value, int startIndex, int count)
        {
            return _value.LastIndexOf(value, startIndex, count);
        }
        public int LastIndexOf(char value, int startIndex)
        {
            return _value.LastIndexOf(value, startIndex);
        }
        public int LastIndexOf(char value)
        {
            return _value.LastIndexOf(value);
        }
        public int LastIndexOf(string value, int startIndex)
        {
            return _value.LastIndexOf(value, startIndex);
        }
        public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            return _value.LastIndexOf(value, startIndex, comparisonType);
        }
        public int LastIndexOf(string value, int startIndex, int count)
        {
            return _value.LastIndexOf(value, startIndex, count);
        }
        public int LastIndexOf(string value, StringComparison comparisonType)
        {
            return _value.LastIndexOf(value, comparisonType);
        }
        public int LastIndexOf(string value)
        {
            return _value.LastIndexOf(value);
        }
        public int LastIndexOfAny(char[] anyOf)
        {
            return _value.LastIndexOfAny(anyOf);
        }
        public int LastIndexOfAny(char[] anyOf, int startIndex)
        {
            return _value.LastIndexOfAny(anyOf, startIndex);
        }
        [SecuritySafeCritical]
        public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return _value.LastIndexOfAny(anyOf, startIndex, count);
        }
        public Name Normalize()
        {
            return new Name(_value.Normalize());
        }
        [SecuritySafeCritical]
        public Name Normalize(NormalizationForm normalizationForm)
        {
            return new Name(_value.Normalize(normalizationForm));
        }
        public Name PadLeft(int totalWidth, char paddingChar)
        {
            return new Name(_value.PadLeft(totalWidth, paddingChar));
        }
        public Name PadLeft(int totalWidth)
        {
            return new Name(_value.PadLeft(totalWidth));
        }
        public Name PadRight(int totalWidth, char paddingChar)
        {
            return new Name(_value.PadRight(totalWidth, paddingChar));
        }
        public Name PadRight(int totalWidth)
        {
            return new Name(_value.PadRight(totalWidth));
        }
        public Name Remove(int startIndex)
        {
            return new Name(_value.Remove(startIndex));
        }
        [SecuritySafeCritical]
        public Name Remove(int startIndex, int count)
        {
            return new Name(_value.Remove(startIndex, count));
        }
        public Name Replace(string oldValue, string newValue)
        {
            return new Name(_value.Replace(oldValue, newValue));
        }
        public Name Replace(char oldChar, char newChar)
        {
            return new Name(_value.Replace(oldChar, newChar));
        }

        private Name[] SplitFromArray(string[] s)
        {
            Name[] n = new Name[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                n[i] = new Name(s[i]);
            }

            return n;
        }
        public Name[] Split(params char[] separator)
        {
            return SplitFromArray(_value.Split(separator));
        }
        public Name[] Split(char[] separator, int count)
        {
            return SplitFromArray(_value.Split(separator, count));
        }

        [ComVisible(false)]
        public Name[] Split(char[] separator, StringSplitOptions options)
        {
            return SplitFromArray(_value.Split(separator, options));
        }
        [ComVisible(false)]
        public Name[] Split(char[] separator, int count, StringSplitOptions options)
        {
            return SplitFromArray(_value.Split(separator, options));
        }
        [ComVisible(false)]
        public Name[] Split(string[] separator, StringSplitOptions options)
        {
            return SplitFromArray(_value.Split(separator, options));
        }
        [ComVisible(false)]
        public Name[] Split(string[] separator, int count, StringSplitOptions options)
        {
            string[] s = _value.Split(separator, options);

            return SplitFromArray(s);
        }
        [ComVisible(false)]
        [SecuritySafeCritical]
        public bool StartsWith(string value, StringComparison comparisonType)
        {
            return _value.StartsWith(value, comparisonType);
        }
        public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
        {
            return _value.StartsWith(value, ignoreCase, culture);
        }
        public bool StartsWith(string value)
        {
            return _value.StartsWith(value);
        }
        [SecuritySafeCritical]
        public Name Substring(int startIndex, int length)
        {
            return new Name(_value.Substring(startIndex, length));
        }
        public Name Substring(int startIndex)
        {
            return new Name(_value.Substring(startIndex));
        }
        [SecuritySafeCritical]
        public char[] ToCharArray(int startIndex, int length)
        {
            return _value.ToCharArray(startIndex, length);
        }
        [SecuritySafeCritical]
        public char[] ToCharArray()
        {
            return _value.ToCharArray();
        }
        public Name ToLower(CultureInfo culture)
        {
            return new Name(_value.ToLower(culture));
        }
        public Name ToLower()
        {
            return new Name(_value.ToLower());
        }
        public Name ToLowerInvariant()
        {
            return new Name(_value.ToLowerInvariant());
        }
        public Name ToUpper()
        {
            return new Name(_value.ToUpper());
        }
        public Name ToUpper(CultureInfo culture)
        {
            return new Name(_value.ToUpper(culture));
        }
        public Name ToUpperInvariant()
        {
            return new Name(_value.ToUpperInvariant());
        }
        public Name Trim(params char[] trimChars)
        {
            return new Name(_value.Trim(trimChars));
        }
        public Name Trim()
        {
            return new Name(_value.Trim());
        }
        public Name TrimEnd(params char[] trimChars)
        {
            return new Name(_value.TrimEnd(trimChars));
        }
        public Name TrimStart(params char[] trimChars)
        {
            return new Name(_value.TrimStart(trimChars));
        }

        public static bool operator ==(Name a, Name b)
        {
            if (object.ReferenceEquals(a, null))
                return object.ReferenceEquals(b, null);

            return a.Equals(b);
        }
        public static bool operator !=(Name a, Name b)
        {
            if (object.ReferenceEquals(a, null))
                return !object.ReferenceEquals(b, null);

            return !a.Equals(b);
        }

        #endregion
        #region Overrides
        public override string ToString()
        {
            return _value;
        }

        #endregion
    }
}