/**************************************************************************
 *                                                                        *
 *  File:        UnitTestUsers.cs                                         *
 *  Copyright:   (c) 2022, Alexandra-Catalina Poleac                      *
 *  Description: Aplicatie pentru administrare magazin de cosmetice       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyUserAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProxy
{
    [TestClass()]
    public class UnitTestUsers
    {
        [TestMethod]
        public void TestLogin_1()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(false, login.Login("", ""));

        }
        [TestMethod]
        public void TestLogin_2()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(false, login.Login("admin", ""));

        }
        [TestMethod]
        public void TestLogin_3()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(true, login.Login("admin", "admin"));

        }
        [TestMethod]
        public void TestLogin_4()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(true, login.Login("alexandra", "alexandra"));

        }
        [TestMethod]
        public void TestLogin_5()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(false, login.Login("", "emilia"));

        }
        [TestMethod]
        public void TestLogin_6()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(false, login.Login("adm3n..", "ADMIN"));

        }
        [TestMethod]
        public void TestLogin_7()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(false, login.Login("1234-1", "1234-"));

        }

        [TestMethod]
        public void TestLogin_8()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(false, login.Login("", "ADMIN"));

        }
        [TestMethod]
        public void TestLogin_9()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(true, login.Login("stefania", "STEFANIA"));

        }
        [TestMethod]
        public void TestLogin_10()
        {
            Proxy login = new Proxy();
            Assert.AreEqual(false, login.Login(".Admin", "Admin"));

        }
    }
}