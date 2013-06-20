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

        /// <summary>
        /// Test constructor
        /// </summary>
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

        /// <summary>
        /// Test global counter
        /// </summary>
        [TestMethod]
        public void TestCount()
        {
            int instance_count;
            instance_count = Para.count;

            Para obj = new Para();
            Assert.AreEqual(instance_count+1, Para.count);

            obj = null;
            Assert.AreEqual(instance_count, Para.count);
        }

        /// <summary>
        /// Test default settings
        /// </summary>
        [TestMethod]
        public void TestProperyColumns1()
        {
            Assert.AreEqual(para.columns, 72);
        }

        /// <summary>
        /// Test constructor initialization
        /// </summary>
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

        /// <summary>
        /// Test empty and regular string formastting, and white space handling
        /// </summary>
        [TestMethod]
        public void TestMethodFormat1()
        {
            const int new_value = 8;
            Para para = new Para(new_value);

            // empty string formatted correctly
            Assert.AreEqual("", para.format(""));

            // short line formatted correctly
            Assert.AreEqual("one two", para.format("one two"));

            // leading space was stripped
            Assert.AreEqual("one", para.format(" one"));

            // trailing space was stripped too
            Assert.AreEqual("one", para.format(" one "));

            // extra internal whitespace handled correctly
            Assert.AreEqual("one two", para.format("one   two"));
        }

        /// <summary>
        /// Test word wrapping and some edge cases
        /// </summary>
        [TestMethod]
        public void TestMethodFormat2()
        {
            const int new_value = 8;
            Para para = new Para(new_value);

            //  third word was wrapped correctly
            Assert.AreEqual("one two\nthree", para.format("one two three"));

            // packing to exactly the end of the line worked
            Assert.AreEqual("one two\nthree go", para.format("one two three go"));

            // packing to just past the end of the line worked
            Assert.AreEqual("one two\nthree\ngo!", para.format("one two three go!"));
        }

        /// <summary>
        /// Test multiple paragraph formatting
        /// </summary>
        [TestMethod]
        public void TestMethodFormat3()
        {
            const int new_value = 8;
            Para para = new Para(new_value);

            // long word was broken correctly
            Assert.AreEqual("one two\nthree\nfourfiv-\nesix", para.format("one two three fourfivesix"));

            // paragraphs handled correctly
            Assert.AreEqual("one two\nthree\n\nfour\nfive six", para.format("one two three\n\nfour five six"));

            // whitespace between paragraphs handled correctly
            Assert.AreEqual("one two\nthree\n\nfour\nfive six", para.format("one two\n three\n \nfour five six"));
        }

    }
}