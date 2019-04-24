using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestHomework00.Core.Homework02
{
    public class MessyAddressInformation
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class CleanAddressInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class MessyListToCleanList
    {
        public List<CleanAddressInformation> CleanAddresses(
            List<MessyAddressInformation> messyAddresses)
        {
            var cleanAddresses = new List<CleanAddressInformation>();

            foreach (var messyAddress in messyAddresses)
            {
                var clean = new CleanAddressInformation();

                //if (messyAddress.Name != null)
                //{
                    var splitName = messyAddress.Name?.Split(' ');
                //    if (splitName.Length == 2)
                //    {
                //        clean.FirstName = splitName[0];
                //        clean.LastName = splitName[1];
                //    }
                //    else if (splitName.Length == 1)
                //    {
                //        if (splitName[0].Length == 0)
                //        {
                //            clean.FirstName = "N/A";
                //            clean.LastName = "N/A";
                //        }
                //        else
                //        {
                //            clean.FirstName = splitName[0];
                //            clean.LastName = "N/A";
                //        }
                //    }
                //}

                messyAddress.Name != null ? clean.FirstName = splitName[0] : clean.FirstName = "N/A";

                if (messyAddress.Address != null)
                {
                    var splitAddress = messyAddress.Address.Split(',');
                    if (splitAddress.Length == 4)
                    {
                        clean.StreetAddress = splitAddress[0];
                        clean.City = splitAddress[1].Trim();
                        clean.State = splitAddress[2].Trim();
                        clean.ZipCode = splitAddress[3].Trim();
                    }
                    else
                    {
                        clean.StreetAddress = "N/A";
                        clean.City = "N/A";
                        clean.State = "N/A";
                        clean.ZipCode = "N/A";
                    }
                }

                cleanAddresses.Add(clean);
            }

            return cleanAddresses;
        }
    }
}
