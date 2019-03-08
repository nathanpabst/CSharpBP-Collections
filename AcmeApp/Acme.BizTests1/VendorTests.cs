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
    public class VendorTests
    {
        [TestMethod()]
        public void SendEmailTest()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Corp",
            };
            //cast operation giving us the 'list' collection type
            var vendors = vendorsCollection.ToList();
            Console.WriteLine(vendors.Count);

            //Act
            var actual = Vendor.SendEmail(vendors, "Test message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestDictionary()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            //renaming the variable to better reflect what it does
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Corp",
            };
            //using a cast operation to cast the result to our desired collection type of 'dictionary' and using companyName as the value
            var vendors = vendorsCollection.ToDictionary(v => v.CompanyName);

            //Act
            var actual = Vendor.SendEmail(vendors.Values, "Test message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestArray()
        {
            //Arrange
            //updating the variable name to better reflect what it is
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Corp",
            };
            //cast operation ToArray to cast the result to our desired collection type 'array'
            var vendors = vendorsCollection.ToArray();
            Console.WriteLine(vendors.Length);

            //Act
            var actual = Vendor.SendEmail(vendors, "Test message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}