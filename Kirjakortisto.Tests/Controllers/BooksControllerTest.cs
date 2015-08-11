using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kirjakortisto.Controllers;
using Kirjakortisto.Models;
using System.Web.Mvc;

namespace Kirjakortisto.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        [TestMethod]
        public void TestCreate()
        {
            var controller = new BooksController();

            var book = new Book();

            //ActionResult result = controller.Create(book);

            //Assert.

        }
    }
}
