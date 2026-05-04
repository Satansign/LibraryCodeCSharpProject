using LanguageExt;
using LanguageExt.TypeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCodeGroupProject
{
    public class Menu
    {


        public void DisplayMenu()
        {
            


                Console.WriteLine("Welcome to the Library Management System!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Customers");
                Console.WriteLine("3. Loans");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine();




                switch (choice)
                {
                    case "1":
                        ShowBookMenu();
                        break;
                    case "2":
                        ShowCustomerMenu();
                        break;
                    case "3":
                        ShowLoanMenu();
                        break;
                    case "4":
                        ShowExit();
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            
        }
    
        


        // Here we put all our diffrent menu options for Books, Customers and Loans. We also have an option to exit the program.
        private void ShowBookMenu()
        {
            Console.WriteLine("Books Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. View Books");
            Console.WriteLine("4. Back to Main Menu");
            string bookChoice = Console.ReadLine();
             
            switch (bookChoice) 
                {
                case "1":
                    // Handle add book logic here
                    break;
                case "2":
                    // Handle remove book logic here
                    break;
                case "3":
                    // Handle view books logic here
                    break;
                case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        // Here we put all our diffrent menu options for Books
        private void ShowCustomerMenu()
        {
            Console.WriteLine("Customers Menu:");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Remove Customer");
            Console.WriteLine("3. View Customers");
            Console.WriteLine("4. Back to Main Menu");
            string customerChoice = Console.ReadLine();
            
            switch (customerChoice)
            {
                case "1":
                    // Handle add customer logic here
                    break;
                case "2":
                    // Handle remove customer logic here
                    break;
                case "3":
                    // Handle view customers logic here
                    break;
                case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
        // Here we put all our diffrent menu options for Loans

        private void ShowLoanMenu()
        {
            Console.WriteLine("Loans Menu:");
            Console.WriteLine("1. Add Loan");
            Console.WriteLine("2. Remove Loan");
            Console.WriteLine("3. View Loans");
            Console.WriteLine("4. Back to Main Menu");
            string loanChoice = Console.ReadLine();
            
            switch(loanChoice) 
                {
                case "1":
                    // Handle add loan logic here
                    break;
                case "2":
                    // Handle remove loan logic here
                    break;
                case "3":
                    // Handle view loans logic here
                    break;
                case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        // Here we put all our diffrent menu options for Loans

            // Handle exit choice here
        private void ShowExit()
        {
            Console.WriteLine("Exiting the program. Goodbye!");
        }
    }
}

// The menu file is not complete. Now i going to do the logic in the LibraryLogic file and then come back to the menu to connect it to the logic. I want to do this because i want to have a clear separation between the menu and the logic. This way we can easily change the menu without affecting the logic and vice versa.
// Please add your opinons in the menu file.


// Jag har börjat bygga ut så vi har en liknade logic i våra filer. Ni kan ändra och lägga till det ni känner för. 