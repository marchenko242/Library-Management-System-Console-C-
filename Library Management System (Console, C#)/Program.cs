using System;
using Models;
using Services;

class Program
{
    static void Main(string[] args)
    {

        List<Book> books = new List<Book>();
        BookService bookService = new BookService();

        Console.WriteLine("Welcome to the Library Management System!");

        while(true)
        {
            Console.WriteLine("Choose one option ( \n 1 - add book, \n 2 - Show all books, \n 3 - Add reader, \n 4 - Show all readers, \n 5 - Borrow book, 6 - Return book, \n 7 - Save & exit): ");

            string answerMenu = Console.ReadLine();

            switch (answerMenu)
            {
                case "1":
                    bookService.AddBook(books);

                    break;
                case "2":
                    bookService.ShowBooks(books);
                    break;
            }
        }
        
        
        

    }

}