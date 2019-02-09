using System;
using System.Collections.Generic;
using System.Linq;
using TypeSafe.Enum.Pattern;

namespace TypeSafe.Enums
{
    public sealed class StateTaskSafeEnum : TypeSafeEnumPattern
    {
        private StateTaskSafeEnum(int id, string name) : base(id: id, name: name)
        { }
        public static readonly StateTaskSafeEnum Init = new StateTaskSafeEnum(id: 1, name: nameof(Init));
        public static readonly StateTaskSafeEnum InProgress = new StateTaskSafeEnum(id: 2, name: nameof(InProgress));
        public static readonly StateTaskSafeEnum Closed = new StateTaskSafeEnum(id: 3, name: nameof(Closed));

        private static readonly List<StateTaskSafeEnum> _AllStateTaskSafeEnum = new List<StateTaskSafeEnum> { Init, InProgress, Closed };

        public static List<StateTaskSafeEnum> GetAllEnum()
        {
            return _AllStateTaskSafeEnum;
        }

        public static explicit operator StateTaskSafeEnum(int id)
        {
            if (!_AllStateTaskSafeEnum.Any(x => x.Id == id))
                throw new ArgumentOutOfRangeException();
            return _AllStateTaskSafeEnum.Single(x => x.Id == id);
        }
    }
}
