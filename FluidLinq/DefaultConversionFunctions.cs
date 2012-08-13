namespace FluidLinq
{
    using System;

    internal static class DefaultConversionFunctions
    {
        public static Func<string, IFormatProvider, Byte> Byte
        {
            get
            {
                return (str, formatProvider) => Convert.ToByte(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, SByte> SByte
        {
            get
            {
                return (str, formatProvider) => Convert.ToSByte(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Int16> Int16
        {
            get
            {
                return (str, formatProvider) => Convert.ToInt16(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, UInt64> UInt64
        {
            get
            {
                return (str, formatProvider) => Convert.ToUInt64(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, UInt32> UInt32
        {
            get
            {
                return (str, formatProvider) => Convert.ToUInt32(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, UInt16> UInt16
        {
            get
            {
                return (str, formatProvider) => Convert.ToUInt16(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Int64> Int64
        {
            get
            {
                return (str, formatProvider) => Convert.ToInt64(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Int32> Int32
        {
            get
            {
                return (str, formatProvider) => Convert.ToInt32(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, DateTime> DateTime
        {
            get
            {
                return (str, formatProvider) => Convert.ToDateTime(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, String> String
        {
            get
            {
                return (str, formatProvider) => str;
            }
        }

        public static Func<string, IFormatProvider, Decimal> Decimal
        {
            get
            {
                return (str, formatProvider) => Convert.ToDecimal(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Char> Char
        {
            get
            {
                return (str, formatProvider) => Convert.ToChar(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Boolean> Boolean
        {
            get
            {
                return (str, formatProvider) => Convert.ToBoolean(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Double> Double
        {
            get
            {
                return (str, formatProvider) => Convert.ToDouble(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Single> Single
        {
            get
            {
                return (str, formatProvider) => Convert.ToSingle(str, formatProvider);
            }
        }

        public static Func<string, IFormatProvider, Nullable<DateTime>> NullableDateTime
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

        public static Func<string, IFormatProvider, Nullable<Decimal>> NullableDecimal
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

        public static Func<string, IFormatProvider, Nullable<Char>> NullableChar
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

        public static Func<string, IFormatProvider, Nullable<Boolean>> NullableBoolean
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

        public static Func<string, IFormatProvider, Nullable<Double>> NullableDouble
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

        public static Func<string, IFormatProvider, Nullable<Single>> NullableSingle
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

        public static Func<string, IFormatProvider, Nullable<UInt64>> NullableUInt64
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

        public static Func<string, IFormatProvider, Nullable<UInt32>> NullableUInt32
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

        public static Func<string, IFormatProvider, Nullable<UInt16>> NullableUInt16
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

        public static Func<string, IFormatProvider, Nullable<Int64>> NullableInt64
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

        public static Func<string, IFormatProvider, Nullable<Int32>> NullableInt32
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

        public static Func<string, IFormatProvider, Nullable<Int16>> NullableInt16
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

        public static Func<string, IFormatProvider, Nullable<SByte>> NullableSByte
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

        public static Func<string, IFormatProvider, Nullable<Byte>> NullableByte
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