using TV.VOD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VODUnitTest
{
    
    
    /// <summary>
    ///This is a test class for IPTVMetadataLoaderTest and is intended
    ///to contain all IPTVMetadataLoaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IPTVMetadataLoaderTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetMetadata
        ///</summary>
        [TestMethod()]
        public void GetMetadataTest()
        {
            IPTVMetadataLoader target = new IPTVMetadataLoader(); 
            string filePath = @"..\..\test.xml";
            VodMetadata expected = new VodMetadata() { AssetId = "11111", AssetName = "test asset", ProviderId = "mine", Description = "This is a test metadata" };
            VodMetadata actual;
            actual = target.GetMetadata(filePath);
            Assert.AreEqual(expected.AssetId, actual.AssetId);
            Assert.AreEqual(expected.AssetName, actual.AssetName);
            Assert.AreEqual(expected.ProviderId, actual.ProviderId);
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}
