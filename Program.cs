using System;

class Program
{
    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. View All Books");
            Console.WriteLine("4. Issue Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Search Book");
            Console.WriteLine("7. Add Member");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Book ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }
                    Console.Write("Enter Title: ");
                    string? title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string? author = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("Title or Author can't be empty.");
                        break;
                    }
                    library.AddBook(new Book(id, title, author));
                    break;

                case 2:
                    Console.Write("Enter Book ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int rid))
                        library.RemoveBook(rid);
                    else
                        Console.WriteLine("Invalid ID.");
                    break;

                case 3:
                    library.ViewBooks();
                    break;

                case 4:
                    Console.Write("Enter Book ID to issue: ");
                    if (!int.TryParse(Console.ReadLine(), out int bid))
                    {
                        Console.WriteLine("Invalid Book ID.");
                        break;
                    }
                    Console.Write("Enter Member ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int mid))
                    {
                        Console.WriteLine("Invalid Member ID.");
                        break;
                    }
                    library.IssueBook(bid, mid);
                    break;

                case 5:
                    Console.Write("Enter Book ID to return: ");
                    if (!int.TryParse(Console.ReadLine(), out int rbid))
                    {
                        Console.WriteLine("Invalid Book ID.");
                        break;
                    }
                    Console.Write("Enter Member ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int rmid))
                    {
                        Console.WriteLine("Invalid Member ID.");
                        break;
                    }
                    library.ReturnBook(rbid, rmid);
                    break;

                case 6:
                    Console.Write("Enter keyword to search: ");
                    string? keyword = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(keyword))
                        library.SearchBook(keyword);
                    else
                        Console.WriteLine("Keyword cannot be empty.");
                    break;

                case 7:
                    Console.Write("Enter Member ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int memid))
                    {
                        Console.WriteLine("Invalid Member ID.");
                        break;
                    }
                    Console.Write("Enter Name: ");
                    string? name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        break;
                    }
                    library.AddMember(new Member(memid, name));
                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

