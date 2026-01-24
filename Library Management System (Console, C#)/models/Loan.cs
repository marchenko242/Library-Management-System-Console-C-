using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Loan
    {

        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime LoanDate { get; set; }
        public bool IsReturned { get; set; }

    }
}
