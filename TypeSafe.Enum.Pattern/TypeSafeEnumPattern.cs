using System;

namespace TypeSafe.Enum.Pattern
{
    public abstract class TypeSafeEnumPattern : IComparable
    {
        private readonly int _id;
        private readonly string _name;

        public int Id { get => _id; }
        public string Name { get => _name; }

        protected TypeSafeEnumPattern(int id, string name)
        {
            _id = id;
            _name = name;
        }

        #region IComparable
        public int CompareTo(object otherEnum)
        {
            return _id.CompareTo(((TypeSafeEnumPattern)otherEnum).Id);
        }
        #endregion

        #region Override default virtual object methods
        public override bool Equals(object objct)
        {
            var otherEnum = objct as TypeSafeEnumPattern;

            if (otherEnum == null)
                return false;

            var typeMatches = GetType().Equals(objct.GetType());
            var valueMatches = _id.Equals(otherEnum.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id, _name);
        }
        #endregion

        #region Override operators
        public static bool operator ==(TypeSafeEnumPattern typeSafeEnumPattern_1, TypeSafeEnumPattern typeSafeEnumPattern_2)
        {
            if (ReferenceEquals(typeSafeEnumPattern_1, null))
            {
                return ReferenceEquals(typeSafeEnumPattern_2, null);
            }
            return typeSafeEnumPattern_1.Equals(typeSafeEnumPattern_2);
        }

        public static bool operator !=(TypeSafeEnumPattern typeSafeEnumPattern_1, TypeSafeEnumPattern typeSafeEnumPattern_2)
        {
            if (ReferenceEquals(typeSafeEnumPattern_1, null))
            {
                return ReferenceEquals(typeSafeEnumPattern_2, null);
            }
            return !typeSafeEnumPattern_1.Equals(typeSafeEnumPattern_2);
        }
        #endregion
    }
}
