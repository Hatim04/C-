using System;
using System.Collections.Generic;

public class Books
{
    private static int nextBookId = 1; // Keeps track of the next available book ID

    private int book_id;
    private string book_name;
    private string author_name;
    private double price;
    private DateTime date_of_publication;

    // Properties
    public int BookId
    {
        get { return book_id; }
        private set { book_id = value; }
    }

    public string BookName
    {
        get { return book_name; }
        private set { book_name = value; }
    }

    public string AuthorName
    {
        get { return author_name; }
        private set { author_name = value; }
    }

    public double Price
    {
        get { return price; }
        private set { price = value; }
    }

    public DateTime DateOfPublication
    {
        get { return date_of_publication; }
        private set { date_of_publication = value; }
    }

    // Constructor
    public Books(string bookName, string authorName, double price, DateTime dateOfPublication)
    {
        BookId = nextBookId++; // Assign the current nextBookId and then increment it
        BookName = bookName;
        AuthorName = authorName;
        Price = price;
        DateOfPublication = dateOfPublication;
    }

    // ... rest of the methods remain the same ...



// Menu methods
public static void AddData(List<Books> bookList)
    {


        Console.Write("Enter book_name:");
        string bookName = Console.ReadLine();

        Console.Write("Enter author_name:");
        string authorName = Console.ReadLine();

        Console.Write("Enter price:");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter date_of_publication (yyyy-MM-dd):");
        DateTime dateOfPublication = Convert.ToDateTime(Console.ReadLine());

        Books book = new Books(bookName, authorName, price, dateOfPublication);
        bookList.Add(book);

        Console.WriteLine("Book added successfully!");
    }

    public static void DisplayData(List<Books> bookList)
    {
        foreach (Books book in bookList)
        {
            Console.WriteLine($"Book ID: {book.book_id}");
            Console.WriteLine($"Book Name: {book.BookName}");
            Console.WriteLine($"Author Name: {book.AuthorName}");
            Console.WriteLine($"Price: {book.Price}");
            Console.WriteLine($"Date of Publication: {book.DateOfPublication.ToString("yyyy-MM-dd")}");
            Console.WriteLine();
        }
    }

    public static Books SearchById(List<Books> bookList, int bookId)
    {
        return bookList.Find(book => book.book_id == bookId);
    }

    public static List<Books> SearchByName(List<Books> bookList, string bookName)
    {
        return bookList.FindAll(book => book.BookName.Equals(bookName, StringComparison.OrdinalIgnoreCase));
    }

    public static void UpdateById(List<Books> bookList, int bookId)
    {
        Books bookToUpdate = SearchById(bookList, bookId);

        if (bookToUpdate != null)
        {
            Console.WriteLine("Enter updated book_name:");
            string updatedBookName = Console.ReadLine();
            bookToUpdate.BookName = updatedBookName;

            Console.WriteLine("Enter updated author_name:");
            string updatedAuthorName = Console.ReadLine();
            bookToUpdate.AuthorName = updatedAuthorName;

            Console.WriteLine("Enter updated price:");
            double updatedPrice = Convert.ToDouble(Console.ReadLine());
            bookToUpdate.Price = updatedPrice;

            Console.WriteLine("Enter updated date_of_publication (yyyy-MM-dd):");
            DateTime updatedDateOfPublication = Convert.ToDateTime(Console.ReadLine());
            bookToUpdate.DateOfPublication = updatedDateOfPublication;

            Console.WriteLine("Book updated successfully!");
        }
        else
        {
            Console.WriteLine("Book with the given ID not found!");
        }
    }

    public static void DeleteById(List<Books> bookList, int bookId)
    {
        Books bookToDelete = SearchById(bookList, bookId);

        if (bookToDelete != null)
        {
            bookList.Remove(bookToDelete);
            Console.WriteLine("Book deleted successfully!");
        }
        else
        {
            Console.WriteLine("Book with the given ID not found!");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Books> bookList = new List<Books>();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add data");
            Console.WriteLine("2. Display data");
            Console.WriteLine("3. Search by ID");
            Console.WriteLine("4. Search by name");
            Console.WriteLine("5. Update by ID");
            Console.WriteLine("6. Delete by ID");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Books.AddData(bookList);
                    break;
                case 2:
                    Books.DisplayData(bookList);
                    break;
                case 3:
                    Console.WriteLine("Enter book ID to search:");
                    int searchId = Convert.ToInt32(Console.ReadLine());
                    Books bookById = Books.SearchById(bookList, searchId);
                    if (bookById != null)
                    {
                        Console.WriteLine("Book found:");
                        Console.WriteLine($"Book ID: {bookById.BookId}");
                        Console.WriteLine($"Book Name: {bookById.BookName}");
                        Console.WriteLine($"Author Name: {bookById.AuthorName}");
                        Console.WriteLine($"Price: {bookById.Price}");
                        Console.WriteLine($"Date of Publication: {bookById.DateOfPublication.ToString("yyyy-MM-dd")}");
                    }
                    else
                    {
                        Console.WriteLine("Book not found with the given ID!");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter book name to search:");
                    string searchName = Console.ReadLine();
                    List<Books> booksByName = Books.SearchByName(bookList, searchName);
                    if (booksByName.Count > 0)
                    {
                        Console.WriteLine("Books found:");
                        foreach (Books book in booksByName)
                        {
                            Console.WriteLine($"Book ID: {book.BookId}");
                            Console.WriteLine($"Book Name: {book.BookName}");
                            Console.WriteLine($"Author Name: {book.AuthorName}");
                            Console.WriteLine($"Price: {book.Price}");
                            Console.WriteLine($"Date of Publication: {book.DateOfPublication.ToString("yyyy-MM-dd")}");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No books found with the given name!");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter book ID to update:");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Books.UpdateById(bookList, updateId);
                    break;
                case 6:
                    Console.WriteLine("Enter book ID to delete:");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    Books.DeleteById(bookList, deleteId);
                    break;
                case 7:
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}