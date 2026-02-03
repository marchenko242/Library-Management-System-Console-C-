using System;
using System.Collections.Generic;
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


            if(selectedBook.IsAvailable == false)
            {
                Console.WriteLine("Book is busy.");
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

            //---

            Loan loan = new Loan();
            loan.BookId = selectedBook.Id;
            loan.ReaderId = selectedReader.Id;
            loan.LoanDate = DateTime.Now;
            loan.IsReturned = false;

            loans.Add(loan);

            selectedBook.IsAvailable = false;
            Console.WriteLine("Book borrowed successfully.");


        }

        public void ReturnBook(List<Loan> loans, List<Book> books)
        {
            Console.WriteLine("Enter id of book for return: ");
            string inputBookId = Console.ReadLine();

            if (!int.TryParse(inputBookId, out int returnBookId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Book activeBook = null;

            foreach(Book b in books)
            {
                if(b.Id == returnBookId)
                {
                    activeBook = b;
                    break;
                }
            }

            if (activeBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (activeBook.IsAvailable == true)
            {
                Console.WriteLine("This book is not borrowed.");
                return;
            }

            Loan activeLoan = null;

            foreach(Loan l in loans)
            {
                if (l.BookId == returnBookId && l.IsReturned == false)
                {
                    activeLoan = l;
                    break;
                }

            }

            if (activeLoan == null)
            {
                Console.WriteLine("Active loan not found.");
                return;
            }

            activeLoan.IsReturned = true;
            activeBook.IsAvailable = true;
            Console.WriteLine("Book returned successfully.");

        }



    }
}
