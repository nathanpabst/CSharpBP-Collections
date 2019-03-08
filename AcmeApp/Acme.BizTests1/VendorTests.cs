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
            //creating an instance of the VendorRepository
            var vendorRepository = new VendorRepository();
            //calling the Retrieve method to retrieve the vendors
            var vendors = vendorRepository.Retrieve();
            //define the expected result...2 messages 
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Corp",
            };

            //Act
            var actual = Vendor.SendEmail(vendors, "Test message");

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
            var vendors = vendorRepository.RetrieveArray();
            //define the expected result...2 messages 
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Corp",
            };

            //Act
            //this code cannot convert the array to a list of vendors. need to change code in the vendor class from List to IList
            var actual = Vendor.SendEmail(vendors, "Test message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}