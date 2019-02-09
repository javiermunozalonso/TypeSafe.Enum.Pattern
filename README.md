# Enum Type Safe Pattern in C#

An alternative implementation for _System.Enum_. Simple and strong.

This is a simple enum named ```ASimpleEnum```

``` csharp
    public enum ASimpleEnum
    {
        Init = 0,
        InProgress = 1,
        Closed = 2
    }
```

This is VERY simple:

- No business logic
- No names without any transformation

This is my proposal to extends the functionality of an enum:

``` csharp
    public abstract class TypeSafeEnumPattern
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
    }
```

This a core functionality with an ```Id``` like an identifier and a ```name``` like a name of the nre enum.

By default, the setter of ```Id``` and ```name``` is readonly and private on the constructor to make them only settable on the build of the object and unmutable to the beyond.

This is the core of the pattern but we can extend it to make more usable, i choose the ```IComparable``` interface to make comparable the differents objects that implements this abstract class.

``` csharp
    public int CompareTo(object otherEnum)
    {
        return Id.CompareTo(((TypeSafeEnumPattern)otherEnum).Id);
    }
```

I also implement ```Equals(object)``` and ```GetHashCode()``` to make more strong comparing objects.

``` csharp
        public override bool Equals(object objct)
        {
            var otherTypeSafeEnumPattern = objct as TypeSafeEnumPattern;

            if (otherTypeSafeEnumPattern == null)
                return false;

            var typeMatches = GetType().Equals(objct.GetType());
            var valueMatches = _id.Equals(otherTypeSafeEnumPattern.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id, _name);
        }
```

Finally, to get more standar, i override comparer operators to make more fit to the code

``` csharp
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
```

With all of this code we've got this full abstract class

``` csharp
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
```

To 