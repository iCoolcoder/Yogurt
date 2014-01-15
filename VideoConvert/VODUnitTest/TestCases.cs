using System.Linq;
using System.Runtime.Remoting;
using System.ServiceModel.Security;
using TV.DAL;
using TV.VOD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VODEntities = VODUnitTest.TV.VOD.VODEntities;
using Asset = VODUnitTest.TV.VOD.Asset;

namespace VODUnitTest
{
    
    
    /// <summary>
    ///This is a test class for IPTVMetadataLoaderTest and is intended
    ///to contain all IPTVMetadataLoaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TestCases
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

        /// <summary>
        ///DB test
        ///</summary>
        [TestMethod()]
        public void GetDataFromDB()
        {
            const string ServiceUri = "http://localhost.:60985/Vod.svc";

            // Retrieve via direct SQL:
            var ctx = new VODEntities(new Uri(ServiceUri));

            // via LINQ
            var q = from asset in ctx.Assets
                select asset;

            // exectue 
            var list = q.ToList();
            list[0].AssetId = "1111111";

            var firstAsset = new Asset() { AssetId = "11111", AssetName = "test asset", ProviderId = "mine", Description = "This is a test metadata" };
            //ctx.AddToAssets(firstAsset);
            ctx.UpdateObject(list[0]);
            

            // Issue an HTTP MERGE to update asset table
            ctx.SaveChanges();

        }

        /// <summary>
        ///DB test
        ///</summary>
        [TestMethod()]
        public void InsertDataToDB()
        {
            const string ServiceUri = "http://localhost.:60985/Vod.svc";
            string EntitySql =
                @"INSERT INTO vod.dbo.Asset (AssetId, AssetName, Description, ProviderId) VALUES (@AssetId, @AssetName, @Des, @ProviderId)";
            string EntitySql1 =
                @"INSERT INTO vod.dbo.Asset (AssetId, AssetName, Description, ProviderId) VALUES ('AssetId', 'AssetName', 'Des', 'ProviderId')";

            var firstAsset = new Asset() { AssetId = "11111", AssetName = "test asset", ProviderId = "mine", Description = "This is a test metadata" };
            EntitySql.Replace(@"@AssetId", firstAsset.AssetId);
            EntitySql.Replace(@"@AssetName", firstAsset.AssetName);
            EntitySql.Replace(@"@Des", firstAsset.Description);
            EntitySql.Replace(@"@ProviderId", firstAsset.ProviderId);

            // Retrieve via direct SQL:
            var ctx = new VODEntities(new Uri(ServiceUri));

            var q = ctx.CreateQuery<Asset>(EntitySql1);

            // Issue an HTTP MERGE to update asset table
            var list = q.ToList();

        }
    }
}
