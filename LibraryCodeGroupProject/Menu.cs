using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;

namespace LibraryCodeGroupProject
{
    public class Menu
    {
        private LibraryLogic LibraryLogic = new LibraryLogic();   //I first missed to create an instance of the LibraryLogic class,
        private bool running;

        //but now we have it and we can use it to call the methods for adding, removing and viewing books, customers and loans.


        public void DisplayMenu()
        {
            Console.Clear();        // I addd this code to clear the window every time we display the menu
            Console.WriteLine(" ");
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
                    break;
                default:
                    Console.Write("Invalid choice. Please press Enter to try again.");
                    Console.ReadLine();
                    DisplayMenu();
                    break;
            }

        }
        // Here we put all our diffrent menu options for Books, Customers and Loans. We also have an option to exit the program.
        private void ShowBookMenu()
        {
            Console.Clear();                             // Clear the console to make it look cleaner when we enter the book menu.
            Console.WriteLine(" ");
            Console.WriteLine("*** Books Menu ***");
            Console.WriteLine(" ");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. View Books");
            Console.WriteLine("4. Back to Main Menu");
            Console.WriteLine(" ");
            Console.Write("Please select an option (1-4): ");
            string bookChoice = Console.ReadLine();

            switch (bookChoice)
            {
                case "1":
                    // Handle add book logic here
                    AddBookMenu();
                    break;
                case "2":
                    // Handle remove book logic here
                    RemoveBookMenu();
                    break;
                case "3":
                    // Handle view books logic here
                    ViewBooksMenu();
                    break;
                case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.Write("Invalid choice. Please press Enter to try again. ");
                    Console.ReadLine();
                    ShowBookMenu();
                    break;
            }
        }
        // Here we put all our diffrent menu options for Books
        private void AddBookMenu()
        {
            Console.Clear();
            Console.WriteLine("Please write the book's title, author and ISBN-number.");
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(isbn))
            {
                Console.Write("All fields are required. Please press Enter to try again. ");
                Console.ReadLine();
                ShowBookMenu();
                return;
            }

            Book newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                IsAvailable = true
            };
            LibraryLogic.AddBook(newBook);
            Console.WriteLine("Book added successfully!");
            Console.WriteLine(" ");
            Console.Write("Press Enter to go back to the Books Menu. ");
            Console.ReadLine();
            ShowBookMenu();
        }

        private void RemoveBookMenu()
        {
            Console.Clear();
            Console.WriteLine("Please write the ISBN-number of the book you want to remove. ");

            List<Book> Books = LibraryLogic.GetBooks(); //Hämtar listan med alla böcker från LibraryLogic 
            // eftersom boklistan finns sparad i LibraryLogic
            Console.Write("Write ISBN: ");
            string isbnToRemove = Console.ReadLine(); //Sparar det isbn som användaren sa i variabeln isbnToRemove
            Book bookToRemove = Books.Find(book => book.ISBN == isbnToRemove);  //Söker i listan books efter en bok med angivet isbn
                                                                                // om ingen bok hittas blir bookToRemove null 

            if (bookToRemove == null)  //kollar om ingen bok hittades
            {
                Console.WriteLine("Book not found. Please press Enter to try again. ");
            }
            else
            {
                Books.Remove(bookToRemove); //om en bok isbn hittades så tas den bort från listan
                                            // LibraryLogic.RemoveBook(bookToRemove);
                Console.WriteLine($"Book with ISBN {isbnToRemove} has been removed successfully!");
                Console.Write("Press Enter to go back to Book menu. ");
            }
            Console.ReadLine();
            ShowBookMenu(); //skickar tillbaks användaren till Book-menun
        }

        private void ViewBooksMenu()
        {
            Console.Clear();                             // Clear the console to make it look cleaner when we enter the book menu.
            Console.WriteLine(" ");
            Console.WriteLine("*** BOOKS IN THE LIBRARY ***");
            Console.WriteLine(" ");
            List<Book> books = LibraryLogic.GetBooks();
            Console.WriteLine("Title                         | Author                        | ISBN ");
            foreach (Book book in books)
            {
                Console.Write(book.Title);
                for (int i = book.Title.Length; i < 30; i++)
                {
                    Console.Write(" "); //To even out the properties in the list evenly
                }
                Console.Write("| " + book.Author);
                for (int i = book.Author.Length; i < 30; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("| " + book.ISBN);
            }

            Console.WriteLine(" ");
            Console.Write("Press Enter to go back to the Books Menu. ");
            Console.ReadLine();
            ShowBookMenu();
        }

        private void ShowCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Customers Menu ***");
            Console.WriteLine(" ");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Remove Customer");
            Console.WriteLine("3. View Customers");
            Console.WriteLine("4. Back to Main Menu");
            Console.WriteLine(" ");
            Console.Write("Please select an option (1-4): ");
            string customerChoice = Console.ReadLine();
            
            switch (customerChoice)
            {
                case "1":
                    Console.Clear();                             // Clear the console to make it look cleaner when we enter the book menu.
                    Console.WriteLine("Write name and ID for the customer you want to add.");
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
                            Console.WriteLine("Customer added successfully!");
                            Console.Write("Press Enter to go back to the Customer Menu. ");
                            Console.ReadLine();
                            ShowCustomerMenu();
                            return;
                        }

                    }
                    Console.Write("Can't be empty. Please press Enter to try again. ");
                    Console.ReadLine();
                    ShowCustomerMenu();
                    break;
                case "2":
                    // Handle remove customer logic here
                    Console.Clear();                             // Clear the console to make it look cleaner when we enter the book menu.
                    Console.WriteLine(" ");
                    Console.WriteLine("Customer ID you want to remove: ");
                    List<Customer> customerDeletion = LibraryLogic.GetCustomers();
                    string cSearch = Console.ReadLine();
                    if (!string.IsNullOrEmpty(cSearch))
                    {
                        var cDeletion = customerDeletion.Find(x => x.CustomerID.Equals(cSearch)); //Searching for the ID that was written.
                        if (cDeletion == null)
                        {
                            Console.WriteLine("Customer not found. Please press Enter to try again.");
                            Console.ReadLine();
                            ShowCustomerMenu();
                            return;
                        }
                        Console.WriteLine($"{cDeletion.CustomerName} has been removed from the system.");
                        Console.Write("Press Enter to go back to the Customer Menu. ");
                        LibraryLogic.RemoveCustomer(cDeletion);
                        Console.ReadLine();
                        ShowCustomerMenu();
                        return;
                    }
                    Console.Write("Invalid choice. Please press Enter to try again.");
                    ShowCustomerMenu();
                    break;
                case "3":
                    // Handle view customers logic here
                    Console.Clear();                             // Clear the console to make it look cleaner when we enter the book menu.
                    Console.WriteLine(" ");
                    Console.WriteLine("Viewing all customers");
                    Console.WriteLine(" ");
                    Console.WriteLine("Customer                      | ID                  ");
                    List<Customer> customers = LibraryLogic.GetCustomers();
                    foreach (Customer customer in customers)
                    {
                        Console.Write(customer.CustomerName);
                        for (int i = customer.CustomerName.Length; i < 30; i++)
                        {
                            Console.Write(" "); //To even out the properties in the list evenly
                        }
                        Console.WriteLine("| " + customer.CustomerID);

                    }
                    Console.WriteLine(" ");
                    Console.Write("Press Enter to go back to the Customer Menu. ");
                    Console.ReadLine();
                    ShowCustomerMenu();
                    break;
                case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.Write("Invalid choice. Please press Enter to try again. ");
                    Console.ReadLine();
                    ShowCustomerMenu(); 
                    break;
            }

        }
        // Here we put all our diffrent menu options for Loans

        private void ShowLoanMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Loans Menu ***");
            Console.WriteLine(" ");
            Console.WriteLine("1. Add Loan");
            Console.WriteLine("2. Return Loan");
            Console.WriteLine("3. View Loans");
            Console.WriteLine("4. Back to Main Menu");
            Console.WriteLine(" ");
            Console.Write("Please select an option (1-4): ");
            string loanChoice = Console.ReadLine();

            switch (loanChoice)
            {
                case "1":
                    AddLoanMenu();
                    // Handle add loan logic here
                    break;
                case "2":
                    ReturnLoanMenu();
                    // Handle return loan logic here
                    break;
                case "3":
                    ViewLoansMenu();
                    // Handle view loans logic here
                    break;
                case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.Write("Invalid choice. Please press Enter to try again. ");
                    Console.ReadLine();
                    ShowLoanMenu();
                    break;
            }
        }
        private void AddLoanMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Adding a new loan ***");
            Console.WriteLine(" ");

            Console.WriteLine("Please write the ISBN of the book you want to loan and the ID of the customer who wants to loan it.");
            Console.WriteLine();

            bool foundAvailableBooks = ShowAvailableBooksMenu();
            if (!foundAvailableBooks)
            {
                Console.WriteLine("No available books to loan. Press Enter to go back to the Loans Menu.");
                Console.ReadLine();
                ShowLoanMenu();
                return;
            }
            bool foundCustomers = ShowCustomersForLoanMenu();
            if (!foundCustomers)
            {
                Console.WriteLine("No customers found. Press Enter to go back to the Loans Menu.");
                Console.ReadLine();
                ShowLoanMenu();
                return;
            }
            Console.WriteLine(" "); 
            Console.Write("Book ISBN: ");
            string bookISBN = Console.ReadLine();
            Console.Write("Customer ID: ");
            string customerID = Console.ReadLine();
            string loanResult = LibraryLogic.LoanBook(customerID, bookISBN);
            Console.WriteLine(loanResult);
            Console.WriteLine(" ");
            Console.Write("Press Enter to go back to the Loans Menu. ");
            Console.ReadLine();
            ShowLoanMenu();
        }

        private void ReturnLoanMenu()
        {
            Console.Clear();
            Console.WriteLine("Returning a loan.");
            Console.WriteLine(" ");
            Console.WriteLine("Please write the ISBN of the book you want to return and the ID of the customer who wants to return it.");
            Console.Write("Book ISBN: ");
            string bookISBN = Console.ReadLine();
            Console.Write("Customer ID: ");
            string customerID = Console.ReadLine();
            string returnResult = LibraryLogic.ReturnBook(customerID, bookISBN);
            Console.WriteLine(returnResult);
            Console.WriteLine(" ");
            Console.Write("Press Enter to go back to the Loans Menu. ");
            Console.ReadLine();
            ShowLoanMenu();
        }
        private void ViewLoansMenu()
        {
            Console.Clear();
            Console.WriteLine("Viewing all loans.");
            Console.WriteLine(" ");
            List<Customer> customers = LibraryLogic.GetCustomers();
            bool foundloan = false;
            foreach (Customer customer in customers)
            {
                if (customer.LoanedBooks.Count > 0)
                {
                    foundloan = true;
                    Console.WriteLine($"Customer: {customer.CustomerName} (ID: {customer.CustomerID}) has loaned the following books:");
                    foreach (Book book in customer.LoanedBooks)
                    {
                        Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN})");
                    }
                    Console.WriteLine(" ");
                }
            }
            if (!foundloan)
            {
                Console.WriteLine("No loans found.");
            }

            Console.WriteLine(" ");
            Console.Write("Press Enter to go back to the Loans Menu. ");
            Console.ReadLine();
            ShowLoanMenu();
        }

        // Here we put all our diffrent menu options for Loans

        // Handle exit choice here
        private void ShowExit()
        {
            Console.Clear();                             // Clear the console to make it look cleaner when we enter the book menu.
            Console.WriteLine(" ");
            Console.WriteLine("Exiting the program. Goodbye!");
        }

        private bool ShowAvailableBooksMenu()
        {
            List<Book> books = LibraryLogic.GetBooks();
            bool foundAvailableBooks = false;
            Console.WriteLine("Available Books:");
            Console.WriteLine("Title                         | Author                        | ISBN ");
            foreach (Book book in books)
            {
                if (book.IsAvailable)
                {
                    foundAvailableBooks = true;
                    Console.Write(book.Title);
                    for (int i = book.Title.Length; i < 30; i++)
                    {
                        Console.Write(" "); //To even out the properties in the list evenly
                    }
                    Console.Write("| " + book.Author);
                    for (int i = book.Author.Length; i < 30; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("| " + book.ISBN);
                }
            }
            if (!foundAvailableBooks)
            {
                Console.WriteLine("No available books found.");
            }
            Console.WriteLine(" ");
            return foundAvailableBooks;
        }


        private bool ShowCustomersForLoanMenu()
        {
            List<Customer> customers = LibraryLogic.GetCustomers();
            bool foundCustomers = false;
            Console.WriteLine("Customers:");
            Console.WriteLine("Customer                      | ID");
            Console.WriteLine("------------------------------|------------------------------");
            foreach (Customer customer in customers)
            {
                foundCustomers = true;
                Console.Write(customer.CustomerName);
                for (int i = customer.CustomerName.Length; i < 30; i++)
                {
                    Console.Write(" "); //To even out the properties in the list evenly
                }
                Console.WriteLine("| " + customer.CustomerID);
            }
            if (!foundCustomers)
            {
                Console.WriteLine("No customers found.");
            }
            return foundCustomers;
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