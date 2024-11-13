namespace libraryProjectMicro;

class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> Books = new List<Book>();

    public void AddBook(Book book)
    {
        bool isExist = false;
        foreach (var item in Books)
        {
            if (book.Id == item.Id)
            {
                isExist = true;
                break;
            }
        }

        if (isExist)
        {
            Console.WriteLine("Kitab siyahıyida artiq movcuddur.");

        }
        else
        {
            Books.Add(book);
            Console.WriteLine("Kitab siyahıya əlavə olundu.");
        }
        PrintBooks();


    }
    
    public Book GetBookById(int id)
    {
        var book = Books.Find(x => x.Id == id);
        if (book == null) Console.WriteLine("veriln id'e uygun kitab tapilmadi.");
        return book;

    }
    public void RemoveBook(int id)
    {
        Books.RemoveAll(x => x.Id == id);
    }
    public void PrintBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("Siyahı boşdur.");
        }
        else
        {
            Console.WriteLine("Kitablarin siyahisi:");
            foreach (var book in Books)
            {
                Console.WriteLine($"Id: {book.Id}, ad: {book.Name}, author: {book.AuthorName}, price: {book.Price}");
            }
        }
    }

}