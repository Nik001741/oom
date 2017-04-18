using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task3
{
    [TestFixture]

    class test_Computer
    {

        [Test]
        public void simpleTest() 
        {
            var computer = new Notebooks("E751", 700, "SLN78");
            Assert.IsTrue(computer.Modell == "E751");
            Assert.IsTrue(computer.N_Preis == 700);
            Assert.IsTrue(computer.Seriennum == "SLN78");
        }

        [Test]
        public void ModellnummNotNULL()
        {
            Assert.Catch(() =>
            {
                var computer = new Notebooks(null, 700, "SLN78");
            });
        }

        [Test]
        public void N_PreisNotSmallerThanNULL()
        {
            Assert.Catch(() =>
            {
                var computer = new Notebooks("E751", -700, "SLN78");
            });
        }

        [Test]
        public void SeriennumNotNULL()
        {
            Assert.Catch(() =>
            {
                var computer = new Notebooks("E751", 700, null);
            });
        }

        [Test]
        public void SeriennumNotEmpty()
        {
            Assert.Catch(() =>
            {
                var computer = new Notebooks("E751", 700, "");
            });
        }

    }
}
