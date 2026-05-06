using System;                           
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// The menu calls this file (LibraryLogic.cs) for having the logic for the library management system. 
// We will put all our logic for adding, removing and viewing books, customers and loans here.
// We will also have some helper methods for validating input and other common tasks.

namespace LibraryCodeGroupProject
{
    public class LibraryLogic 
    { 
        private List<Book> Books;           // Stores all books during runtime
        private List<Customer> Customers;   // Stores all customers during runtime

        public LibraryLogic()
        {
            Books = new List<Book>();       // empty lists when the program starts
            Customers = new List<Customer>();
        }
        public List<Book> GetBooks()        // Returns current list of books
        {
            return Books;
        }
        public List<Customer> GetCustomers()
        {
            return Customers;               // Returns current list of customers
        }

    }
}

// -------------------------
//    Development Notes
// -------------------------
//
// The logic is not complete yet, we will add methods for adding, removing and viewing books, customers and loans. 
// We will also add some helper methods for validating input and other common tasks.
// is going to be more complete in the future, we will add more methods and logic as we go along. 
//We will also add some error handling and validation to make sure the program runs smoothly.
// bra jobbat Andreas. Ellinor och Mattis har kikat tillsammans, vi återkommer med mer