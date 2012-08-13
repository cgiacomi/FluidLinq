namespace FluidLinq
{
    using System;

    internal static class DefaultConversionFunctions
    {
        public static Func<string, IFormatProvider, object> Byte
        {
            get
            {
                return (str, formatProvider) => Convert.ToByte(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> SByte
        {
            get
            {
                return (str, formatProvider) => Convert.ToSByte(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> Int16
        {
            get
            {
                return (str, formatProvider) => Convert.ToInt16(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> UInt64
        {
            get
            {
                return (str, formatProvider) => Convert.ToUInt64(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> UInt32
        {
            get
            {
                return (str, formatProvider) => Convert.ToUInt32(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> UInt16
        {
            get
            {
                return (str, formatProvider) => Convert.ToUInt16(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> Int64
        {
            get
            {
                return (str, formatProvider) => Convert.ToInt64(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> Int32
        {
            get
            {
                return (str, formatProvider) => Convert.ToInt32(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> DateTime
        {
            get
            {
                return (str, formatProvider) => Convert.ToDateTime(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> String
        {
            get
            {
                return (str, formatProvider) => str;
            }
        }

        public static Func<string, IFormatProvider, object> Decimal
        {
            get
            {
                return (str, formatProvider) => Convert.ToDecimal(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> Char
        {
            get
            {
                return (str, formatProvider) => Convert.ToChar(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> Boolean
        {
            get
            {
                return (str, formatProvider) => Convert.ToBoolean(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> Double
        {
            get
            {
                return (str, formatProvider) => Convert.ToDouble(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> Single
        {
            get
            {
                return (str, formatProvider) => Convert.ToSingle(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, object> NullableDateTime
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        DateTime? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToDateTime(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableDecimal
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Decimal? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToDecimal(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableChar
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Char? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToChar(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableBoolean
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Boolean? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToBoolean(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableDouble
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Double? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToDouble(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableSingle
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Single? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToSingle(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableUInt64
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        UInt64? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToUInt64(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableUInt32
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        UInt32? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToUInt32(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableUInt16
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        UInt16? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToUInt16(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableInt64
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Int64? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToInt64(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableInt32
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Int32? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToInt32(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableInt16
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Int16? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToInt16(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableSByte
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        SByte? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToSByte(str, formatProvider);
                        return result;
                    };
            }
        }

        public static Func<string, IFormatProvider, object> NullableByte
        {
            get
            {
                return (str, formatProvider) =>
                    {
                        Byte? result = null;
                        if (!System.String.IsNullOrEmpty(str)) result = Convert.ToByte(str, formatProvider);
                        return result;
                    };
            }
        }
    }
}