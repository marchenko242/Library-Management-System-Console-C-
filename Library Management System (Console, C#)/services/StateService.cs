using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using Models;

namespace Services
{
    public class StateService
    {

        private const string DataFolder = "data";
        private const string BooksFile = "Data/books.json";
        private const string LoansFile = "Data/loans.json";
        private const string ReadersFile = "Data/readers.json";


        public void Save(List<Book> books, List<Reader> readers, List<Loan> loans)
        {

            try
            {
                if (!Directory.Exists(DataFolder))
                {
                    Directory.CreateDirectory(DataFolder);
                }

                File.WriteAllText(BooksFile, JsonSerializer.Serialize(books));
                File.WriteAllText(ReadersFile, JsonSerializer.Serialize(readers));
                File.WriteAllText(LoansFile, JsonSerializer.Serialize(loans));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving data.");
                Console.WriteLine(ex.Message);
            }
            

        }


        public List<Book> LoadBooks()
        {
            try
            {
                if (!File.Exists(BooksFile))
                {
                    return new List<Book>();
                }

                string json = File.ReadAllText(BooksFile);
                return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading books.");
                Console.WriteLine(ex.Message);
                return new List<Book>();
            }
        }

        public List<Reader> LoadReaders()
        {
            try
            {
                if (!File.Exists(ReadersFile))
                {
                    return new List<Reader>();
                }

                string json = File.ReadAllText(ReadersFile);
                return JsonSerializer.Deserialize<List<Reader>>(json) ?? new List<Reader>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading readers.");
                Console.WriteLine(ex.Message);
                return new List<Reader>();
            }
        }

        public List<Loan> LoadLoans()
        {
            try
            {
                if (!File.Exists(LoansFile))
                {
                    return new List<Loan>();
                }

                string json = File.ReadAllText(LoansFile);
                return JsonSerializer.Deserialize<List<Loan>>(json) ?? new List<Loan>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading loans.");
                Console.WriteLine(ex.Message);
                return new List<Loan>();
            }
        }

    }
}
