using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Services
{
    public class LoanService
    {
        public void BorrowBook(List<Reader> readers, List<Book> books, List<Loan> loans)
        {

            Console.WriteLine("Enter id of book: ");
            string bookInputID = Console.ReadLine();
            
            if (!int.TryParse(bookInputID, out int bookID))
            {
                Console.WriteLine("Invalid book id.");
                return;
            }


            Book selectedBook = null;

            foreach (Book b in books)
            {
                if (b.Id == bookID)
                {
                    selectedBook = b;
                    break;
                }
            }

            if(selectedBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            //-------

            Console.WriteLine("Enter id of reader: ");
            string readerInputID = Console.ReadLine();

            if (!int.TryParse(readerInputID, out int readerID))
            {
                Console.WriteLine("Invalid reader id.");
                return;
            }

            Reader selectedReader = null;

            foreach (Reader r in readers)
            {
                if(r.Id == readerID)
                {
                    selectedReader = r;
                    break;
                }
            }

            if(selectedReader == null)
            {
                Console.WriteLine("Reader not found.");
                return;
            }





        }



    }
}
