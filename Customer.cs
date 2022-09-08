using System;
using System.Collections.Generic;
using System.IO;
/*
* Author: Matthew Rodriguez
* Date Creation: June 20, 2022
* Date Modified: September 7, 2022
*/
namespace InvoiceCreation
{
    [Serializable]
    class Customer
    {
        private List<Customer> customers = new List<Customer>(); // list of customers that can be added, modified, viewed, or deleted based on user input
        public int nextID = 0; // count for the next unique id number to be assigned to the new added customer

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

        public string State // Customer State Property
        {
            set; get;
        }

        public string City // Customer City Property
        {
            set; get;
        }

        public string Zip  // Customer Zip Property
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
            City = "San Benito";
            State = "TX";
            Address = "208 Washington Avenue";
            Zip = "78586";
            PhoneNumber = "9564563350";
        }

        // Constructor with seven parameters with an int ID_num parameter and four string parameters: firstName, lastName, city, state, address, zip, phoneNumber
        public Customer(int ID_num, string firstName, string lastName, string city , string state, string address, string zip, string phoneNumber) 
        {
            IdNumber = ID_num;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            State = state;
            Address = address;
            Zip = zip;
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
                    Console.WriteLine($"Customer City: {c.City}");
                    Console.WriteLine($"Customer State: {c.State} ");
                    Console.WriteLine($"Customer Address: {c.Address}");
                    Console.WriteLine($"Customer Zip: {c.Zip}");
                    Console.WriteLine($"Customer PhoneNumber: {c.PhoneNumber}");
                    Console.WriteLine("**********************************");
                }
            }
        }

        /*
         * CreateNewCustomer()
         * 
         * Add a new customer object and adds it to the in-store memory list of customers.
         * The user will input data into the firstName, lastName, city, state, address, zip, and phoneNumber variables. 
         * Error checking is handled by passing the values of firstname and lastname into the CheckName() function, city into the CheckCityName() function,
         * state into the CheckState() function afterwards it will be correctly abbreviatedfor passing into the state parameter of the customer object, 
         * address into the CheckAddress() function, zip into the CheckZipCode function, and finally phoneNumber into the CheckPhoneNumber() function.
         * Once error checking is complete the data is passed into the Customer cosntructor with next_IDnum.
         * The customer object is then added to the list with notification. The variable nextID is incremented by 1.
         * 
         * Parameters: int next_IDnum - id number for the next customer object being created
         * Returns: None
         */
        public void CreateNewCustomer(int next_IDnum)
        {
            string firstName, lastName, city , state, address, zip, phoneNumber; // Initialize all variables with the exception of the id number
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
            Console.WriteLine("Enter Customer City Name:");
            city = Console.ReadLine();
            bool isValidCityName = CheckCityName(city);
            while(!isValidCityName)
            {
                Console.WriteLine("A city name cannot contain any numbers or special characters. Please enter a city name.");
                city = Console.ReadLine();
                isValidCityName = CheckCityName(city);
            }
            Console.WriteLine("Enter Customer State Name (Can be full name or usps abbreviated format):");
            state = Console.ReadLine();
            bool isValidState = CheckState(state);
            while(!isValidState)
            {
                Console.WriteLine("This is not a valid United States state. Please enter your home state. (Can be full name or usps abbreviated format)");
                state = Console.ReadLine();
                isValidState = CheckState(state);
            }
            if (state.Length == 2) // if the user input for state is exactly 2 characters, uppercase them
            {
                state = state.ToUpper();
            }
            if (state.Length > 2) // if the user input is a full state name, even if its entered badly, pass it to the SetStateToAbbrName() function to process and set it to abbreviated format.
            {
                state = SetStateToAbbrName(state);
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
            Console.WriteLine("Enter Customer Zip Code:");
            zip = Console.ReadLine();
            bool isValidZip = CheckZipCode(zip);
            while(!isValidZip) //
            {
                Console.WriteLine("The zip code entered was invalid. A zip code may only contain 5 digits. No letters, spaces or special symbols are allowed. Please enter your Zip Code.");
                zip = Console.ReadLine();
                isValidZip = CheckZipCode(zip);
            }
            Console.WriteLine("Enter Customer Phone Number:");
            phoneNumber = Console.ReadLine();
            bool isValidPhoneNumber = CheckPhoneNumber(phoneNumber); // flag to check if the number is valid
            while (!isValidPhoneNumber)  // while the number is not valid
            {
                Console.WriteLine("The phone number entered is not valid. The phone number must be a total of 10 digits with no letters, spaces or special characters."); // output error message
                phoneNumber = Console.ReadLine(); // get user input 
                isValidPhoneNumber = CheckPhoneNumber(phoneNumber); // call CheckValidPhoneNumber function passing in the user input
            }
            var newCustomer = new Customer(next_IDnum, firstName, lastName, city, state, address, zip, phoneNumber); // make new customer object from inputs
            customers.Add(newCustomer);
            nextID++;
            Console.WriteLine("Customer Added");
        }

        /*
         * CheckValidPhoneNumber()
         * Checks the input to verify if it is a ten digit string. The variable isValid will be returned.
         * If the string is either too long, too short, or contains any letters or special characters, a false value will be assigned to isValid.
         * Otherwise, true will be assigned to isValid.
         * 
         * Parameters: string number - the string input from the user
         * Returns: isValid - flag for phone number validation (True or False)
         */
        public bool CheckPhoneNumber(string number)
        {
            bool isVaild;  // flag 
            if (number.Length == 10)  // Check to see if the length of the string is equal to 10 or 5.
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
                isVaild = false; // set to false if the length of the number is less or more than 10 or 5 characters
            return isVaild; // return the flag
        }

        public bool CheckZipCode(string number)
        {
            bool isVaild;  // flag 
            if (number.Length == 5)  // Check to see if the length of the string is equal to 10 or 5.
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
                isVaild = false; // set to false if the length of the number is less or more than 10 or 5 characters
            return isVaild; // return the flag
        }

        /*
         * CheckName()
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
         * CheckCityName()
         * This function is almost identical to CheckName() with the exception that whitespaces are allowed for input for city names.
         * 
         * Parameters: string name - the name if the string
         * Returns: isValidName - flag for name validation (True or False)
         */
        public bool CheckCityName(string cityName)
        {
            bool isValidCityName = true;  // flag 
                                      // Check if the input contains any characters besides letters and spaces
            if (cityName.Contains('!') || cityName.Contains('@') || cityName.Contains('#') || cityName.Contains('$') || cityName.Contains('%') || cityName.Contains('^') || cityName.Contains('&') ||
                cityName.Contains('&') || cityName.Contains('*') || cityName.Contains('(') || cityName.Contains(')') || cityName.Contains('_') || cityName.Contains('+') || cityName.Contains('-') ||
                cityName.Contains('=') || cityName.Contains('{') || cityName.Contains('}') || cityName.Contains('|') || cityName.Contains(':') || cityName.Contains('"') || cityName.Contains('<') ||
                cityName.Contains('>') || cityName.Contains('?') || cityName.Contains('[') || cityName.Contains(']') || cityName.Contains((char)0x5C) || cityName.Contains(';') ||
                cityName.Contains((char)0X27) || cityName.Contains(',') || cityName.Contains('.') || cityName.Contains('/') || cityName.Contains('0') ||
                cityName.Contains('1') || cityName.Contains('2') || cityName.Contains('3') || cityName.Contains('4') || cityName.Contains('5') || cityName.Contains('5') || cityName.Contains('6') ||
                cityName.Contains('7') || cityName.Contains('8') || cityName.Contains('9'))
                isValidCityName = false; // set to false if it does contain an invalid character
            return isValidCityName; // return the flag
        }

        /*
         * CheckAddress()
         * This function checks the user inputted string name for any type of special characters or numbers.
         * A boolean variable named isValidName is set to true.
         * If there are, the boolean variable isValidName will be set to false.
         * 
         * Parameters: string address - the name if the string
         * Returns: bool isValidAddress - flag for address validation (True or False)
         */
        public bool CheckAddress(string address)
        {
            bool isValidAddress = true;
            // Check if the input contains any special characters or symbols (Letters, Numbers, Whitespaces -> OK)
            if (address.Contains('!') || address.Contains('@') || address.Contains('#') || address.Contains('$') || address.Contains('%') || address.Contains('^') || address.Contains('&') ||
                address.Contains('&') || address.Contains('*') || address.Contains('(') || address.Contains(')') || address.Contains('_') || address.Contains('+') || address.Contains('-') ||
                address.Contains('=') || address.Contains('{') || address.Contains('}') || address.Contains('|') || address.Contains(':') || address.Contains('"') || address.Contains('<') ||
                address.Contains('>') || address.Contains('?') || address.Contains('[') || address.Contains(']') || address.Contains((char)0x5C) || address.Contains(';') ||
                address.Contains((char)0X27) || address.Contains(',') || address.Contains('.') || address.Contains('/'))
                isValidAddress = false; // set to false if it does contain an invalid character
            return isValidAddress;
        }

        /*
         * CheckState()
         * 
         * This function checks to see if the user has entered a valid state via full state name or USPS abbreviation name.
         * A two dimensional array is used to go through each full or abbreviatted name.
         * Depending on the length of the input determines what names will be compared.
         * length > 2 will compare full names while length = 2 will compare abbreviated names.
         * User inputs will be corrected properly before comparing to each element inside the list.
         * 
         * Parameters: string state - user inputted state
         * Returns: bool isValidZip - flag for zip code validation (True or False)
         */
        public bool CheckState(string state)
        {
            bool isValidState = true;  // flag if the input entered is a real state
            // List of States with Full Names and Abbreviated USPS Names
            string[,] statesWithAbs = new string[50, 2] { {"Alabama","AL"} , { "Alaska", "AK" } , { "Arizona", "AZ" } , { "Arkansas", "AR" } , { "California", "CA" } , 
                { "Colorado", "CO" } , { "Connecticut", "CT" } , { "Delaware", "DE" } , { "Florida", "FL" } ,{"Georgia" , "GA"} , {"Hawaii" , "HI"} , {"Idaho" , "ID"} , 
                {"Illinois" , "IL"} , {"Indiana" , "IN"} , {"Iowa" , "IA"} , {"Kansas" , "KS"} , {"Kentucky" , "KY"} , {"Louisiana" , "LA"} , {"Maine" , "ME"} , 
                {"Maryland" , "MD"} , {"Massachusetts" , "MA"} , {"Michigan" , "MI"} ,{"Minnesota" , "MN"} , {"Mississippi" , "MS"} , {"Missouri" , "MO"} , 
                {"Montana" , "MT"} , {"Nebraska" , "NE"} , {"Nevada" , "NV"} , {"New Hampshire" , "NH"} , {"New Jersey" , "NJ"} , {"New Mexico" , "NM"} , 
                {"New York" , "NY"} , {"North Carolina" , "NC"} , {"North Dakota" , "ND"} , {"Ohio" , "OH"} , {" Oklahoma" , "OK"} , {"Orgeon" , "OR"} , {"Pennsylvania" , "PA"} , 
                {"Rhode Island" , "RI"} , {"South Carolina" , "SC"} , {"South Dakota" , "SD"} , {"Tennesee" , "TN"} , {"Texas" , "TX"}, {"Utah" , "UT"} , 
                {"Vermont" , "VT"} , {"Virginia" , "VA"} , {" Washington" , "WA"} , {"West Virginia" , "WV"} , {"Wisconsin" , "WI"} , {"Wyoming" , "WY"} }; 
            int length = state.Length; // length of the input
            if (state.Contains('!') || state.Contains('@') || state.Contains('#') || state.Contains('$') || state.Contains('%') || state.Contains('^') || state.Contains('&') ||
                state.Contains('&') || state.Contains('*') || state.Contains('(') || state.Contains(')') || state.Contains('_') || state.Contains('+') || state.Contains('-') ||
                state.Contains('=') || state.Contains('{') || state.Contains('}') || state.Contains('|') || state.Contains(':') || state.Contains('"') || state.Contains('<') ||
                state.Contains('>') || state.Contains('?') || state.Contains('[') || state.Contains(']') || state.Contains((char)0x5C) || state.Contains(';') ||
                state.Contains((char)0X27) || state.Contains(',') || state.Contains('.') || state.Contains('/') || state.Contains('0') || state.Contains('1') ||
                state.Contains('2') || state.Contains('3') || state.Contains('4') || state.Contains('5') || state.Contains('5') || state.Contains('6') ||
                state.Contains('7') || state.Contains('8') || state.Contains('9')) // Check if the input contains any characters besides letters or whitespaces
                isValidState = false;
            else if (length == 2) //usps abbreviation
            {
                state = state.ToUpper(); // set abbr. uppercase
                int count; // number of times to loop through the elements
                bool found = false; // flag if the match is found
                // Divided list into 2 because total number of elements in all dimensions of stateswithAbs is 100 which will cause an overflow.
                // Need only the second side of each element to compare.
                for (count = 0; count < statesWithAbs.Length/2; count++)
                {
                    if (state == statesWithAbs[count, 1])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No match found...");
                    isValidState = false;
                }
            }
            else  // full state name
            {
                if(state.Contains(' ')) // for states that have 2 words seperated by a whitespace
                {
                    string[] words = state.Split(' '); // split the input into 2 (this is for bad inputs like: NeW HAMPshIrE, NoRTh dAKoTA, etc.)
                    words[0] = words[0].Substring(0, 1).ToUpper() + words[0].Substring(1).ToLower(); // title case the first word
                    words[1] = words[1].Substring(0, 1).ToUpper() + words[1].Substring(1).ToLower(); // title case the second word
                    state = words[0] + " " + words[1]; // contcatenate the two words with the space in between.
                    int count; // number of times to loop through the elements
                    bool found = false; // flag if the match is found
                    // Divided list into 2 because total number of elements in all dimensions of stateswithAbs is 100 which will cause an overflow.
                    // Need only the first side of each element to compare.
                    for (count = 0; count < statesWithAbs.Length / 2; count++) 
                    {
                        if (state == statesWithAbs[count, 0])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        isValidState = false;
                }
                else  //single word states
                {
                    state = state.Substring(0, 1).ToUpper() + state.Substring(1).ToLower(); // title case the word
                    int count; // number of times to loop through the elements
                    bool found = false; // flag if the match is found
                    // Divided list into 2 because total number of elements in all dimensions of stateswithAbs is 100 which will cause an overflow.
                    // Need only the first side of each element to compare.
                    for (count = 0; count < statesWithAbs.Length / 2; count++)
                    {
                        if (state == statesWithAbs[count, 0])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found) // if the found variable is not set to true
                        isValidState = false; // set the isValidState to false.
                }     
            }
            return isValidState;
        }
        /*
         * SetStateToAbbrName()
         * 
         * This function turns any user entered full state input to its abbreviated name equivalent to be inserted into the state property inside the customer object.
         * Function is only called when either making a new customer or updating the state parameter withing the UpdateCustomerInfo() function.
         * 
         * Parameters: string state - user inputted string for the full state name given
         * Returns: string state - the abbreviated state name to be inserted into the state parameter
         */
        public string SetStateToAbbrName(string state)
        { 
            // List of States with Full Names and Abbreviated USPS Names
            string[,] statesWithAbs = new string[50, 2] { {"Alabama","AL"} , { "Alaska", "AK" } , { "Arizona", "AZ" } , { "Arkansas", "AR" } , { "California", "CA" } ,
                { "Colorado", "CO" } , { "Connecticut", "CT" } , { "Delaware", "DE" } , { "Florida", "FL" } ,{"Georgia" , "GA"} , {"Hawaii" , "HI"} , {"Idaho" , "ID"} ,
                {"Illinois" , "IL"} , {"Indiana" , "IN"} , {"Iowa" , "IA"} , {"Kansas" , "KS"} , {"Kentucky" , "KY"} , {"Louisiana" , "LA"} , {"Maine" , "ME"} ,
                {"Maryland" , "MD"} , {"Massachusetts" , "MA"} , {"Michigan" , "MI"} ,{"Minnesota" , "MN"} , {"Mississippi" , "MS"} , {"Missouri" , "MO"} ,
                {"Montana" , "MT"} , {"Nebraska" , "NE"} , {"Nevada" , "NV"} , {"New Hampshire" , "NH"} , {"New Jersey" , "NJ"} , {"New Mexico" , "NM"} ,
                {"New York" , "NY"} , {"North Carolina" , "NC"} , {"North Dakota" , "ND"} , {"Ohio" , "OH"} , {" Oklahoma" , "OK"} , {"Orgeon" , "OR"} , {"Pennsylvania" , "PA"} ,
                {"Rhode Island" , "RI"} , {"South Carolina" , "SC"} , {"South Dakota" , "SD"} , {"Tennesee" , "TN"} , {"Texas" , "TX"}, {"Utah" , "UT"} ,
                {"Vermont" , "VT"} , {"Virginia" , "VA"} , {" Washington" , "WA"} , {"West Virginia" , "WV"} , {"Wisconsin" , "WI"} , {"Wyoming" , "WY"} };

            if (state.Contains(' ')) // if the state has a space in it...
            {
                string[] words = state.Split(' '); // split the input into 2 (this is for bad inputs like: NeW HAMPshIrE, NoRTh dAKoTA, etc.)
                words[0] = words[0].Substring(0, 1).ToUpper() + words[0].Substring(1).ToLower(); // title case the first word
                words[1] = words[1].Substring(0, 1).ToUpper() + words[1].Substring(1).ToLower(); // title case the second word
                state = words[0] + " " + words[1]; // contcatenate the two words with the space in between.
            }
            else
                state = state.Substring(0, 1).ToUpper() + state.Substring(1).ToLower(); // title case the single word

            for (int i = 0; i < statesWithAbs.Length / 2; i++)
            {
                if (state == statesWithAbs[i, 0]) // if full states match
                {
                    state = statesWithAbs[i, 1]; // change the matching full state to its abbreviated state name
                    break;
                }
            }
            return state;
        }

        /*
         * UpdateCustomerInfo()
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
                input = input.ToLower();
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
                    Console.WriteLine($"Customer ID Number: {customers[i].IdNumber}");
                    Console.WriteLine($"Customer First Name: {customers[i].FirstName}");
                    Console.WriteLine($"Customer Last Name: {customers[i].LastName}");
                    Console.WriteLine($"Customer City: {customers[i].City}");
                    Console.WriteLine($"Customer State: {customers[i].State}");
                    Console.WriteLine($"Customer Address: {customers[i].Address}");
                    Console.WriteLine($"Customer Zip Code: {customers[i].Zip}");
                    Console.WriteLine($"Customer PhoneNumber: {customers[i].PhoneNumber}");
                    while (!doneModify)
                    {
                        Console.WriteLine("Is this the record you would like to modify? (Yes / No)");
                        input = Console.ReadLine();
                        input = input.ToLower();
                        if (input == "yes" || input == "y")
                        {
                            bool recordComplete = false;
                            while (!recordComplete)
                            {
                                Console.WriteLine("How would you like to update this record? (All, Some, Cancel)");
                                input = Console.ReadLine();
                                input = input.ToLower();
                                if (input == "all")
                                {
                                    string firstName, lastName, city, state, address, zip, phonenumber;
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
                                    Console.WriteLine("Enter Customer City Name:");
                                    city = Console.ReadLine();
                                    bool isValidCityName = CheckCityName(city);
                                    while (!isValidCityName)
                                    {
                                        Console.WriteLine("A city name cannot contain any numbers or special characters. Please enter a city name.");
                                        city = Console.ReadLine();
                                        isValidCityName = CheckCityName(city);
                                    }
                                    customers[i].City = city;
                                    Console.WriteLine("Enter Customer State Name (Can be full name or usps abbreviated format):");
                                    state = Console.ReadLine();
                                    bool isValidState = CheckState(state);
                                    while (!isValidState)
                                    {
                                        Console.WriteLine("This is not a valid United States state. Please enter your home state. (Can be full name or usps abbreviated format)");
                                        state = Console.ReadLine();
                                        isValidState = CheckState(state);
                                    }
                                    if (state.Length == 2) // for usps inputs
                                    {
                                        state = state.ToUpper();
                                    }
                                    if (state.Length > 2) // for full name inputs
                                    {
                                        state = SetStateToAbbrName(state);
                                    }
                                    customers[i].State = state;
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
                                    Console.WriteLine("Enter Customer Zip Code:");
                                    zip = Console.ReadLine();
                                    bool isValidZip = CheckZipCode(zip);
                                    while (!isValidZip) //
                                    {
                                        Console.WriteLine("The zip code entered was invalid. A zip code may only contain 5 digits. No letters, spaces or special symbols are allowed. Please enter your Zip Code.");
                                        zip = Console.ReadLine();
                                        isValidZip = CheckZipCode(zip);
                                    }
                                    customers[i].Zip = zip;
                                    Console.WriteLine("Enter Customer Phone Number:");
                                    phonenumber = Console.ReadLine();
                                    bool isValidPhoneNumber = CheckPhoneNumber(phonenumber); 
                                    while (isValidPhoneNumber == false)  
                                    {
                                        Console.WriteLine("The phone number entered is not valid. The phone number must be a total of 10 digits with no letters, spaces or special characters. Please input a phone number.");
                                        phonenumber = Console.ReadLine(); 
                                        isValidPhoneNumber = CheckPhoneNumber(phonenumber);
                                        if (isValidPhoneNumber)
                                            customers[i].PhoneNumber = phonenumber;
                                    }
                                    Console.WriteLine("Record Updated!");
                                    recordComplete = true;
                                }
                                else if (input == "some")
                                {
                                    string firstName, lastName, city, state, address, zip, phonenumber;
                                    bool finish = false;
                                    while (!finish)
                                    {
                                        Console.WriteLine("Which part of the record do you want to change? (firstname, lastname, city, state, address, zip, phonenumber)\n" +
                                            "If you need to check the record again, type check. Type done to return to the record select menu.");
                                        input = Console.ReadLine();
                                        input = input.ToLower();
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
                                        else if(input == "city")
                                        {
                                            Console.WriteLine("Enter Customer City Name:");
                                            city = Console.ReadLine();
                                            bool isValidCityName = CheckCityName(city);
                                            while (!isValidCityName)
                                            {
                                                Console.WriteLine("A city name cannot contain any numbers or special characters. Please enter a city name.");
                                                city = Console.ReadLine();
                                                isValidCityName = CheckCityName(city);
                                            }
                                            customers[i].City = city;
                                        }
                                        else if(input == "state")
                                        {
                                            Console.WriteLine("Enter Customer State Name (Can be full name or usps abbreviated format):");
                                            state = Console.ReadLine();
                                            bool isValidState = CheckState(state);
                                            while (!isValidState)
                                            {
                                                Console.WriteLine("This is not a valid United States state. Please enter your home state. (Can be full name or usps abbreviated format)");
                                                state = Console.ReadLine();
                                                isValidState = CheckState(state);
                                            }
                                            if (state.Length == 2) // for usps inputs
                                            {
                                                state = state.ToUpper();
                                            }
                                            if (state.Length > 2) // for full name inputs
                                            {
                                                state = SetStateToAbbrName(state);
                                            }
                                            customers[i].State = state;
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
                                        else if (input == "zip")
                                        {
                                            Console.WriteLine("Enter Customer Zip Code:");
                                            zip = Console.ReadLine();
                                            bool isValidZip = CheckZipCode(zip);
                                            while (!isValidZip) //
                                            {
                                                Console.WriteLine("The zip code entered was invalid. A zip code may only contain 5 digits. No letters, spaces or special symbols are allowed. Please enter your Zip Code.");
                                                zip = Console.ReadLine();
                                                isValidZip = CheckZipCode(zip);
                                            }
                                            customers[i].Zip = zip;
                                        }
                                        else if (input == "phonenumber")
                                        {
                                            Console.WriteLine("Enter Customer Phone Number:");
                                            phonenumber = Console.ReadLine();
                                            bool isValidNumber = CheckPhoneNumber(phonenumber);
                                            while (isValidNumber == false)
                                            {
                                                Console.WriteLine("The phone number entered is not valid. The phone number must be a total of 10 digits with no letters, spaces or special characters. Please input a phone number.");
                                                phonenumber = Console.ReadLine(); 
                                                isValidNumber = CheckPhoneNumber(phonenumber);
                                            }
                                            customers[i].PhoneNumber = phonenumber;
                                        }
                                        else if (input == "check")
                                        {
                                            Console.WriteLine($"Customer ID Number: {customers[i].IdNumber}");
                                            Console.WriteLine($"Customer First Name: {customers[i].FirstName}");
                                            Console.WriteLine($"Customer Last Name: {customers[i].LastName}");
                                            Console.WriteLine($"Customer City: {customers[i].City}");
                                            Console.WriteLine($"Customer State: {customers[i].State}");
                                            Console.WriteLine($"Customer Address: {customers[i].Address}");
                                            Console.WriteLine($"Customer Zip Code: {customers[i].Zip}");
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
                input = input.ToLower();
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
                    Console.WriteLine($"Customer City: {customers[i].City}");
                    Console.WriteLine($"Customer State: {customers[i].State}");
                    Console.WriteLine($"Customer Address: {customers[i].Address}");
                    Console.WriteLine($"Customer Zip Code: {customers[i].Zip}");
                    Console.WriteLine($"Customer PhoneNumber: {customers[i].PhoneNumber}");
                    while (!doneDelete)
                    {
                        Console.WriteLine("Are you sure you want to delete this customer? (Yes / No)");
                        input = Console.ReadLine();
                        input = input.ToLower();
                        if (input == "yes" || input == "y") // Ask a second time.
                        {
                            Console.WriteLine("ARE YOU SURE? Once deleted it's gone forever. (Yes / No)");
                            input = Console.ReadLine();
                            input = input.ToLower();
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

        public void DeleteAllCustomerData()
        {
            Console.WriteLine("Deleting all customer data...");     // Output a message to the user notifying the in memory customer data will be deleted
            customers.Clear();                                      // empty all the customer objects in the list
            nextID = 0;                                             // reset the ID number count (customers in memory) to 0
        }

        public void SaveCustomerListToFile()
        {
            string input; // input line
            string original_FileName = ""; // string for the file name
            bool doneSave = false;
            while (!doneSave) // loop block statement to continue executing when a file hasn't been saved yet...
            {
                Console.WriteLine("Please enter the file name to save the current customer records to.");
                original_FileName = Console.ReadLine();
                if (original_FileName.EndsWith(".dat") || original_FileName.EndsWith(".txt")) // Check if the file name ends with .dat or .txt extension type
                {
                    if (File.Exists(@original_FileName)) // Check if the file exists...
                    {
                        Console.WriteLine($"The file {original_FileName} already exists. Do you want to overwrite this file? (Yes / No)"); // Ask if the file entered wants to be overwritten
                        input = Console.ReadLine();  // read input
                        input = input.ToLower();    // lowercase the input
                        if (input == "yes" || input == "y") // if yes, then overwrite the file
                        {
                            try
                            {
                                Console.WriteLine($"Overwriting {original_FileName}...");
                                FileStream file = new FileStream(original_FileName, FileMode.Create, FileAccess.Write); // Open a new file to create and write to
                                StreamWriter sw = new StreamWriter(file);   // Create a stream writer for the file
                                sw.WriteLine($"************ {original_FileName} Created:" + System.DateTime.Now + "***********");
                                foreach (Customer c in customers)  // for each customer object c in the list
                                {
                                    sw.WriteLine($"{c.IdNumber}|{c.FirstName}|{c.LastName}|{c.City}|{c.State}|{c.Address}|{c.Zip}|{c.PhoneNumber}"); //write all data within each object per line seperated by the pipe symbol '|'.
                                }
                                sw.WriteLine("************End-of-File************");
                                sw.Flush();
                                sw.Dispose();
                                sw.Close();
                                Console.WriteLine("File has been saved. Check the file within the directory of the program.");
                                doneSave = true;  // set to true to get out of the file save loop
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("File could not be saved..." + e.Message);
                            }
                        }
                        else if (input == "no") // if no, ask user if they want to save the list of customers under a new file name.
                        {
                            bool redo = true;
                            while(redo) // loop to ask if they want to save under new file name, loop will continue until yes or no is entered
                            {
                                Console.WriteLine("Do you want to enter a different file name?");
                                input = Console.ReadLine();
                                input = input.ToLower();
                                if (input == "yes" || input == "y") // if yes then redo the section for the file name input
                                {
                                    redo = false; // get out of the redo loop
                                }
                                else if (input == "no" || input == "n") // if no, then return to the main menu
                                {
                                    redo = false; // get out of redo loop
                                    doneSave = true; // get out of file save loop
                                }
                                else
                                {
                                    Console.WriteLine("Please enter yes or no if you want to enter a different file name.");
                                }
                            }
                        }
                    }
                    else // if the file doesn't exist...
                    {
                        Console.WriteLine($"Now creating: {original_FileName}");
                        try
                        {
                            FileStream file = new FileStream(original_FileName, FileMode.Create, FileAccess.Write); // Open a new file to create and write to
                            StreamWriter sw = new StreamWriter(file);   // Create a stream writer for the file
                            sw.WriteLine($"************ {original_FileName} Created:" + System.DateTime.Now + "***********");
                            foreach (Customer c in customers)
                            {
                                sw.WriteLine($"{c.IdNumber}|{c.FirstName}|{c.LastName}|{c.City}|{c.State}|{c.Address}|{c.Zip}|{c.PhoneNumber}"); //write all data within each object per line seperated by the pipe symbol '|'.
                            }
                            sw.WriteLine("************End-of-File************");
                            sw.Flush();
                            sw.Dispose();
                            sw.Close();
                            Console.WriteLine("File has been saved. Check the file within the directory of the program.\n");
                            doneSave = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("File could not be saved..." + e.Message);
                        }
                    }
                }
                else // the user entered file doesn't end with the .dat, .txt. or .bin
                {
                    bool flag = false; // flag for invalid inputs
                    Console.WriteLine($"The file name entered: {original_FileName} does not contain the .txt or .dat extension. Would you like to enter a different file name? (Yes / No)");
                    while (!flag)
                    {               
                        input = Console.ReadLine();
                        input = input.ToLower();
                        if (input == "yes" || input == "y")
                        {
                            flag = true;
                        }
                        else if (input == "no" || input == "n")
                        {
                            Console.WriteLine("Returning to Main Menu.");
                            doneSave = true;
                            flag = true;
                        }
                        else
                            Console.WriteLine("Invalid input. Would you like to enter a different file name? (Yes / No)");
                    }
                }
            }
        }

        public void LoadCustomerListfromFile(string fileName)
        {
            string[] linesFromText = System.IO.File.ReadAllLines(fileName); // open the file and read all lines
            bool allRead = true; // flag if all the lines have been read without any issues
            Console.WriteLine($"nextID value: {nextID}"); // output the value of the nextID variable
            for (int i = 0; i < linesFromText.Length; i++)  // check each line to see of they contain the | symbol
            {
                if(linesFromText[i].Contains('|')) // if the line does contain a pipe symbol
                {
                    string[] data = linesFromText[i].Split('|'); // split the data using the pipe '|' symbols as the seperator
                    int idNumber;  // data for int id number
                    string firstName, lastName, city, state, address, zipCode, phoneNumber; // data for string 
                    bool isParsable = int.TryParse(data[0], out idNumber); // try to parse the id number
                    if (isParsable) // if the id is parseable...
                    {
                        // parse all data into their perspective attributes
                        firstName = data[1];
                        lastName = data[2];
                        city = data[3];
                        state = data[4];
                        address = data[5];
                        zipCode = data[6];
                        phoneNumber = data[7];
                        var loadCustomer = new Customer(idNumber, firstName, lastName, city, state, address, zipCode, phoneNumber); // load into a new customer object
                        customers.Add(loadCustomer); // add the customer to the list
                        nextID++; // increment to match size of the list for the next unique ID for each customer loaded.
                        Console.WriteLine($"nextID value: {nextID}"); // output the value of the nextID variable
                        // continue until all lines have processed
                    }
                    else
                        allRead = false;
                }
            }
            if (!allRead)
            {
                Console.WriteLine("An error occurred when reading one of the lines. " +
                    "Please check the file for any out-of-place data that may interfere with loading the file.");
            }
        }
    }  
}
