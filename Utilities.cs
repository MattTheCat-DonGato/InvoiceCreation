using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreation
{
/*
* Author: Matthew Rodriguez
* Date Creation: August 9, 2022
* Date Modified: August 12, 2022
*/
    class Utilities
    {
        /*
         * IntroMessage()
         * Function to display the intro message for the program.
         * 
         * Parameters: None
         * Returns: None
         */
        public void IntroMessage()
        {
            Console.WriteLine("Hello. Welcome to my Invoice Program. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("Currently we can only create customer records, read customer records, update customer records, and delete customer records. (Press Enter)");
            Console.ReadLine();
        }

        /*
         * HelperFunction()
         * Displays information on how the program works and commands the user can use within it.
         * 
         * Parameters: None
         * Returns: None
         */
        public void HelperFunction()
        {
            Console.WriteLine("You found the help function!\nCreate Customer Record lets you add customers into the in-memory customer list. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("To access this menu, type in create, create customer, or create customer record. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("Update Customer Record allows you to change or update customer records that are currently stored within memory. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("To access this menu, type in update, update customer, or update customer record. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("Delete Customer Record allows you to delete customer records that are currently stored within memory. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("To access this menu, type in delete, delete customer, or delete customer record. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("View Records will display all of the records within memory. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("To access this, type in view or view records. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("Exit Program will close the program. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("Type exit, quit, or exit program to end the program. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("This all for now, but more features and functionality will be added over time. (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("Press Enter to return to the Main Menu.");
            Console.ReadLine();
        }
    }
}
