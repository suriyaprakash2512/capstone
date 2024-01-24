using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogLib
{
    [TestFixture]
    class NUnitTestEmpInfo
    {
        [TestCase]
        public void Email()
        {
            AdminInfo adminInfo = new AdminInfo();
            Assert.AreEqual("smith@gmail.com", "smith@gmail.com");
        }

        [TestCase]
        public void PassCode()
        {
            AdminInfo adminInfo = new AdminInfo();
            Assert.AreEqual(4567, 4567);
        }
    }

}
