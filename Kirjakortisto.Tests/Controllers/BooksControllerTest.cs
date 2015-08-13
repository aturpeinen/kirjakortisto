using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kirjakortisto.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Kirjakortisto.Models;
using Kirjakortisto.Repositories;
using System.Web.Mvc;

namespace Kirjakortisto.Controllers.Tests
{
    [TestClass()]
    public class BooksControllerTest
    {
        /*[TestMethod()]
        public void BooksControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BooksControllerTest1()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public void IndexTest()
        {
            Mock<IBooksRepository> mock = new Mock<IBooksRepository>();

            // Arrange
            var controller = new BooksController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        private IQueryable<Book> GetThreeBooks()
        {
            return new Book[] {
                new Book() { Id = 1, Name = "Bar", Description = "Foo", Author = "Antti" },
                new Book() { Id = 2, Name = "BarFoo", Description = "FooBar", Author = "Abc" },
                new Book() { Id = 3, Name = "123", Description = "456", Author = "789" },
            }.AsQueryable();
        }

        [TestMethod()]
        public void IndexJSONTest()
        {
            Mock<IBooksRepository> mock = new Mock<IBooksRepository>();

            // Add three books to repository
            mock.Setup(m => m.Books).Returns(GetThreeBooks().AsQueryable());

            // BooksController's IndexJSON should return all the books
            var controller = new BooksController(mock.Object);
            var result = controller.IndexJSON();

            // Make sure that it returned two books
            Assert.IsNotNull(result);
            dynamic books = result.Data;
            Assert.AreEqual(books[0].Name, "Bar");
            Assert.AreEqual(books[1].Description, "FooBar");
            Assert.AreEqual(books[2].Author, "789");
            Assert.AreEqual(books.Count, 3);
        }

        
        [TestMethod()]
        public void DetailsTest()
        {
            Mock<IBooksRepository> mock = new Mock<IBooksRepository>();

            // Add three books to repository
            mock.Setup(m => m.Books).Returns(GetThreeBooks());
            mock.Setup(m => m.GetById(It.IsAny<int>())).Returns((int i) => GetThreeBooks().Where(x => x.Id == i).Single());

            // Arrange
            var controller = new BooksController(mock.Object);

            // Act
            ViewResult result = controller.Details(2) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Book));
            Book book = result.Model as Book;

            Assert.AreEqual(book.Name, "BarFoo");
        }


        /*
        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }*/
    }
}