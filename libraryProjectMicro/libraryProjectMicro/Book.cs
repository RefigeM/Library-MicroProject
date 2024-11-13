namespace libraryProjectMicro;
     class Book
{
    static public int count { get; set; }
    public int Id { get; }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public float Price { get; set; }
    //public Book(int id,string name,string authorName, float price)
    //{
    //    Id = id;
    //    Name = name;      
    //    AuthorName = authorName;
    //    Price = price;
    //}
    public Book()
    {
        Id = ++count;
    }

    public void ShowInfo()
    {
    }

}

