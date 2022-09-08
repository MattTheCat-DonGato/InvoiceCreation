using System;
using System.IO;
/*
 * Author: Matthew Rodriguez
 * Date Creation: June 20, 2022
 * Date Modified: September 7, 2022
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
               Console.WriteLine("\nWhat would you like to do?\nCreate Customer Record\nUpdate Customer Record\nDelete Customer Record\nView Customer Records\nSave Records to File\nExit Program\nIf you need help on what to do, type in help or h.");
                input = Console.ReadLine();
                input = input.ToLower();
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
                else if (input == "save" || input == "save records")
                    SaveCustomerInfo(customerList);
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

        static void SaveCustomerInfo(Customer cList)
        {
            if (cList.nextID == 0) // if the list is empty
                Console.WriteLine("\nThere are no records within memory to save.");
            else // 
                cList.SaveCustomerListToFile();
        }

        static void LoadCustomerInfo(Customer cList)
        {
            string input;  // user input
            string fileName;  // string for the filename path
            bool doneLoad = false;  // flag for user to return to main menu after loading a file or cancel loading
            if (cList.nextID != 0) // if there are records within memory
            {
                Console.WriteLine("There are currently some records still within memory. All data within this list will be deleted upon loading from a file. " +
                    "Do you want to save or overwrite these records to a file? (Yes / No)"); // Ask if user wants to overwrite the file
                while (!doneLoad)
                {
                    input = Console.ReadLine();
                    input = input.ToLower();
                    if (input == "yes" || input == "y") // If the user wants to save/overwrite the file with the current memory list
                    {
                        bool redoFileName = true; // flag to retry inputting a file name until a valid one is read
                        Console.WriteLine("NOTE: If you change your mind about saving, the customer data in memory will still be deleted. Be careful!");
                        cList.SaveCustomerListToFile(); // call this function to save current customer list data to the file
                        cList.DeleteAllCustomerData(); // clear all the customer data
                        while (redoFileName)
                        {
                            Console.WriteLine("Please enter a file name to load customer data into the main memory.");
                            input = Console.ReadLine(); // inform user to enter a file name to load the data from (must end in .dat or .txt)
                            fileName = input;
                            if (fileName.EndsWith(".dat") || fileName.EndsWith(".txt"))
                            {
                                bool fileExists = File.Exists(fileName); // check of the file exists
                                if(fileExists) // if the file does exists
                                {
                                    bool savetoLoadConfirm = false; // flag for loop to continue until user decides to load from this fileName.
                                    while (!savetoLoadConfirm) // while we have not confirmed to load after saving
                                    {
                                        Console.WriteLine($"Load customer data from {fileName}? (Yes / No)");
                                        input = Console.ReadLine();
                                        input = input.ToLower();
                                        if (input == "yes" || input == "y") // if yes...
                                        {
                                            cList.LoadCustomerListfromFile(fileName); // call the cList.LoadCustomerListFromFile(fileName) to load the data.
                                            savetoLoadConfirm = true; // exit the savetoLoadConfirm loop
                                            redoFileName = false; // exit the redo loop
                                            doneLoad = true; // exit the doneLoad loop and return to main menu
                                            Console.WriteLine("Returning to Main Menu.");
                                        }
                                        else if (input == "no" || input == "n") // if no..
                                        {
                                            bool confirmNewFileName = false;
                                            while(!confirmNewFileName)
                                            {
                                                Console.WriteLine("Do you want to enter a different file name? (Yes / No)");
                                                Console.WriteLine("Inputting No will allow you to return to the main menu without deleting the current customer data.");
                                                input = Console.ReadLine();
                                                input = input.ToLower();
                                                if (input == "yes" || input == "y")
                                                {
                                                    confirmNewFileName = true; // exit confirmNewFileName loop
                                                    savetoLoadConfirm = true; // exit savetoLoadConfirm loop -> return to redoFileName loop
                                                }
                                                else if (input == "no" || input == "n")
                                                {
                                                    confirmNewFileName = true; // exit confirmNewFileName loop
                                                    savetoLoadConfirm = true; // exit savetoLoadConfirm loop
                                                    redoFileName = false; // exit redoFileName loop
                                                    doneLoad = true; // exit doneLoad loop -> return to Main Menu
                                                }
                                                else
                                                    Console.WriteLine("Invalid input. Please enter Yes or No.");
                                            }
                                        }
                                        else
                                            Console.WriteLine("Invalid input. Please enter Yes or No.");
                                    }         
                                }
                                else
                                {
                                    Console.WriteLine($"The file name {fileName} doesn't exist.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input doesn't end with .dat or .txt type extension. Please enter a filename that ends with .dat or .txt.");
                            }
                        }                
                    }
                    else if (input == "no" || input == "n") // If they do not want to save/overwrite the file
                    {
                        bool cancel = false; // flag to cancel if user changes their mind
                        while(!cancel)
                        {
                            Console.WriteLine("The in memory list of customer data will be gone if you don't save. Proceed? (Yes / No)");
                            input = Console.ReadLine();
                            input = input.ToLower();
                            if (input == "yes" || input == "y") // user continues to load without saving data
                            {
                                bool redoFileNameNoSave = false;
                                while(!redoFileNameNoSave)
                                {
                                    Console.WriteLine("Please enter a file name to load customer data into the main memory.");
                                    input = Console.ReadLine(); // inform user to enter a file name to load the data from (must end in .dat or .txt)
                                    fileName = input;
                                    if(fileName.EndsWith(".dat") || fileName.EndsWith(".txt"))
                                    {
                                        bool fileExistsNoSave = File.Exists(fileName);
                                        if(fileExistsNoSave)
                                        {
                                            Console.WriteLine($"Load customer data from {fileName}? (Yes / No)");
                                            input = Console.ReadLine();
                                            input = input.ToLower();
                                            if (input == "yes" || input == "y")
                                            {
                                                cList.LoadCustomerListfromFile(fileName); // call the cList.LoadCustomerListFromFile(fileName) to load the data.
                                                redoFileNameNoSave = true;                // leave redoFileNameNoSave loop
                                                cancel = true;                            // leave cancel loop
                                                doneLoad = true;                          // leave doneLoad loop -> return to Main Menu
                                            }
                                            else if (input == "no" || input == "n")
                                            {
                                                bool confirmNewFileNameNoSave = false;
                                                while (!confirmNewFileNameNoSave)
                                                {
                                                    Console.WriteLine("Do you want to enter a different file name? (Yes / No)");
                                                    Console.WriteLine("Inputting No will allow you to return to the main menu without deleting the current customer data.");
                                                    input = Console.ReadLine();
                                                    input = input.ToLower();
                                                    if (input == "yes" || input == "y")
                                                    {
                                                        confirmNewFileNameNoSave = true; // exit confirmNewFileNameNoSave loop -> go to redoFileNameNoSave
                                                    }
                                                    else if (input == "no" || input == "n")
                                                    {
                                                        confirmNewFileNameNoSave = true;          // leave confirmNewFileNameNoSave loop
                                                        redoFileNameNoSave = true;                // leave redoFileNameNoSave loop
                                                        cancel = true;                            // leave cancel loop
                                                        doneLoad = true;                          // leave doneLoad loop -> return to Main Menu
                                                    }
                                                    else
                                                        Console.WriteLine("Invalid input. Please enter Yes or No.");
                                                }                                           
                                            }
                                            else
                                                Console.WriteLine("Invalid input, please enter Yes or No.");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"The file name {fileName} doesn't exist.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input doesn't end with .dat or .txt type extension. Please enter a filename that ends with .dat or .txt.");
                                    }
                                }
                            }
                            else if (input == "no" || input == "n") // user moves back to the first while loop area.
                            {
                                cancel = true;
                                Console.WriteLine("There are currently some records still within memory. All data within this list will be deleted upon loading from a file. " +
                    "Do you want to save or overwrite these records to a file? (Yes / No)");
                            }
                            else
                                Console.WriteLine("Invalid input. Please input yes or no.");
                        }
                    }
                    else
                        Console.WriteLine("Invalid input. Do you want to save/overwrite the current customer data to a file? (Yes / No)");
                }
            }
            else // no records in memory
            {
                Console.WriteLine("Please enter a file name to load customer data into the main memory.");
                input = Console.ReadLine();  // get user input
                fileName = input;            // set to fileName
                bool fileExists = File.Exists(fileName);
                if(fileExists)
                {
                    bool loadNoCustomer = false; 
                    while(!loadNoCustomer)
                    {
                        Console.WriteLine($"Load customer data from {fileName}? (Yes / No)");  // Overwrite?
                        input = Console.ReadLine();
                        input = input.ToLower();
                        if (input == "yes" || input == "y") // if yes...
                        {
                            // clear all the customer data (need to make a ClearAllCustomerData() function)
                            // call cList.LoadCustomerListfromFile(fileName) to load the customer data (needs to be implemented)
                            // return to main menu 
                        }
                        else if (input == "no" || input == "n") // if no..
                        {
                            // output messafe to ask if they want to enter a different file name
                            // if yes, 
                        }
                        else
                            Console.WriteLine("Invalid input, please enter yes or no");
                    }
                }
                else
                {
                    Console.WriteLine($"The file name {fileName} doesn't exist. Enter a different file name? (Yes / No)");
                }   
            }
        }
    }
}