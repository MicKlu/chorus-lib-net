using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace ChorusLib.Tests
{

    [TestClass]
    public class OtherMethodsTest
    {
        [TestMethod]
        public async Task Count()
        {
            ChorusApi api = ChorusApi.GetInstance();
            int count = await api.Count();
            Assert.IsTrue(count >= 0, $"Expected value 0 or more, but got \"{count}\"");
        }
    }

}