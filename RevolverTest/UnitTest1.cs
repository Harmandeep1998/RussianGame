using Microsoft.VisualStudio.TestTools.UnitTesting;
using RussianGame;
using System;

namespace RevolverTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            Revolver revolver = new Revolver();
            revolver.LoadBullet();
            Assert.AreEqual(revolver.Fire(0), true);
        }

        [TestMethod]
        public void Test2()
        {
            Revolver revolver = new Revolver();
            revolver.LoadBullet();
            Assert.AreEqual(revolver.Fire(2), false);
        }
    }
}
