using Newtonsoft.Json;

namespace libraryProjectMicro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = Path.Combine(@"C:\Users\ACER\OneDrive\Masaüstü\libraryProjectMicro\libraryProjectMicro\Files\Database.json");

            if (File.Exists(filepath)) Console.WriteLine("bu adli file artiq movcuddur");
            else
            {
                File.Create(filepath);
                Console.WriteLine("File yaradildi.");
            }
            Library library = new Library();
            FileHelper fileHelper = new FileHelper(@"C:\Users\ACER\OneDrive\Masaüstü\libraryProjectMicro\libraryProjectMicro\Files\Database.json");



            //try,catch hissesinde komek almisam
            var readFile = fileHelper.Read();
            try
            {
                library.Books = JsonConvert.DeserializeObject<List<Book>>(readFile) ?? new List<Book>();
            }
            catch (JsonReaderException)
            {
                library.Books = new List<Book>();
            }
            int click = int.Parse(Console.ReadLine());
            switch (click)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Book'un name'ni daxil edin:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Book'un authorName'i daxil edin:");
                    string authorName = Console.ReadLine();
                    Console.WriteLine("Book'un price'i daxil edin:");
                    float price = float.Parse(Console.ReadLine());
                    Book book = new Book
                    {

                        Name = name,
                        AuthorName = authorName,
                        Price = price
                    };
                    //Books.Add(book);
                    library.AddBook(book);
                    var result = JsonConvert.SerializeObject(library.Books);
                    fileHelper.replace(result);

                    break;

                case 2:
                    Console.WriteLine("Istediyiniz kitabin id'ni daxil edin:");
                    int iD = int.Parse(Console.ReadLine());
                    var readJsonfile = fileHelper.Read();
                    JsonConvert.DeserializeObject<List<Book>>(readJsonfile);
                    var searchedaBook = library.GetBookById(iD);
                    if (searchedaBook != null) Console.WriteLine("axtarillan  id'e uygun kitab tapildi.");

                    break;
                case 3:
                    Console.WriteLine("Silmek istediyiniz kitabin id'ni daxil edin:");
                    int bookId = int.Parse(Console.ReadLine());
                    var readJsonfileAll = fileHelper.Read();
                    var desR = JsonConvert.DeserializeObject<List<Book>>(readJsonfileAll);
                    library.RemoveBook(bookId);
                    Console.WriteLine($"{bookId} id'li book siyahidan silinddi.");
                    string serL = JsonConvert.SerializeObject(desR);
                    fileHelper.replace(serL);
                    library.PrintBooks();
                    break;
                default:
                    Console.WriteLine("1. Add book\r\n2. Get book by id\r\n3. Remove book\r\n0. Quit");
                    break;

            }
        
        }
    }
}

