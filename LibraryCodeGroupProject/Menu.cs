using System;
using System.Collections.Generic;
using System.Numerics;

namespace LibraryCodeGroupProject
{
    public class Menu
    {
        private LibraryLogic LibraryLogic = new LibraryLogic();   //I first missed to create an instance of the LibraryLogic class,
                                                                  //but now we have it and we can use it to call the methods for adding, removing and viewing books, customers and loans.


        public void DisplayMenu()
        {
                Console.Clear();        // I addd this code to clear the window every time we display the menu
                Console.WriteLine("*********************************************************************************");
                Console.WriteLine("    Welcome to the Library Management System by Ellinor, Andreas, and Mattis!");
                Console.WriteLine("*********************************************************************************");
                // Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Customers");
                Console.WriteLine("3. Loans");
                Console.WriteLine("4. Exit");
                Console.WriteLine(" ");
                Console.Write("Please select an option (1-4): ");
                
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
            Console.WriteLine("*** Books Menu ***");
            Console.WriteLine(" ");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. View Books");
            Console.WriteLine("4. Back to Main Menu");
            string bookChoice = Console.ReadLine();
             
            switch (bookChoice) 
                {
                case "1":
                    // Handle add book logic here
                    AddBookMenu(); 
                    break;

                case "2":
                    // Handle remove book logic here
                    break;
                case "3":
                    // Handle view books logic here
                    ViewBooksMenu();
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
        private void AddBookMenu()
        {
            Console.Write("Title: ");
             string title = Console.ReadLine();

             Console.Write("Author: ");
             string author = Console.ReadLine();

             Console.Write("ISBN: ");
             string isbn = Console.ReadLine(); 

            Book newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                IsAvailable = true
            };
            LibraryLogic.AddBook(newBook);
            Console.WriteLine("Book added successfully!");
          //  Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            ShowBookMenu();
        }
        
        private void ViewBooksMenu()
            {
            Console.WriteLine("Books in the library:");
            List<Book> books = LibraryLogic.GetBooks();
            Console.WriteLine("Title            | Author                  | ISBN");
            foreach (Book book in books)
            {
                Console.Write(book.Title);
                    for (int i = book.Title.Length; i < 20; i++)
                    {
                    Console.Write(" "); //To even out the properties in the list evenly
                    }
                Console.Write("  | " + book.Author);
                     for (int i = book.Author.Length; i < 20; i++)
                     {
                    Console.Write(" ");
                     }
                Console.WriteLine("  |" + book.ISBN);
            }

          //  Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            ShowBookMenu();

        }
        

        private void ShowCustomerMenu()
        {
            Console.WriteLine("*** Customers Menu ***");
            Console.WriteLine(" ");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Remove Customer");
            Console.WriteLine("3. View Customers");
            Console.WriteLine("4. Back to Main Menu");
            string customerChoice = Console.ReadLine();
            
            switch (customerChoice)
            {
                case "1":
                    // Handle add customer logic here
                    Console.Write("Customer name: ");
                    string cName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(cName))
                    {
                        Console.Write("Customer ID: ");
                        string cID = Console.ReadLine();
                        if (!string.IsNullOrEmpty(cID))
                        {
                            Customer newCustomer = new Customer
                            {
                                CustomerName = cName,
                                CustomerID = cID
                            };
                            LibraryLogic.AddCustomer(newCustomer);
                            ShowCustomerMenu();
                        }
                    }
                    Console.WriteLine("Can't be empty. Please try again.");
                    ShowCustomerMenu();
                    break;
                case "2":
                    // Handle remove customer logic here
                    Console.WriteLine("Customer ID you want to remove: ");
                    List<Customer> customerDeletion = LibraryLogic.GetCustomers();
                    string cSearch = Console.ReadLine();
                    if (!string.IsNullOrEmpty(cSearch))
                    {
                        var cDeletion = customerDeletion.Find(x => x.CustomerID.Equals(cSearch)); //Searching for the ID that was written.
                        Console.WriteLine($"{cDeletion.CustomerName} has been removed from the system.");
                        LibraryLogic.RemoveCustomer(cDeletion);
                        ShowCustomerMenu();
                    }
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowCustomerMenu();
                    break;
                case "3":
                    // Handle view customers logic here
                    Console.WriteLine("Viewing all customers");
                    Console.WriteLine("Customer            | ID                  | Books loaned");
                    List<Customer> customers = LibraryLogic.GetCustomers();
                    foreach (Customer customer in customers)
                    {
                        Console.Write(customer.CustomerName);
                        for (int i = customer.CustomerName.Length; i < 20; i++)
                        {
                            Console.Write(" "); //To even out the properties in the list evenly
                        }
                        Console.Write("| " + customer.CustomerID);
                        for (int i = customer.CustomerID.Length; i < 20; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine($"| {customer.LoanedBooks}");  // Nothing visible yet.
                    }
                    ShowCustomerMenu();
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
            Console.WriteLine("*** Loans Menu ***");
            Console.WriteLine(" ");
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

// -------------------------
//    Development Notes
// -------------------------
//
// The menu file is not complete. Now i going to do the logic in the LibraryLogic file and then come back to the menu to connect it to the logic. I want to do this because i want to have a clear separation between the menu and the logic. This way we can easily change the menu without affecting the logic and vice versa.
// Please add your opinons in the menu file.
// Jag har börjat bygga ut så vi har en liknade logic i våra filer. Ni kan ändra och lägga till det ni känner för. 