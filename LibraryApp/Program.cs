using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    class Program
    {
        static List<User> users = new List<User>()
        {
            new User {Username = "user", Password="1234"}
        };

        static List<Book> books = new List<Book>()
        {
            new Book{Title = "Sefiller",Author="Victor Hugo",Year = 1862},
            new Book{Title = "Suç ve Ceza",Author="Dostoyevski", Year = 1866},
            new Book{Title = "Balonla Beş Hafta",Author="Jules Verne", Year = 1863},
            new Book{Title = "Unutulmuş Düşler",Author="Stefan Zweig", Year = 1900},
            new Book{Title = "İki Şehrin Hikayesi",Author="Charles Dickens", Year = 1859},
            new Book{Title = "Küçük Prens",Author="Antoine de Saint-Exupéry", Year = 1943},
            new Book{Title = "Harry Potter ve Felsefe Taşı",Author="J.K Rowling", Year = 1997},
            new Book{Title = "Hobbit",Author="J.R R. Tolkien", Year = 1937},
            new Book{Title = "Kızıl Köşkün Rüyası",Author="Cao Xueqin", Year = 1791},
            new Book{Title = "On Kişiydiler",Author="Agatha Christie", Year = 1939}
        };

        static void Main()
        {
            if (Login())
            {
                ShowMenu();
            }
            else
            {
                Console.WriteLine("Login failed. Program is terminating.");
            }
        }

        static bool Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            return users.Any(u => u.Username == username && u.Password == password);
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1-List Books\n2-Add Book\n3-Search Book\n4-Exit");
                Console.Write("Choose: ");
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        ListBooks();
                        break;

                    case "2":
                        AddBook();
                        break;

                    case "3":
                        SearchBook();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid Choose!");
                        break;

                }

                static void ListBooks()
                {
                    Console.WriteLine("\nList Books");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.Title} - {book.Author} ({book.Year})");
                    }
                }

                static void AddBook()
                {
                    Console.Write("Book Name: ");
                    string title = Console.ReadLine();
                    Console.Write("Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Year: ");
                    int year = int.Parse(Console.ReadLine());

                    books.Add(new Book { Title = title, Author = author, Year = year });
                    Console.WriteLine("Book Added.");
                }

                static void SearchBook()
                {
                    Console.Write("Search Word: ");
                    string keyword = Console.ReadLine().ToLower();

                    var results = books
                        .Where(b => b.Title.ToLower().Contains(keyword) || b.Author.ToLower().Contains(keyword))
                        .ToList();

                    if (results.Count == 0)
                    {
                        Console.WriteLine("No Books Found.");

                    }
                    else
                    {
                        Console.WriteLine("Search Results: ");
                        foreach (var book in results)
                        {
                            Console.WriteLine($"{book.Title} - {book.Author} ({book.Year})");
                        }
                    }
                }

            }
        }



    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}