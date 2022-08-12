using System.Collections.Generic;
/*
 * Author: Matthew Rodriguez
 * Date Creation: June 20, 2022
 * Date Modified: August 12, 2022
 */
namespace InvoiceCreation
{
    class Jobs
    {
        private List<Jobs> allJobs = new List<Jobs>(); // list of jobs that will be added, modified or deleted based on certain situations

        public string JobName
        {
            get; set;
        }

        public string JobDesc
        {
            get; set;
        }

        public double JobPrice
        {
            get; set;
        }

        public Jobs()  // Empty Constructor
        {
        }

        public Jobs(string name, string desc, double price)  // Override Constructor to add new jobs for list of services.
        {
            JobName = name;
            JobDesc = desc;
            JobPrice = price;
        }

    }
}
