﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}