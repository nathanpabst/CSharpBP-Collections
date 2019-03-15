using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            //arrange
            var repository = new VendorRepository();
            var expected = 42;

            //act 
            var actual = repository.RetrieveValue<int>("Select...", 42);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            //arrange
            var repository = new VendorRepository();
            var expected = "test";

            //act 
            var actual = repository.RetrieveValue<string>("Select...", "test");

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueObjectTest()
        {
            //arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //act 
            var actual = repository.RetrieveValue<Vendor>("Select...", vendor);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();

            expected.Add(new Vendor()
            { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });

            expected.Add(new Vendor()
            { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });

            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveAllTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                {new Vendor()
                    { VendorId = 22, CompanyName = "Amal Toys", Email = "a@amaltoys.com" } },
                { new Vendor()
                    { VendorId = 35, CompanyName = "Car Toys", Email = "car@abc.com" } },
                { new Vendor()
                    { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocs@abc.com" } },
                { new Vendor()
                    { VendorId = 42, CompanyName = "Toys n Stuff Inc", Email = "stuff@abc.com" } }
            };

            //Act
            var vendors = repository.RetrieveAll();
            // USING QUERY SYNTAX
            //var vendorQuery = from v in vendors
            //                  where v.CompanyName.Contains("Toy")
            //                  orderby v.CompanyName
            //                  select v;
            // USING METHOD SYNTAX WITH METHOD NAMES (ie FilterCompanies & OrderCompaniesByName)
            //var vendorQuery = vendors.Where(FilterCompanies)
            //    .OrderBy(OrderCompaniesByName);

            //lambda expression = a method that can be passed as an argument to a method when that arg expects a delegate type
            //USING METHOD SYNTAX AND PASSING LAMBDA EXPRESSIONS...eliminates the private methods below
            var vendorQuery = vendors.Where(v => v.CompanyName.Contains("Toys"))
                .OrderBy(v => v.CompanyName);

            //Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }

        //delegate is a data type that represents a reference to a method with a specific parameter list and return type. 
        //delegates are used to pass methods as arguments to other methods
        //example of using a lambda expression to create a delegate
        //private bool FilterCompanies(Vendor v) =>
        //     v.CompanyName.Contains("Toys");

        //private string OrderCompaniesByName(Vendor v) => v.CompanyName;
        

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                { new Vendor()
                  { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                { new Vendor()
                  { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" }
                }
            };

            //Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }


    }
}