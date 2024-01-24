using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogLib
{
    [TestFixture]
    class NUnitTestAdminInfo
    {
        [TestCase]
        public void Email()
        {
            AdminInfo adminInfo = new AdminInfo();
            Assert.AreEqual("surya@gmail.com", "surya@gmail.com");
        }

        [TestCase]
        public void Password()
        {
            AdminInfo adminInfo = new AdminInfo();
            Assert.AreEqual("surya@25", "surya@25");
        }
    }
}
