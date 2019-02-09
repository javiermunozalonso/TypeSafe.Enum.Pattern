using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TypeSafe.Enums;

namespace TypeSafe.Enum.Pattern.Test
{
    [TestClass]
    public class StateTaskSafeEnumUnitTest
    {
        readonly List<StateTaskSafeEnum> _stateTasks = StateTaskSafeEnum.GetAllEnum();

        [TestMethod]
        public void Using_GetAllEnum_should_return_all_objects()
        {
            Assert.IsTrue(_stateTasks.Count == 3);
            Assert.IsTrue(_stateTasks.Contains(StateTaskSafeEnum.Init));
            Assert.IsTrue(_stateTasks.Contains(StateTaskSafeEnum.Closed));
            Assert.IsTrue(_stateTasks.Contains(StateTaskSafeEnum.InProgress));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Try_get_a_StateTask_out_of_range_should_return_null()
        {
            var nonExistingStateTask = (StateTaskSafeEnum)10;
        }

        [TestMethod]
        public void Try_get_a_StateTask_on_range_should_return_the_state()
        {
            var stateTaskSafeEnumInit = (StateTaskSafeEnum)1;
            Assert.IsTrue(stateTaskSafeEnumInit.Id == StateTaskSafeEnum.Init.Id);
            Assert.IsTrue(stateTaskSafeEnumInit.Name == StateTaskSafeEnum.Init.Name);
        }
    }
}
