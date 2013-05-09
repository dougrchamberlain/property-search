using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search.Data.Services;
using Search.Controllers;
using Moq; 
using Search.Html.ViewModels;
using System.Web.Mvc;
using System.Collections.Generic;
using Search.Data.Models;
using System.Linq;



namespace TestSearch
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void AsStrapFormatsStrapValueCorrectly()
        {
            Assert.AreEqual("0001020003", "0/()001-02|0003".AsStrap()); 
            //
            // TODO: Add test logic here
            //
        }

       

        [TestMethod]
        public void GetPropertiesOnlyReturnsOneDistinctSTRAP()
        {
            List<Search.Data.Models.Parcel> properties = new List<Search.Data.Models.Parcel>();
 
            properties.Add(new Parcel{ STRAP="0001020003"});
            properties.Add(new Parcel{ STRAP="0001020003"});
            properties.Add(new Parcel{ STRAP="0001020003"});
            properties.Add(new Parcel{ STRAP="0001020003"});
            properties.Add(new Parcel{ STRAP="0001020005"});


            var Mock = new Mock<ICamaService>();

            Mock.Setup(c=>c.GetParcels()).Returns(properties.AsQueryable);   

            var controller = new ParcelController(Mock.Object);
            var search = new BasicSearchViewModel{ STRAP="0001-02-0003"} ;


            var viewresults = (List<ResultsListItemViewModel>)controller.Results(search).Model;

            Assert.AreEqual(1, viewresults.Count);

            

        }
    }
}
