namespace LibraryCodeGroupProject
{
    public class Book    // Represents a book in the library system
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }          // Unique ISBN number for the book
        public bool IsAvailable { get; set; }     // Shows whether the book is available 
    }
}