using System;
/*
 * Author: Matthew Rodriguez
 * Date Creation: June 20, 2022
 * Date Modified: August 12, 2022
 */
namespace InvoiceCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customerList = new(); // Initialize new Customer Object for list
            Utilities messages = new(); // Helper functions, etc.
            string input; // Initalize user input stream
            bool exitProgram = false; // flag to end the program
            messages.IntroMessage();
            while (!exitProgram)
            {
                Console.WriteLine("\nWhat would you like to do?\nCreate Customer Record\nUpdate Customer Record\nDelete Customer Record\nView Customer Records\nExit Program\nIf you need help on what to do, type in help or h.");
                input = Console.ReadLine();
                input.ToLower();
                if (input == "create" || input == "create customer" || input == "create customer record")
                    CreateCustomerInfo(customerList);
                else if (input == "update" || input == "update customer" || input == "update customer record")
                    UpdateCustomerInfo(customerList);
                else if (input == "delete" || input == "delete customer" || input == "delete customer record")
                    DeleteCustomerInfo(customerList);
                else if (input == "view" || input == "view records" || input == "read" || input == "read customer records" || input == "read records")
                    customerList.ViewAllCustomers();
                else if (input == "help" || input == "h")
                    messages.HelperFunction();
                else if (input == "exit" || input == "exit program" || input == "quit")
                    exitProgram = true;
                else
                    Console.WriteLine("Invalid command. You may type help for an overview of the program.\n");
            }
            Console.WriteLine("Thank you for using this program. Good bye.");
            Console.ReadLine();
        }

        static void CreateCustomerInfo(Customer cList)
        {   
            Console.WriteLine("\nWould you like to create a new customer or use old customer info? (New or Old)." +
                "\nType done when you are done entering customer information.");  // display welcome message
            string input;  // Initialize a string for user input

            while (true)
            {            
                input = Console.ReadLine().ToLower();  // convert input to lowercase 
                if (input == "done") // if done break the loop and return to the main menu
                {
                    break;
                }
                else if (input == "old")
                {
                    var oldcust = new Customer(cList.nextID);  // Create a customer object using the default constructor
                    cList.AddCustomer(oldcust);
                    Console.WriteLine("Would you like to create another customer? (New or Old)\nOr would you like to return to the main menu? (Done)");
                }
                else if (input == "new")
                {
                    cList.CreateNewCustomer(cList.nextID);  // Create a new Customer object from user input
                    Console.WriteLine("Would you like to create another customer? (New or Old)\nOr would you like to return to the main menu? (Done)");
                }
                else
                {
                    Console.WriteLine("Invalid Input. To make a new customer from scratch, type in new.\nTo make a customer from an old data set, type in old.\nTo return to the main menu type done.");
                }
            }
        }

        static void UpdateCustomerInfo(Customer cList)
        {
            // If the list is empty
            if (cList.nextID == 0)
                Console.WriteLine("\nThere are no records within memory to update.");
            else
                cList.UpdateCustomerInfo();
        }

        static void DeleteCustomerInfo(Customer cList)
        {
            if (cList.nextID == 0)
                Console.WriteLine("\nThere are no records within memory to delete.");
            else
                cList.DeleteCustomerInfo();
        }
    }
}
