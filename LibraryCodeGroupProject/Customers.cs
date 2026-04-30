using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCodeGroupProject
{
    public class Customer
    {
        public string Name { get; set; }
        public string customerID { get; set; }
        public List<LoanedBooks> loanedBooks { get; set; }
    }
    public class LoanedBooks
    {
        public string loaned { get; set; }
    }
}
