using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Services;

namespace Services
{
    public class ReaderService
    {
        public void AddReader(List<Reader> readers)
        {
            Console.WriteLine("Enter name of reader: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            if (readers.Any(reader => reader.Name == name))
            {
                Console.WriteLine("Reader already exists.");
                return;
            }

            int newId = IdGenerator.GenerateReaderId(readers);

            Reader reader = new Reader();

            reader.Id = newId;
            reader.Name = name;

            readers.Add(reader);
            Console.WriteLine("Reader added successfully.");


        }

    }
}
