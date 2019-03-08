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


        //a generic list can be any length and provides methods to easily add, insert, or remove elements from the list
        //declaring a generic list
        public List<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                //initialize new list of type Vendor
                vendors = new List<Vendor>();

                //populate the list
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });
            }

            //iterating through the list 
            //use the for loop when iterating through a subset of the list or to modify the object instance 
            for (int i = 0; i < vendors.Count; i++)
            {
                //Console.WriteLine(vendors[i]);
            }

            //simplest way to iterate through an entire list. an objects properties can be edited, but not the object instance
            foreach (var vendor in vendors)
            {
                Console.WriteLine(vendor);
            }

            return vendors;
        }

        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>()
            {
                { "ABC Corp", new Vendor()
                    { VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                { "XYZ Corp", new Vendor()
                    { VendorId = 8, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" } }
                };
            Console.WriteLine(vendors["XYZ Corp"]);
            //checking to see if the key exists
            if (vendors.ContainsKey("XYZ"))
            {
                Console.WriteLine(vendors["XYZ"]);
            }
            //or...this code is more efficient because it doesn't have to look up the key twice
            Vendor vendor;
            if (vendors.TryGetValue("XYZ", out vendor))
            {
                Console.WriteLine(vendor);
            }

            return vendors;
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
