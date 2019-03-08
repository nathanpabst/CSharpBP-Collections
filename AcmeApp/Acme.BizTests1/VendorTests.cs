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
    }
}