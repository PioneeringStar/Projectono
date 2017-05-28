using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Projectono.Environment;

namespace Projectono.Core.Environment.TypeConversion
{
    [Dependency.Transient]
    public class RootConverters : ITypeConverter,
            ITypeConverter<bool, bool>,
            ITypeConverter<sbyte, bool>,
            ITypeConverter<byte, bool>,
            ITypeConverter<char, bool>,
            ITypeConverter<ushort, bool>,
            ITypeConverter<short, bool>,
            ITypeConverter<uint, bool>,
            ITypeConverter<int, bool>,
            ITypeConverter<ulong, bool>,
            ITypeConverter<long, bool>,
            ITypeConverter<float, bool>,
            ITypeConverter<double, bool>,
            ITypeConverter<decimal, bool>,
            ITypeConverter<string, bool>,

            ITypeConverter<bool, sbyte>,
            ITypeConverter<sbyte, sbyte>,
            ITypeConverter<byte, sbyte>,
            ITypeConverter<char, sbyte>,
            ITypeConverter<ushort, sbyte>,
            ITypeConverter<short, sbyte>,
            ITypeConverter<uint, sbyte>,
            ITypeConverter<int, sbyte>,
            ITypeConverter<ulong, sbyte>,
            ITypeConverter<long, sbyte>,
            ITypeConverter<float, sbyte>,
            ITypeConverter<double, sbyte>,
            ITypeConverter<decimal, sbyte>,
            ITypeConverter<string, sbyte>,

            ITypeConverter<bool, byte>,
            ITypeConverter<sbyte, byte>,
            ITypeConverter<byte, byte>,
            ITypeConverter<char, byte>,
            ITypeConverter<ushort, byte>,
            ITypeConverter<short, byte>,
            ITypeConverter<uint, byte>,
            ITypeConverter<int, byte>,
            ITypeConverter<ulong, byte>,
            ITypeConverter<long, byte>,
            ITypeConverter<float, byte>,
            ITypeConverter<double, byte>,
            ITypeConverter<decimal, byte>,
            ITypeConverter<string, byte>,

            ITypeConverter<bool, char>,
            ITypeConverter<sbyte, char>,
            ITypeConverter<byte, char>,
            ITypeConverter<char, char>,
            ITypeConverter<ushort, char>,
            ITypeConverter<short, char>,
            ITypeConverter<uint, char>,
            ITypeConverter<int, char>,
            ITypeConverter<ulong, char>,
            ITypeConverter<long, char>,
            ITypeConverter<float, char>,
            ITypeConverter<double, char>,
            ITypeConverter<decimal, char>,
            ITypeConverter<string, char>,

            ITypeConverter<bool, ushort>,
            ITypeConverter<sbyte, ushort>,
            ITypeConverter<byte, ushort>,
            ITypeConverter<char, ushort>,
            ITypeConverter<ushort, ushort>,
            ITypeConverter<short, ushort>,
            ITypeConverter<uint, ushort>,
            ITypeConverter<int, ushort>,
            ITypeConverter<ulong, ushort>,
            ITypeConverter<long, ushort>,
            ITypeConverter<float, ushort>,
            ITypeConverter<double, ushort>,
            ITypeConverter<decimal, ushort>,
            ITypeConverter<string, ushort>,

            ITypeConverter<bool, short>,
            ITypeConverter<sbyte, short>,
            ITypeConverter<byte, short>,
            ITypeConverter<char, short>,
            ITypeConverter<ushort, short>,
            ITypeConverter<short, short>,
            ITypeConverter<uint, short>,
            ITypeConverter<int, short>,
            ITypeConverter<ulong, short>,
            ITypeConverter<long, short>,
            ITypeConverter<float, short>,
            ITypeConverter<double, short>,
            ITypeConverter<decimal, short>,
            ITypeConverter<string, short>,

            ITypeConverter<bool, uint>,
            ITypeConverter<sbyte, uint>,
            ITypeConverter<byte, uint>,
            ITypeConverter<char, uint>,
            ITypeConverter<ushort, uint>,
            ITypeConverter<short, uint>,
            ITypeConverter<uint, uint>,
            ITypeConverter<int, uint>,
            ITypeConverter<ulong, uint>,
            ITypeConverter<long, uint>,
            ITypeConverter<float, uint>,
            ITypeConverter<double, uint>,
            ITypeConverter<decimal, uint>,
            ITypeConverter<string, uint>,

            ITypeConverter<bool, int>,
            ITypeConverter<sbyte, int>,
            ITypeConverter<byte, int>,
            ITypeConverter<char, int>,
            ITypeConverter<ushort, int>,
            ITypeConverter<short, int>,
            ITypeConverter<uint, int>,
            ITypeConverter<int, int>,
            ITypeConverter<ulong, int>,
            ITypeConverter<long, int>,
            ITypeConverter<float, int>,
            ITypeConverter<double, int>,
            ITypeConverter<decimal, int>,
            ITypeConverter<string, int>,

            ITypeConverter<bool, ulong>,
            ITypeConverter<sbyte, ulong>,
            ITypeConverter<byte, ulong>,
            ITypeConverter<char, ulong>,
            ITypeConverter<ushort, ulong>,
            ITypeConverter<short, ulong>,
            ITypeConverter<uint, ulong>,
            ITypeConverter<int, ulong>,
            ITypeConverter<ulong, ulong>,
            ITypeConverter<long, ulong>,
            ITypeConverter<float, ulong>,
            ITypeConverter<double, ulong>,
            ITypeConverter<decimal, ulong>,
            ITypeConverter<string, ulong>,

            ITypeConverter<bool, long>,
            ITypeConverter<sbyte, long>,
            ITypeConverter<byte, long>,
            ITypeConverter<char, long>,
            ITypeConverter<ushort, long>,
            ITypeConverter<short, long>,
            ITypeConverter<uint, long>,
            ITypeConverter<int, long>,
            ITypeConverter<ulong, long>,
            ITypeConverter<long, long>,
            ITypeConverter<float, long>,
            ITypeConverter<double, long>,
            ITypeConverter<decimal, long>,
            ITypeConverter<string, long>,

            ITypeConverter<bool, float>,
            ITypeConverter<sbyte, float>,
            ITypeConverter<byte, float>,
            ITypeConverter<char, float>,
            ITypeConverter<ushort, float>,
            ITypeConverter<short, float>,
            ITypeConverter<uint, float>,
            ITypeConverter<int, float>,
            ITypeConverter<ulong, float>,
            ITypeConverter<long, float>,
            ITypeConverter<float, float>,
            ITypeConverter<double, float>,
            ITypeConverter<decimal, float>,
            ITypeConverter<string, float>,

            ITypeConverter<bool, double>,
            ITypeConverter<sbyte, double>,
            ITypeConverter<byte, double>,
            ITypeConverter<char, double>,
            ITypeConverter<ushort, double>,
            ITypeConverter<short, double>,
            ITypeConverter<uint, double>,
            ITypeConverter<int, double>,
            ITypeConverter<ulong, double>,
            ITypeConverter<long, double>,
            ITypeConverter<float, double>,
            ITypeConverter<double, double>,
            ITypeConverter<decimal, double>,
            ITypeConverter<string, double>,

            ITypeConverter<bool, decimal>,
            ITypeConverter<sbyte, decimal>,
            ITypeConverter<byte, decimal>,
            ITypeConverter<char, decimal>,
            ITypeConverter<ushort, decimal>,
            ITypeConverter<short, decimal>,
            ITypeConverter<uint, decimal>,
            ITypeConverter<int, decimal>,
            ITypeConverter<ulong, decimal>,
            ITypeConverter<long, decimal>,
            ITypeConverter<float, decimal>,
            ITypeConverter<double, decimal>,
            ITypeConverter<decimal, decimal>,
            ITypeConverter<string, decimal>,

            ITypeConverter<bool, string>,
            ITypeConverter<sbyte, string>,
            ITypeConverter<byte, string>,
            ITypeConverter<char, string>,
            ITypeConverter<ushort, string>,
            ITypeConverter<short, string>,
            ITypeConverter<uint, string>,
            ITypeConverter<int, string>,
            ITypeConverter<ulong, string>,
            ITypeConverter<long, string>,
            ITypeConverter<float, string>,
            ITypeConverter<double, string>,
            ITypeConverter<decimal, string>,
            ITypeConverter<string, string>

    {
        private static readonly Dictionary<Type, Dictionary<Type, Func<RootConverters, object, object>>> ReflectedConverters;

        static RootConverters() {
            var basetype = typeof(ITypeConverter<object, object>).GetGenericTypeDefinition();
            var ifaces = typeof(RootConverters)
                .GetTypeInfo()
                .ImplementedInterfaces
                .Where(iface => iface.GetGenericTypeDefinition() == basetype);
            var byfrom = ifaces
                .GroupBy(iface => iface.GenericTypeArguments[0])
                .ToDictionary(g => g.Key);
            var byto = byfrom
                .ToDictionary(
                    f => f.Key,
                    f => f.Value
                    .ToDictionary(iface => iface.GenericTypeArguments[1])
                 );
            ReflectedConverters = byto
                .ToDictionary(
                    f => f.Key,
                    f => f.Value
                    .ToDictionary(
                        t => t.Key,
                        t => {
                            var method = t.Key.GetTypeInfo().GetDeclaredMethod("Convert");
                            return new Func<RootConverters, object, object>((instance, value) => method.Invoke(instance, new object[] { value }));
                        })
                );
        }

        public bool CanConvert(Type from, Type to)
        {
            return ReflectedConverters.ContainsKey(from)
                && ReflectedConverters[from.GetType()].ContainsKey(to);
        }

        public object Convert(object from, Type to)
        {
            return ReflectedConverters[from.GetType()][to](this, from);
        }

        bool ITypeConverter<bool, bool>.Convert(bool from)
        {
            return from;
        }

        bool ITypeConverter<sbyte, bool>.Convert(sbyte from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<byte, bool>.Convert(byte from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<char, bool>.Convert(char from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<ushort, bool>.Convert(ushort from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<short, bool>.Convert(short from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<uint, bool>.Convert(uint from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<int, bool>.Convert(int from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<ulong, bool>.Convert(ulong from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<long, bool>.Convert(long from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<float, bool>.Convert(float from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<double, bool>.Convert(double from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<decimal, bool>.Convert(decimal from)
        {
            return System.Convert.ToBoolean(from);
        }

        bool ITypeConverter<string, bool>.Convert(string from)
        {
            return System.Convert.ToBoolean(from);
        }

        sbyte ITypeConverter<bool, sbyte>.Convert(bool from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<sbyte, sbyte>.Convert(sbyte from)
        {
            return from;
        }

        sbyte ITypeConverter<byte, sbyte>.Convert(byte from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<char, sbyte>.Convert(char from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<ushort, sbyte>.Convert(ushort from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<short, sbyte>.Convert(short from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<uint, sbyte>.Convert(uint from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<int, sbyte>.Convert(int from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<ulong, sbyte>.Convert(ulong from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<long, sbyte>.Convert(long from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<float, sbyte>.Convert(float from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<double, sbyte>.Convert(double from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<decimal, sbyte>.Convert(decimal from)
        {
            return System.Convert.ToSByte(from);
        }

        sbyte ITypeConverter<string, sbyte>.Convert(string from)
        {
            return System.Convert.ToSByte(from);
        }

        byte ITypeConverter<bool, byte>.Convert(bool from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<sbyte, byte>.Convert(sbyte from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<byte, byte>.Convert(byte from)
        {
            return from;
        }

        byte ITypeConverter<char, byte>.Convert(char from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<ushort, byte>.Convert(ushort from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<short, byte>.Convert(short from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<uint, byte>.Convert(uint from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<int, byte>.Convert(int from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<ulong, byte>.Convert(ulong from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<long, byte>.Convert(long from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<float, byte>.Convert(float from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<double, byte>.Convert(double from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<decimal, byte>.Convert(decimal from)
        {
            return System.Convert.ToByte(from);
        }

        byte ITypeConverter<string, byte>.Convert(string from)
        {
            return System.Convert.ToByte(from);
        }

        char ITypeConverter<bool, char>.Convert(bool from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<sbyte, char>.Convert(sbyte from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<byte, char>.Convert(byte from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<char, char>.Convert(char from)
        {
			return from;
        }

        char ITypeConverter<ushort, char>.Convert(ushort from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<short, char>.Convert(short from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<uint, char>.Convert(uint from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<int, char>.Convert(int from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<ulong, char>.Convert(ulong from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<long, char>.Convert(long from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<float, char>.Convert(float from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<double, char>.Convert(double from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<decimal, char>.Convert(decimal from)
        {
            return System.Convert.ToChar(from);
        }

        char ITypeConverter<string, char>.Convert(string from)
        {
            return System.Convert.ToChar(from);
        }

        ushort ITypeConverter<bool, ushort>.Convert(bool from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<sbyte, ushort>.Convert(sbyte from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<byte, ushort>.Convert(byte from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<char, ushort>.Convert(char from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<ushort, ushort>.Convert(ushort from)
        {
			return from;
        }

        ushort ITypeConverter<short, ushort>.Convert(short from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<uint, ushort>.Convert(uint from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<int, ushort>.Convert(int from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<ulong, ushort>.Convert(ulong from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<long, ushort>.Convert(long from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<float, ushort>.Convert(float from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<double, ushort>.Convert(double from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<decimal, ushort>.Convert(decimal from)
        {
            return System.Convert.ToUInt16(from);
        }

        ushort ITypeConverter<string, ushort>.Convert(string from)
        {
            return System.Convert.ToUInt16(from);
        }

        short ITypeConverter<bool, short>.Convert(bool from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<sbyte, short>.Convert(sbyte from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<byte, short>.Convert(byte from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<char, short>.Convert(char from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<ushort, short>.Convert(ushort from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<short, short>.Convert(short from)
        {
			return from;
        }

        short ITypeConverter<uint, short>.Convert(uint from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<int, short>.Convert(int from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<ulong, short>.Convert(ulong from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<long, short>.Convert(long from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<float, short>.Convert(float from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<double, short>.Convert(double from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<decimal, short>.Convert(decimal from)
        {
            return System.Convert.ToInt16(from);
        }

        short ITypeConverter<string, short>.Convert(string from)
        {
            return System.Convert.ToInt16(from);
        }

        uint ITypeConverter<bool, uint>.Convert(bool from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<sbyte, uint>.Convert(sbyte from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<byte, uint>.Convert(byte from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<char, uint>.Convert(char from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<ushort, uint>.Convert(ushort from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<short, uint>.Convert(short from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<uint, uint>.Convert(uint from)
        {
			return from;
        }

        uint ITypeConverter<int, uint>.Convert(int from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<ulong, uint>.Convert(ulong from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<long, uint>.Convert(long from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<float, uint>.Convert(float from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<double, uint>.Convert(double from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<decimal, uint>.Convert(decimal from)
        {
            return System.Convert.ToUInt32(from);
        }

        uint ITypeConverter<string, uint>.Convert(string from)
        {
            return System.Convert.ToUInt32(from);
        }

        int ITypeConverter<bool, int>.Convert(bool from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<sbyte, int>.Convert(sbyte from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<byte, int>.Convert(byte from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<char, int>.Convert(char from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<ushort, int>.Convert(ushort from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<short, int>.Convert(short from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<uint, int>.Convert(uint from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<int, int>.Convert(int from)
        {
			return from;
        }

        int ITypeConverter<ulong, int>.Convert(ulong from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<long, int>.Convert(long from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<float, int>.Convert(float from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<double, int>.Convert(double from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<decimal, int>.Convert(decimal from)
        {
            return System.Convert.ToInt32(from);
        }

        int ITypeConverter<string, int>.Convert(string from)
        {
            return System.Convert.ToInt32(from);
        }

        ulong ITypeConverter<bool, ulong>.Convert(bool from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<sbyte, ulong>.Convert(sbyte from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<byte, ulong>.Convert(byte from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<char, ulong>.Convert(char from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<ushort, ulong>.Convert(ushort from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<short, ulong>.Convert(short from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<uint, ulong>.Convert(uint from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<int, ulong>.Convert(int from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<ulong, ulong>.Convert(ulong from)
        {
			return from;
        }

        ulong ITypeConverter<long, ulong>.Convert(long from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<float, ulong>.Convert(float from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<double, ulong>.Convert(double from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<decimal, ulong>.Convert(decimal from)
        {
            return System.Convert.ToUInt64(from);
        }

        ulong ITypeConverter<string, ulong>.Convert(string from)
        {
            return System.Convert.ToUInt64(from);
        }

        long ITypeConverter<bool, long>.Convert(bool from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<sbyte, long>.Convert(sbyte from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<byte, long>.Convert(byte from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<char, long>.Convert(char from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<ushort, long>.Convert(ushort from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<short, long>.Convert(short from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<uint, long>.Convert(uint from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<int, long>.Convert(int from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<ulong, long>.Convert(ulong from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<long, long>.Convert(long from)
        {
			return from;
        }

        long ITypeConverter<float, long>.Convert(float from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<double, long>.Convert(double from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<decimal, long>.Convert(decimal from)
        {
            return System.Convert.ToInt64(from);
        }

        long ITypeConverter<string, long>.Convert(string from)
        {
            return System.Convert.ToInt64(from);
        }

        float ITypeConverter<bool, float>.Convert(bool from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<sbyte, float>.Convert(sbyte from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<byte, float>.Convert(byte from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<char, float>.Convert(char from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<ushort, float>.Convert(ushort from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<short, float>.Convert(short from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<uint, float>.Convert(uint from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<int, float>.Convert(int from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<ulong, float>.Convert(ulong from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<long, float>.Convert(long from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<float, float>.Convert(float from)
        {
			return from;
        }

        float ITypeConverter<double, float>.Convert(double from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<decimal, float>.Convert(decimal from)
        {
            return System.Convert.ToSingle(from);
        }

        float ITypeConverter<string, float>.Convert(string from)
        {
            return System.Convert.ToSingle(from);
        }

        double ITypeConverter<bool, double>.Convert(bool from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<sbyte, double>.Convert(sbyte from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<byte, double>.Convert(byte from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<char, double>.Convert(char from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<ushort, double>.Convert(ushort from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<short, double>.Convert(short from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<uint, double>.Convert(uint from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<int, double>.Convert(int from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<ulong, double>.Convert(ulong from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<long, double>.Convert(long from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<float, double>.Convert(float from)
        {
            return from;
        }

        double ITypeConverter<double, double>.Convert(double from)
        {
			return from;
        }

        double ITypeConverter<decimal, double>.Convert(decimal from)
        {
            return System.Convert.ToDouble(from);
        }

        double ITypeConverter<string, double>.Convert(string from)
        {
            return System.Convert.ToDouble(from);
        }

        decimal ITypeConverter<bool, decimal>.Convert(bool from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<sbyte, decimal>.Convert(sbyte from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<byte, decimal>.Convert(byte from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<char, decimal>.Convert(char from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<ushort, decimal>.Convert(ushort from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<short, decimal>.Convert(short from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<uint, decimal>.Convert(uint from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<int, decimal>.Convert(int from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<ulong, decimal>.Convert(ulong from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<long, decimal>.Convert(long from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<float, decimal>.Convert(float from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<double, decimal>.Convert(double from)
        {
            return System.Convert.ToDecimal(from);
        }

        decimal ITypeConverter<decimal, decimal>.Convert(decimal from)
        {
			return from;
        }

        decimal ITypeConverter<string, decimal>.Convert(string from)
        {
            return System.Convert.ToDecimal(from);
        }

        string ITypeConverter<bool, string>.Convert(bool from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<sbyte, string>.Convert(sbyte from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<byte, string>.Convert(byte from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<char, string>.Convert(char from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<ushort, string>.Convert(ushort from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<short, string>.Convert(short from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<uint, string>.Convert(uint from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<int, string>.Convert(int from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<ulong, string>.Convert(ulong from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<long, string>.Convert(long from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<float, string>.Convert(float from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<double, string>.Convert(double from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<decimal, string>.Convert(decimal from)
        {
            return System.Convert.ToString(from);
        }

        string ITypeConverter<string, string>.Convert(string from)
        {
			return from;
        }
    }
}
