using System;
using System.Collections.Generic;

/*
* Author: Matthew Rodriguez
* Date Creation: June 20, 2022
* Date Modified: August 12, 2022
*/

namespace InvoiceCreation
{
    class Customer
    {
        private List<Customer> customers = new List<Customer>(); // list of customers that can be added, modified, viewed, or deleted based on user input
        public int nextID = 0; // count for the next id number to be assigned to the new added customer

        public int IdNumber // Customer ID Property
        {
            set; get;
        }

        public string FirstName  // Customer First Name Property
        {
            set; get;
        }

        public string LastName  // Customer Last Name Property
        {
            set; get;
        }

        public string Address // Customer Address Property
        {
            set; get;
        }

        public string PhoneNumber // Customer Phone Number Property 
        {
            set; get;
        }

        // Empty Constructor
        public Customer()
        {

        }

        // Constructor with one parameter in the form of an int ID_num parameter
        public Customer(int ID_num) 
        {
            IdNumber = ID_num; 
            FirstName = "Matthew";
            LastName = "Rodriguez";
            Address = "208 Washington Avenue";
            PhoneNumber = "9564563350";
        }

        // Constructor with five parameters with an int ID_num parameter and four string parameters: firstName, lastName, address, phoneNumber
        public Customer(int ID_num, string firstName, string lastName, string address, string phoneNumber) 
        {
            IdNumber = ID_num;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        /*
         * AddCustomer()
         * 
         * Add the customer object to the list of customers, and notify that a customer was added.
         * nextID will be incremented so the next id number will be used when creating a new customer object to add to the list.
         * 
         * Parameters: Customer newCustomer - The customer object to be added to the list
         * Returns: None
         */
        public void AddCustomer(Customer newCustomer)
        {
            customers.Add(newCustomer);
            Console.WriteLine("Customer Created!");
            nextID++;
        }

        /*
         * ViewAllCustomers()
         * 
         * Displays all the list of Customers stored within the customers list. 
         * If the list is empty an error message will be displayed instead.
         * 
         * Parameters: None
         * Returns: None
         */
        public void ViewAllCustomers()
        {
            if(customers.Count == 0)
            {
                Console.WriteLine("\nThere are no records within memory to view.");
            }
            else
            {
                foreach (Customer c in customers)
                {
                    Console.WriteLine("**********************************");
                    Console.WriteLine($"Customer ID Number: {c.IdNumber}");
                    Console.WriteLine($"Customer First Name: {c.FirstName}");
                    Console.WriteLine($"Customer Last Name: {c.LastName}");
                    Console.WriteLine($"Customer Address: {c.Address}");
                    Console.WriteLine($"Customer PhoneNumber: {c.PhoneNumber}");
                    Console.WriteLine("**********************************");
                }
            }
        }

        /*
         * CreateNewCustomer()
         * 
         * Add a new customer object and adds it to the in-store memory list of customers.
         * The user will input data into the firstName, lastName, address, and Phone Number. Error checking is handled by passing the values of firstname and lastname 
         * into theCheckName() function, address into the CheckAddress() function, and finally phoneNumber into the CheckValidPhoneNumber() function.
         * Once error checking is complete the data is passed into the Customer cosntructor with next_IDnum.
         * The customer object is then added to the list with notification. The variable nextID is incremented by 1.
         * 
         * Parameters: int next_IDnum - id number for the next customer object being created
         * Returns: None
         */
        public void CreateNewCustomer(int next_IDnum)
        {
            string firstName, lastName, address, phoneNumber; // Initialize all variables with the exception of the id number
            Console.WriteLine("Enter Customer First Name:");
            firstName = Console.ReadLine();
            bool isValidFName = CheckName(firstName);
            while(!isValidFName)
            {
                Console.WriteLine("A name cannot contain any numbers or special characters/symbols. Please enter a First Name."); // output error message
                firstName = Console.ReadLine();
                isValidFName = CheckName(firstName);
            }
            Console.WriteLine("Enter Customer Last Name:");
            lastName = Console.ReadLine();
            bool isValidLName = CheckName(lastName);
            while(!isValidLName)
            {
                Console.WriteLine("A name cannot contain any numbers or special characters/symbols. Please enter a Last Name."); // output error message
                lastName = Console.ReadLine();
                isValidLName = CheckName(lastName);
            }
            Console.WriteLine("Enter Customer Address:");
            address = Console.ReadLine();
            bool isValidAddress = CheckAddress(address);
            while(!isValidAddress)
            {
                Console.WriteLine("An address cannot contain any special characters or symbols. Letters, numbers, and spaces are okay. Please enter an Address.");
                address = Console.ReadLine();
                isValidAddress = CheckAddress(address);
            }
            Console.WriteLine("Enter Customer Phone Number:");
            phoneNumber = Console.ReadLine();
            bool isValidNumber = CheckValidPhoneNumber(phoneNumber); // flag to check if the number is valid
            while (isValidNumber == false)  // while the number is not valid
            {
                Console.WriteLine("The phone number entered is not valid. " +
                    "The phone number must be a total of 10 digits with no letters, spaces or special characters."); // output error message
                phoneNumber = Console.ReadLine(); // get user input 
                isValidNumber = CheckValidPhoneNumber(phoneNumber); // call CheckValidPhoneNumber function passing in the user input
            }
            var newCustomer = new Customer(next_IDnum, firstName, lastName, address, phoneNumber); // make new customer object from inputs
            customers.Add(newCustomer);
            nextID++;
            Console.WriteLine("Customer Added");
        }

        /*
         * CheckValidPhoneNumber()
         * 
         * Checks the input to verify if it is a ten digit string. The variable isValid will be returned.
         * If the string is either too long, too short, or contains any letters or special characters, a false value will be assigned to isValid.
         * Otherwise, true will be assigned to isValid.
         * 
         * Parameters: string number - the string input from the user
         * Returns: isValid - flag for phone number validation (True or False)
         */
        public bool CheckValidPhoneNumber(string number)
        {
            bool isVaild;  // flag 
            // Console.WriteLine(number.Length);

            if (number.Length == 10)  // Check to see if the length of the string is equal to 10
            {
                // Check if the input contains any characters besides a number
                if (number.Contains('A') || number.Contains('B') || number.Contains('C') || number.Contains('D') || number.Contains('E') || number.Contains('F') || number.Contains('G') || number.Contains('H') ||
                    number.Contains('I') || number.Contains('J') || number.Contains('K') || number.Contains('L') || number.Contains('M') || number.Contains('N') || number.Contains('O') || number.Contains('P') ||
                    number.Contains('Q') || number.Contains('R') || number.Contains('S') || number.Contains('T') || number.Contains('U') || number.Contains('V') || number.Contains('W') || number.Contains('X') ||
                    number.Contains('Y') || number.Contains('Z') || number.Contains('a') || number.Contains('b') || number.Contains('c') || number.Contains('d') || number.Contains('e') || number.Contains('f') ||
                    number.Contains('g') || number.Contains('h') || number.Contains('i') || number.Contains('j') || number.Contains('k') || number.Contains('l') || number.Contains('m') || number.Contains('n') ||
                    number.Contains('o') || number.Contains('p') || number.Contains('q') || number.Contains('r') || number.Contains('s') || number.Contains('t') || number.Contains('u') || number.Contains('v') ||
                    number.Contains('w') || number.Contains('x') || number.Contains('y') || number.Contains('z') || number.Contains('!') || number.Contains('@') || number.Contains('#') || number.Contains('$') ||
                    number.Contains('%') || number.Contains('^') || number.Contains('&') || number.Contains('&') || number.Contains('*') || number.Contains('(') || number.Contains(')') || number.Contains('_') ||
                    number.Contains('+') || number.Contains('-') || number.Contains('=') || number.Contains('{') || number.Contains('}') || number.Contains('|') || number.Contains(':') || number.Contains('"') ||
                    number.Contains('<') || number.Contains('>') || number.Contains('?') || number.Contains('[') || number.Contains(']') || number.Contains((char)0x5C) || number.Contains(';') || number.Contains((char)0X27) ||
                    number.Contains(',') || number.Contains('.') || number.Contains('/') || number.Contains(' '))  
                    isVaild = false; // set to false if it does contain an invalid character
                else
                    isVaild = true; // set to true if number doesn't contain any special characters or letters
            }
            else
                isVaild = false; // set to false if the length of the number is less or more than 10 characters
            return isVaild; // return the flag
        }

        /*
         * CheckName()
         * 
         * This function checks the user inputted string name for any type of special characters or numbers.
         * A boolean variable named isValidName is set to true.
         * If there are, the boolean variable isValidName will be set to false.
         * The isValidName variable is returned.
         * 
         * Parameters: string name - the name if the string
         * Returns: isValidName - flag for name validation (True or False)
         */
        public bool CheckName(string name)
        {
            bool isValidName = true;  // flag 
                // Check if the input contains any characters besides letters
                if (name.Contains('!') || name.Contains('@') || name.Contains('#') || name.Contains('$') || name.Contains('%') || name.Contains('^') || name.Contains('&') || 
                    name.Contains('&') || name.Contains('*') || name.Contains('(') || name.Contains(')') || name.Contains('_') || name.Contains('+') || name.Contains('-') || 
                    name.Contains('=') || name.Contains('{') || name.Contains('}') || name.Contains('|') || name.Contains(':') || name.Contains('"') || name.Contains('<') || 
                    name.Contains('>') || name.Contains('?') || name.Contains('[') || name.Contains(']') || name.Contains((char)0x5C) || name.Contains(';') || 
                    name.Contains((char)0X27) || name.Contains(',') || name.Contains('.') || name.Contains('/') || name.Contains(' ') || name.Contains('0') ||
                    name.Contains('1') || name.Contains('2') || name.Contains('3') || name.Contains('4') || name.Contains('5') || name.Contains('5') || name.Contains('6') ||
                    name.Contains('7') || name.Contains('8') || name.Contains('9'))
                    isValidName = false; // set to false if it does contain an invalid character
            return isValidName; // return the flag
        }

        /*
         * CheckAddress()
         * This function checks the user inputted string name for any type of special characters or numbers.
         * A boolean variable named isValidName is set to true.
         * If there are, the boolean variable isValidName will be set to false.
         * 
         * *Parameters: string address - the name if the string
         * Returns: isValidAddress - flag for address validation (True or False)
         */
        public bool CheckAddress(string address)
        {
            bool isValidAddress = true;
            // Check if the input contains any special characters or symbols (Letters, Numbers, Whitespaces - OK)
            if (address.Contains('!') || address.Contains('@') || address.Contains('#') || address.Contains('$') || address.Contains('%') || address.Contains('^') || address.Contains('&') ||
                address.Contains('&') || address.Contains('*') || address.Contains('(') || address.Contains(')') || address.Contains('_') || address.Contains('+') || address.Contains('-') ||
                address.Contains('=') || address.Contains('{') || address.Contains('}') || address.Contains('|') || address.Contains(':') || address.Contains('"') || address.Contains('<') ||
                address.Contains('>') || address.Contains('?') || address.Contains('[') || address.Contains(']') || address.Contains((char)0x5C) || address.Contains(';') ||
                address.Contains((char)0X27) || address.Contains(',') || address.Contains('.') || address.Contains('/'))
                isValidAddress = false; // set to false if it does contain an invalid character
            return isValidAddress;
        }

        /*
         * UpdateCustomerInfo()
         * 
         * A function that takes in user input to be passed into the CustomerIDSearchUpdate() function to search a record to update.
         * Checks to see if input is cancel, back, or done, so the user can return to the main menu. If not then we try to parse thr input into an int value.
         * Failing this will cause an error and the user will be asked to try again with another input.
         *
         * Parameters: None
         * Returns: None
         */
        public void UpdateCustomerInfo()
        {
            int id_num; // Id number to look for
            string input; // user input
            bool done = false; // flag to return to main menu when done modifying records
            Console.WriteLine("\nWhich customer data would you like to look up? Please enter the ID number to lookup the record\n" +
                "Or type back or cancel to return to the main menu.");
            while (!done)
            {
                input = Console.ReadLine();
                input.ToLower();
                if(input == "cancel" || input == "back" || input == "done")
                    done = true;
                else
                {
                    bool isParsable = Int32.TryParse(input, out id_num);
                    if (isParsable)
                        CustomerIdSearchUpdate(id_num);
                    else
                        Console.WriteLine("Invalid number/command entered. Please enter an ID number or enter command back or cancel to return to the main menu.");
                }
            }
        }

        /*
         * CustomerIdSearchUpdate()
         * 
         * This function searches for the record indicated by the value of the id_num passed in by the user from to be updated or modified by the user.
         * A boolean value named found is used to check a record is found or not. A for loop is used to cycle through the records to check if the id_num variable
         * matches. If found display the infomration and ask if this data is what they want to update. If so, ask if they want to update all of the record 
         * or just some attributes the record. User may type in cancel to return to the UpdateCustomerInfo() function without making any changes to the selected record. 
         * When user is updating with All, they will return to the UpdateCustomerInfo() function after filling in all of the attributes. 
         * When user is updating with Some, they may only return to the UpdateCustomerInfo() function after typing in done.
         * 
         * Parameters: int id_num - The id number used to search for the record in the list.
         * Returns: None
         */

        public void CustomerIdSearchUpdate(int id_num)
        {
            bool found = false;    // flag to check if a record has been found
            for (int i = 0; i < customers.Count; i++)
            {
                if (id_num == customers[i].IdNumber)
                {
                    string input;   // user input
                    bool doneModify = false;    //flag to verify that user id done modifying the record
                    found = true;   
                    Console.WriteLine("Record Found!");
                    Console.WriteLine($"Customer ID Number: {customers[i].IdNumber}");
                    Console.WriteLine($"Customer First Name: {customers[i].FirstName}");
                    Console.WriteLine($"Customer Last Name: {customers[i].LastName}");
                    Console.WriteLine($"Customer Address: {customers[i].Address}");
                    Console.WriteLine($"Customer PhoneNumber: {customers[i].PhoneNumber}");
                    while (!doneModify)
                    {
                        Console.WriteLine("Is this the record you would like to modify? (Yes / No)");
                        input = Console.ReadLine();
                        input.ToLower();
                        if (input == "yes" || input == "y")
                        {
                            bool recordComplete = false;
                            while (!recordComplete)
                            {
                                Console.WriteLine("How would you like to update this record? (All, Some, Cancel)");
                                input = Console.ReadLine();
                                input.ToLower();
                                if (input == "all")
                                {
                                    string firstName, lastName, address, phonenumber;
                                    Console.WriteLine("Enter Customer First Name:");
                                    firstName = Console.ReadLine();
                                    bool isValidFName = CheckName(firstName);
                                    while (!isValidFName)
                                    {
                                        Console.WriteLine("A name cannot contain any numbers or special characters/symbols. Please enter a First Name."); // output error message
                                        firstName = Console.ReadLine();
                                        isValidFName = CheckName(firstName);
                                    }
                                    customers[i].FirstName = firstName;
                                    Console.WriteLine("Enter Customer Last Name:");
                                    lastName = Console.ReadLine();
                                    bool isValidLName = CheckName(lastName);
                                    while (!isValidLName)
                                    {
                                        Console.WriteLine("A name cannot contain any numbers or special characters/symbols. Please enter a Last Name."); // output error message
                                        lastName = Console.ReadLine();
                                        isValidLName = CheckName(lastName);
                                    }
                                    customers[i].LastName = lastName;
                                    Console.WriteLine("Enter Customer Address:");
                                    address = Console.ReadLine();
                                    bool isValidAddress = CheckAddress(address);
                                    while (!isValidAddress)
                                    {
                                        Console.WriteLine("An address cannot contain any special characters or symbols. Letters, numbers, and spaces are valid. Please input an Address.");
                                        address = Console.ReadLine();
                                        isValidAddress = CheckAddress(address);
                                    }
                                    customers[i].Address = address;
                                    Console.WriteLine("Enter Customer Phone Number:");
                                    phonenumber = Console.ReadLine();
                                    bool isValidNumber = CheckValidPhoneNumber(phonenumber); 
                                    while (isValidNumber == false)  
                                    {
                                        Console.WriteLine("The phone number entered is not valid. The phone number must be a total of 10 digits with no letters, spaces or special characters. Please input a phone number.");
                                        phonenumber = Console.ReadLine(); 
                                        isValidNumber = CheckValidPhoneNumber(phonenumber);
                                        if (isValidNumber)
                                            customers[i].PhoneNumber = phonenumber;
                                    }
                                    Console.WriteLine("Record Updated!");
                                    recordComplete = true;
                                }
                                else if (input == "some")
                                {
                                    string firstName, lastName, address, phonenumber;
                                    bool finish = false;
                                    while (!finish)
                                    {
                                        Console.WriteLine("Which part of the record do you want to change? (firstname, lastname, address, phonenumber)\n" +
                                            "If you need to check the record again, type check. Type done to return to the record select menu.");
                                        input = Console.ReadLine();
                                        input.ToLower();
                                        if (input == "firstname")
                                        {
                                            Console.WriteLine("Enter Customer First Name:");
                                            firstName = Console.ReadLine();
                                            bool isValidFName = CheckName(firstName);
                                            while (!isValidFName)
                                            {
                                                Console.WriteLine("A name cannot contain any numbers or special characters/symbols. Please enter a First Name."); // output error message
                                                firstName = Console.ReadLine();
                                                isValidFName = CheckName(firstName);
                                            }
                                            customers[i].FirstName = firstName;
                                        }
                                        else if (input == "lastname")
                                        {
                                            Console.WriteLine("Enter Customer Last Name:");
                                            lastName = Console.ReadLine();
                                            bool isValidLName = CheckName(lastName);
                                            while (!isValidLName)
                                            {
                                                Console.WriteLine("A name cannot contain any numbers or special characters/symbols. Please enter a Last Name."); // output error message
                                                lastName = Console.ReadLine();
                                                isValidLName = CheckName(lastName);
                                            }
                                            customers[i].LastName = lastName;
                                        }
                                        else if (input == "address")
                                        {
                                            Console.WriteLine("Enter Customer Address:");
                                            address = Console.ReadLine();
                                            bool isValidAddress = CheckAddress(address);
                                            while (!isValidAddress)
                                            {
                                                Console.WriteLine("An address cannot contain any special characters or symbols. Letters, numbers, and spaces are okay. Please enter an Address.");
                                                address = Console.ReadLine();
                                                isValidAddress = CheckAddress(address);
                                            }
                                            customers[i].Address = address;
                                        }
                                        else if (input == "phonenumber")
                                        {
                                            Console.WriteLine("Enter Customer Phone Number:");
                                            phonenumber = Console.ReadLine();
                                            bool isValidNumber = CheckValidPhoneNumber(phonenumber);
                                            while (isValidNumber == false)
                                            {
                                                Console.WriteLine("The phone number entered is not valid. The phone number must be a total of 10 digits with no letters, spaces or special characters. Please input a phone number.");
                                                phonenumber = Console.ReadLine(); 
                                                isValidNumber = CheckValidPhoneNumber(phonenumber);
                                                if (isValidNumber)
                                                    customers[i].PhoneNumber = phonenumber;
                                            }
                                        }
                                        else if (input == "check")
                                        {
                                            Console.WriteLine($"Customer ID Number: {customers[i].IdNumber}");
                                            Console.WriteLine($"Customer First Name: {customers[i].FirstName}");
                                            Console.WriteLine($"Customer Last Name: {customers[i].LastName}");
                                            Console.WriteLine($"Customer Address: {customers[i].Address}");
                                            Console.WriteLine($"Customer PhoneNumber: {customers[i].PhoneNumber}");
                                        }
                                        else if (input == "done")
                                        {
                                            finish = true;
                                            recordComplete = true;
                                            Console.WriteLine("Record Updated!");
                                        }
                                        else
                                            Console.WriteLine("Invalid Input");
                                    }
                                }
                                else if (input == "cancel")
                                    recordComplete = true;
                                else
                                    Console.WriteLine("Invalid Input");
                            }
                            doneModify = true;
                            Console.WriteLine("Which customer data would you like to modify? Please enter the ID number to lookup the record\n" +
                "Or type back or cancel to return to the main menu.");
                        }
                        else if (input == "no" || input == "n")
                        {
                            doneModify = true;
                            Console.WriteLine("Which customer data would you like to modify? Please enter the ID number to lookup the record\n" +
                "Or type back or cancel to return to the main menu.");
                        }
                        else
                            Console.WriteLine("Invalid Input. Please input Yes or No.");
                    }
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Record could not be found. Please enter a different ID number.");
            }
        }

        /*
         * DeleteCustomerInfo()
         * 
         * A function that takes in user input to be passed into the CustomerIDSearchUpdate() function to search a record to delete.
         * Checks to see if input is cancel, back, or done, so the user can return to the main menu. If not then we try to parse thr input into an int value.
         * Failing this will cause an error and the user will be asked to try again with another input.
         * If at any point the customers list is empty the user will be taken back to the main menu of the program.
         *
         * Parameters: None
         * Returns: None
         */
        public void DeleteCustomerInfo()
        {
            int id_num; // Id number to look for
            string input; // user input
            bool done = false; // flag to return to main menu when done deleting records
            Console.WriteLine("\nWhich customer data would you like to look up? Please enter the ID number to lookup the record\n" +
                "Or type back or cancel to return to the main menu.");
            while (!done)
            {
                input = Console.ReadLine();
                input.ToLower();
                if (input == "cancel" || input == "back")
                    done = true;
                else
                {
                    bool isParsable = Int32.TryParse(input, out id_num);
                    if (isParsable)
                    {
                        CustomerIdSearchDelete(id_num);
                        if(customers.Count == 0)
                            done = true; // return to the main menu if the list is empty
                    }
                    else
                        Console.WriteLine("Invalid number/command entered. Please enter an ID number or enter command back or cancel to return to the main menu.");
                }
            }
        }

        /*
         * CustomerIdSearchDelete()
         * 
         * This function searches for the record indicated by the value of the id_num passed in by the user from to be deleted by the user.
         * A boolean value named found is used to check a record is found or not. A for loop is used to cycle through the records to check if the id_num variable
         * matches. If found display the information and ask if this data is what they want to delete. If user inputs yes, they will be asked another time to confirm.
         * If user inputs no they will exit the function and return to DeleteCustomerInfo() function. If input is yes again, the record based on the user id entered
         * will be deleted. Also, records from the deleted postion onwards will have their id values decremented by one to match the size of customer list.
         * This is due to the fact that this is isn't DB driven.
         * The user will be taken back to the DeleteCustomerInfo() function after deletion. If the list is empty after deleting a record, the user will be notified.
         * 
         * Parameters: int id_num - the id number to search for to be deleted
         * Returns: None
         */
        public void CustomerIdSearchDelete(int id_num)
        {
            bool found = false;    // flag to check if a record has been found
            for (int i = 0; i < customers.Count; i++)
            {
                if (id_num == customers[i].IdNumber)
                {
                    string input;   // user input
                    bool doneDelete = false;    //flag to verify that user is done deleting the record
                    found = true;
                    Console.WriteLine("Record Found!");
                    Console.WriteLine($"Customer ID Number: {customers[i].IdNumber}");
                    Console.WriteLine($"Customer First Name: {customers[i].FirstName}");
                    Console.WriteLine($"Customer Last Name: {customers[i].LastName}");
                    Console.WriteLine($"Customer Address: {customers[i].Address}");
                    Console.WriteLine($"Customer PhoneNumber: {customers[i].PhoneNumber}");
                    while (!doneDelete)
                    {
                        Console.WriteLine("Are you sure you want to delete this customer? (Yes / No)");
                        input = Console.ReadLine();
                        input.ToLower();
                        if (input == "yes" || input == "y") // Ask a second time.
                        {
                            Console.WriteLine("ARE YOU SURE? Once deleted it's gone forever. (Yes / No)");
                            input = Console.ReadLine();
                            input.ToLower();
                            if (input == "yes" || input == "y") // Okay then...
                            {
                                customers.RemoveAt(i); // remove the customer object from the list at index i
                                for(int x = id_num; x < customers.Count; x++) // from the point where the record i was deleted until we get to the end of the list
                                {
                                    customers[x].IdNumber--; // decrement the next customer id value by 1 for all records to match with the size of the list.
                                }
                                nextID--; // decrement the size count by 1
                                doneDelete = true;
                                Console.WriteLine("Record Deleted!");
                                if(nextID == 0)
                                    Console.WriteLine("There are no more records within the list. Returning to the main menu.");
                                else
                                    Console.WriteLine("Which customer data would you like to delete? Please enter the ID number to lookup the record\n" +
                    "Or type back or cancel to return to the main menu.");
                            }
                            else if (input == "no" || input == "n")
                            {
                                doneDelete = true;
                                Console.WriteLine("Which customer data would you like to delete? Please enter the ID number to lookup the record\n" +
                    "Or type back or cancel to return to the main menu.");
                            }
                            else
                                Console.WriteLine("Invalid Input. Please input Yes or No. Delete this record for good?");
                        }
                        else if (input == "no" || input == "n")
                        {
                            doneDelete = true;
                            Console.WriteLine("Which customer data would you like to delete? Please enter the ID number to lookup the record\n" +
                "Or type back or cancel to return to the main menu.");
                        }
                        else
                            Console.WriteLine("Invalid Input. Please input Yes or No. Delete Record?");
                    }
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Record could not be found. Please enter a different ID number.");
            }
        }
    }
}