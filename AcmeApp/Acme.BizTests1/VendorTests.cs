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
            //creating an instance of the VendorRepository
            var vendorRepository = new VendorRepository();
            //calling the Retrieve method to retrieve the vendors
            var vendorsCollection = vendorRepository.Retrieve();
            //define the expected result...2 messages 
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Corp",
            };
            //casting as a dictionary using companyName as the value
            var vendors = vendorsCollection.ToDictionary(v => v.CompanyName);

            //Act
            //this code cannot convert the dictionary to a list of vendors. need to change code in the vendor class from List to ICollection

            var actual = Vendor.SendEmail(vendors.Values, "Test message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestArray()
        {
            //Arrange
            //creating an instance of the VendorRepository
            var vendorRepository = new VendorRepository();
            //calling the Retrieve method to retrieve the vendors
            var vendorsCollection = vendorRepository.Retrieve();
            //define the expected result...2 messages 
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Corp",
            };
            //casting as an array using the ToArray method
            var vendors = vendorsCollection.ToArray();
            Console.WriteLine(vendors.Length);

            //Act
            //this code cannot convert the array to a list of vendors. need to change code in the vendor class from List to IList
            var actual = Vendor.SendEmail(vendors, "Test message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}