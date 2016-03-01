using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns;
using PatternsTests;

namespace PatternsTests
{
    [TestClass]
    public class RecursionTests
    {
        [TestMethod]
        public void create_hanoi_tower_expect_rules()
        {

            //       =1           =       =
            //      =2=           =       =
            //     ==3==          =       = 
            //    ===4===         =       =
            //   ====5====        =       =
            //=================================

            var amountOfDisks = 8;

            var tower = new HanoiTower();

            var source = new Stack<int>().AddRange(amountOfDisks);
            var destination = new Stack<int>();
            var temporary = new Stack<int>();

            tower.MoveTower(source.Count, source, destination, temporary);

            Assert.AreEqual(0, source);
            Assert.AreEqual(amountOfDisks, destination);
            Assert.AreEqual(0, temporary);
        }
    }

   
}
