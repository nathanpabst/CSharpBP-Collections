using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        //add field to retain list of vendors
        private List<Vendor> vendors;

        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        //changing the return type to IEnumerable to restrict the caller from adding/removing (ie an immutable collection) from the collection
        public IEnumerable<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                //initialize new list of type Vendor
                vendors = new List<Vendor>();

                //populate the list
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });
            }

            foreach (var vendor in vendors)
            {
                Console.WriteLine(vendor);
            }

            return vendors;
        }

        public IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>()
            {
                { new Vendor()
                { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                { new Vendor()
                { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" } },
                { new Vendor()
                { VendorId = 12, CompanyName = "EFG Ltd", Email = "efg@efg.com" } },
                { new Vendor()
                { VendorId = 17, CompanyName = "HIJ AG", Email = "hij@hij.com" } },
                { new Vendor()
                { VendorId = 22, CompanyName = "Amal Toys", Email = "a@amaltoys.com" } },
                { new Vendor()
                { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocs@abc.com" } },
                { new Vendor()
                { VendorId = 31, CompanyName = "Home Products Inc", Email = "home@abc.com" } },
                { new Vendor()
                { VendorId = 35, CompanyName = "Car Toys", Email = "car@abc.com" } },
                { new Vendor()
                { VendorId = 42, CompanyName = "Toys n Stuff Inc", Email = "stuff@abc.com" } }

            };
            return vendors;
        }

        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            // get data from the database
            this.Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor Id: {vendor.VendorId}");
                //yield return listed below provides example of deferred execution...use an iterator for deferred execution. DE: when evaluation of an expression (such as a method call) is delayed until its value is required. 
                //...don't use DE if it is not required and the method always returns an entire list
                //and... lazy evaluation...method will return one element at a time.  
                yield return vendor;
            }

        }

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            T value = defaultValue;

            return value;
        }


        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }
    }
}
