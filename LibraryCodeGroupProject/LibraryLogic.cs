using System;                           
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
// The menu calls this file (LibraryLogi.cs) for having the logic for the library management system. 
// We will put all our logic for adding, removing and viewing books, customers and loans here.
// We will also have some helper methods for validating input and other common tasks.

namespace LibraryCodeGroupProject
{
    public class LibraryLogic
    {
        private List<Book> books;           // Stores all books during runtime
        private List<Customer> customers;   // Stores all customers during runtime

        public LibraryLogic()
        {
            books = new List<Book>();       // empty lists when the program starts
            customers = new List<Customer>();
        }
        public List<Book> GetBooks()        // Returns current list of books
        {
            return books;
        }
        public List<Customer> GetCustomers()
        {
            return customers;               // Returns current list of customers
        }
        public void AddBook(Book book)     // Add a book to the list book
        {
            books.Add(book);
        }

        public void AddCustomer(Customer customer)     // Add a customer to the list Customer
        {
            customers.Add(customer);
        }
        public void RemoveCustomer(Customer customer)     // Remove a customer from the list Customer
        {
            customers.Remove(customer);
        }

        public string LoanBook(string customerID, string bookISBN)  // Loan a book to a customer
        {
            if (string.IsNullOrWhiteSpace(customerID) || string.IsNullOrWhiteSpace(bookISBN))
            {
                return "Invalid input: Customer ID and Book ISBN cannot be empty.";
            }
            Customer customer = FindCustomerByID(customerID);
            if (customer == null)
            {
                return "Customer not found.";
            }
            Book book = FindBookByISBN(bookISBN);
            if (book == null)
            {
                return "Book not found.";
            }
            if (!book.IsAvailable)
            {
                return "Book is currently not available.";
            }
            book.IsAvailable = false;   // Mark the book as loaned
            customer.LoanedBooks.Add(book);    // Add the book to the customer's loaned books
            return "Book loaned successfully.";
        }


        public string ReturnBook(string customerID, string bookISBN)
           
        {
            if (string.IsNullOrWhiteSpace(customerID) || string.IsNullOrWhiteSpace(bookISBN))
            {
                return "Invalid input: Customer ID and Book ISBN cannot be empty.";
            }
            Customer customer = FindCustomerByID(customerID);

            if (customer == null)
            {
                return "Customer not found.";
            }
            Book book = FindBookByISBN(bookISBN);
            if (book == null)
            {
                return "Book not found.";
            }
            if (!customer.LoanedBooks.Contains(book))
            {
                return "This book was not loaned to this customer.";
            }
            book.IsAvailable = true;    // Mark the book as available
            customer.LoanedBooks.Remove(book);   // Remove the book from the customer's loaned books
            return "Book returned successfully.";
        }    
    public List<Book> GetCustomerLoans(string customerID)  // Get a list of books loaned by a customer
        {
            Customer customer = FindCustomerByID(customerID);
            if (customer == null)
            {
                return null;    // Customer not found
            }
            return customer.LoanedBooks;   // Return the list of loaned books
        }
        private Book FindBookByTitle(string title)     // Find a book by its title
        {
            return books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        private Customer FindCustomerByID(string customerID)     // Find a customer by their ID
        {
            return customers.FirstOrDefault(c => c.CustomerID.Equals(customerID, StringComparison.OrdinalIgnoreCase));
        }
        private Book FindBookByISBN(string isbn)     // Find a book by its ISBN
        {
            return books.FirstOrDefault(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
        }
    }
}
// ------------------------
//    Development Notes
// -------------------------
//
// The logic is not complete yet, we will add methods for adding, removing and viewing books, customers and loans. 
// We will also add some helper methods for validating input and other common tasks.
// is going to be more complete in the future, we will add more methods and logic as we go along. 
//We will also add some error handling and validation to make sure the program runs smoothly.
// bra jobbat Andreas. Ellinor och Mattis har kikat tillsammans, vi återkommer med mer