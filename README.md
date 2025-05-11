📚 Library Management System (C# Console App)

A simple, console-based Library Management System built using pure C#. This application allows users to manage books, issue/return books to members, and persist data to a local file. It uses core object-oriented concepts, file handling, and basic user interaction in a clean and modular structure.

🚀 Features

Add and remove books

View all books in the library

Search books by title or author

Add new members

Issue and return books

Persistent storage using file I/O (library_data.txt)

Null-safe and user input validation

🛠️ Technologies Used

💻 Language: C# (.NET Core or .NET 6/7 compatible)

📦 Framework: Console Application

🧠 Concepts: OOP (Classes, Encapsulation), File I/O, LINQ, Error Handling

📁 File Structure

cpp
Copy
Edit
/LibraryManagementSystem
├── Book.cs         // Book model
├── Member.cs       // Member model
├── Library.cs      // Core logic: issue, return, data handling
├── Program.cs      // Entry point with UI loop
├── library_data.txt // Local file to save book/member data
└── README.md 

📝 Sample Usage

--- Library Management System ---
1. Add Book
2. Remove Book
3. View All Books
...
Choose an option: 1
Enter Book ID: 101
Enter Title: Clean Code
Enter Author: Robert C. Martin
Book added successfully
