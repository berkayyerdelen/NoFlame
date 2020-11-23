using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NoFlame.Domain.Base
{
    public abstract class SmartEnum<TEnum, TValue> : IEquatable<SmartEnum<TEnum, TValue>> where TEnum : SmartEnum<TEnum, TValue>
    {
        private static readonly Lazy<List<TEnum>> _list = new Lazy<List<TEnum>>(ListAllOptions);

        private static List<TEnum> ListAllOptions()
        {
            Type t = typeof(TEnum);
            return t.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(p => t.IsAssignableFrom(p.FieldType))
                .Select(pi => (TEnum)pi.GetValue(null))
                .OrderBy(p => p.Name)
                .ToList();
        }

        public static List<TEnum> List => _list.Value;

        public string Name { get; }

        public TValue Value { get; protected set; }

        protected SmartEnum(string name, TValue value)
        {
            Name = name;
            Value = value;
        }

        public static TEnum FromName(string name)
        {
            var result = List.FirstOrDefault(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));

            if (result == null)
            {
                throw new ArgumentException($"No {typeof(TEnum).Name} with Name \"{name}\" found.");
            }

            return result;
        }

        public static TEnum FromValue(TValue value)
        {
            var result = List.FirstOrDefault(item => EqualityComparer<TValue>.Default.Equals(item.Value, value));

            if (result == null)
            {
                throw new ArgumentException($"No {typeof(TEnum).Name} with Value {value} found.");
            }

            return result;
        }

        public static TEnum FromValue(TValue value, TEnum defaultValue)
        {
            var result = List.FirstOrDefault(item => EqualityComparer<TValue>.Default.Equals(item.Value, value));

            if (result == null)
            {
                result = defaultValue;
            }
            return result;
        }

        public override string ToString() => $"{Name} ({Value})";

        public override int GetHashCode() => new { Name, Value }.GetHashCode();

        public override bool Equals(object obj) => Equals(obj as SmartEnum<TEnum, TValue>);


        public bool Equals(SmartEnum<TEnum, TValue> other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Name == other.Name && EqualityComparer<TValue>.Default.Equals(Value, other.Value);
        }

        public static bool operator ==(SmartEnum<TEnum, TValue> left, SmartEnum<TEnum, TValue> right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(SmartEnum<TEnum, TValue> left, SmartEnum<TEnum, TValue> right) => !(left == right);


        public static implicit operator TValue(SmartEnum<TEnum, TValue> smartEnum) => smartEnum.Value;


        public static explicit operator SmartEnum<TEnum, TValue>(TValue value) => FromValue(value);
    }
}