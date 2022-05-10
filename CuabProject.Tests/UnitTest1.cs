using System;
using Xunit;
using CuabProjectAllocation.Core.Util;

namespace CuabProject.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Act
            var resp = helper.GenerateAlphaNumberic(10);
            Assert.NotNull(resp);
        }
    }
}
