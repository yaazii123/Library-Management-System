using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Library
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();
    private string dataPath = "library_data.txt";

    public Library()
    {
        LoadData();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        SaveData();
    }

    public void RemoveBook(int id)
    {
        books.RemoveAll(b => b.Id == id);
        SaveData();
    }

    public void ViewBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Issued: {book.IsIssued}");
        }
    }

    public void SearchBook(string keyword)
    {
        var results = books.Where(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        foreach (var book in results)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Issued: {book.IsIssued}");
        }
    }

    public void IssueBook(int bookId, int memberId)
    {
        var book = books.FirstOrDefault(b => b.Id == bookId && !b.IsIssued);
        var member = members.FirstOrDefault(m => m.MemberId == memberId);

        if (book != null && member != null)
        {
            book.IsIssued = true;
            member.BorrowedBookIds.Add(bookId);
            SaveData();
            Console.WriteLine("Book issued successfully.");
        }
        else
        {
            Console.WriteLine("Issue failed. Book might be unavailable or Member ID is invalid.");
        }
    }

    public void ReturnBook(int bookId, int memberId)
    {
        var book = books.FirstOrDefault(b => b.Id == bookId);
        var member = members.FirstOrDefault(m => m.MemberId == memberId);

        if (book != null && member != null && book.IsIssued && member.BorrowedBookIds.Contains(bookId))
        {
            book.IsIssued = false;
            member.BorrowedBookIds.Remove(bookId);
            SaveData();
            Console.WriteLine("Book returned successfully.");
        }
        else
        {
            Console.WriteLine("Return failed. Check book and member details.");
        }
    }

    public void AddMember(Member member)
    {
        members.Add(member);
        SaveData();
    }

    private void SaveData()
    {
        using StreamWriter sw = new StreamWriter(dataPath);
        foreach (var book in books)
        {
            sw.WriteLine($"BOOK|{book.Id}|{book.Title}|{book.Author}|{book.IsIssued}");
        }
        foreach (var member in members)
        {
            var borrowed = string.Join(",", member.BorrowedBookIds);
            sw.WriteLine($"MEMBER|{member.MemberId}|{member.Name}|{borrowed}");
        }
    }

    private void LoadData()
    {
        if (!File.Exists(dataPath)) return;
        foreach (var line in File.ReadAllLines(dataPath))
        {
            var parts = line.Split('|');
            if (parts[0] == "BOOK")
            {
                books.Add(new Book(int.Parse(parts[1]), parts[2], parts[3]) { IsIssued = bool.Parse(parts[4]) });
            }
            else if (parts[0] == "MEMBER")
            {
                var borrowed = parts[3].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                members.Add(new Member(int.Parse(parts[1]), parts[2]) { BorrowedBookIds = borrowed });
            }
        }
    }
}