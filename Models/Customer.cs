using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SlutuppgiftDatabasLotta.Models
{
    public class Customer
    {
        public int CardNumber { get; set; }
     
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
       
        public ICollection<Customer_Book> Customer_Book { get; set; }
    }
}
