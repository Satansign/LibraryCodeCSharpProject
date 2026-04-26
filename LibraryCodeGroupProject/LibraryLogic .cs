using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// This file is caling from menu and having the logic for the library management system. We will put all our logic for adding, removing and viewing books, customers and loans here. We will also have some helper methods for validating input and other common tasks.

namespace LibraryCodeGroupProject
{
    public class LibraryLogic 
    { 
        private List<Book> books;
        private List<Customer> customers;
        
        public LibraryLogic()
        {
            books = new List<Book>();
            customers = new List<Customer>();
        }
        public list <Book> GetBooks()
        {
            return books;
        }
        public List<Customer> GetCustomers()
        {
            return customers;
        }

    }
}
// The logic is not complete yet, we will add methods for adding, removing and viewing books, customers and loans. We will also add some helper methods for validating input and other common tasks.
// is going to be more complete in the future, we will add more methods and logic as we go along. We will also add some error handling and validation to make sure the program runs smoothly.
