using System;
using System.Reflection;
namespace Projectono.Core.Environment.TypeConversion
{
    public interface ITypeConverter
    {
        bool CanConvert(Type from, Type to);
        object Convert(object from, Type to);
    }

    public interface ITypeConverter<TFrom, TTo> : ITypeConverter
    {
        TTo Convert(TFrom from);
    }

    public abstract class TypeConverter<TFrom, TTo> : ITypeConverter<TFrom, TTo> 
    {
        private static readonly TypeInfo _from = typeof(TFrom).GetTypeInfo();
        private static readonly TypeInfo _to = typeof(TTo).GetTypeInfo();

        bool ITypeConverter.CanConvert(Type from, Type to) {
            return _from.IsAssignableFrom(from.GetTypeInfo())
                && to.GetTypeInfo().IsAssignableFrom(_to);
        }

        object ITypeConverter.Convert(object from, Type to) {
            return this.Convert((TFrom)from);
        }

        public abstract TTo Convert(TFrom from);
    }
}
