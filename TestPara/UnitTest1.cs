using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParaNamespace;

namespace TestPara
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private Para para;

        public UnitTest1()
        {
            para = new Para();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestProperyColumns1()
        {
            Assert.AreEqual(para.columns, 72);
        }

        [TestMethod]
        public void TestProperyColumns2()
        {
            const int initial_value = 8;
            const int new_value = 10;

            Para para = new Para(initial_value);
            Assert.AreEqual(para.columns, initial_value);

            para = new Para(new_value);
            Assert.AreEqual(para.columns, new_value);

        }

        [TestMethod]
        public void TestMethodFormat1()
        {
            const int new_value = 8;
            Para para = new Para(new_value);
            String expected = "";
            String actual = para.format("");
            Assert.AreEqual(expected, actual);

            Assert.AreEqual("one", para.format(" one"));    // truncate leading space...
            Assert.AreEqual("one", para.format(" one "));   // and the rest...
            Assert.AreEqual("one two", para.format("one   two"));
        }

    }
}
