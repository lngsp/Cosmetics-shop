/**************************************************************************
 *                                                                        *
 *  File:        UnitTestProdus.cs                                        *
 *  Copyright:   (c) 2022, Alexandra-Catalina Poleac                      *
 *  Description: Aplicatie pentru administrare magazin de cosmetice       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Produse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProduse
{
    [TestClass()]
    public class UnitTestProdus
    {
        [TestMethod]
        public void TestProdus_1()
        {
            Produs produs = new Produs();
            Assert.AreEqual(1, produs.ListCount() - 3);
        }
        [TestMethod]
        public void TestProdus_2()
        {
            Produs produs = new Produs();
            Assert.AreEqual(4, produs.ListCount());
        }
        [TestMethod]
        public void TestProdus_3()
        {
            Produs produs = new Produs();
            produs.ListAll();
        }
        [TestMethod]
        public void TestProdus_4()
        {
            Produs produs = new Produs();
            produs.AddProdus("Blush");
        }
        [TestMethod]
        public void TestProdus_5()
        {
            Produs produs = new Produs();
            produs.DeleteProdus("Blush");
        }
        [TestMethod]
        public void TestProdus_6()
        {
            Produs produs = new Produs();
            produs.AddProdus("");
        }
        [TestMethod]
        public void TestProdus_7()
        {
            Produs produs = new Produs();
            produs.DeleteProdus("");
        }

        [TestMethod]
        public void TestProdus_8()
        {
            Produs produs = new Produs();
            produs.Save();
        }
        [TestMethod]
        public void TestProdus_9()
        {
            Produs produs = new Produs();
            produs.AddProdus("1234");
        }
        [TestMethod]
        public void TestProdus_10()
        {
            Produs produs = new Produs();
            produs.DeleteProdus("1234");
        }
    }
}