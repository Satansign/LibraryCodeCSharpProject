using LibraryCodeGroupProject;
using System;
using System.Collections.Generic;

namespace LibraryCodeGroupProject
{
    public class Customer
    {
        public string CustomerName { get; set; }    // Customer's full name
        public string CustomerID { get; set; }  // Unique identifier
        public List<Book> LoanedBooks { get; set; }= new List<Book>();  // List of books currently loaned
    }
    public class LoanedBooks
    {
        public string Loaned { get; set; }  // List of books currently loaned
    }
}
