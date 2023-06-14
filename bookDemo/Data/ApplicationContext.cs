using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book() {Id = 1, Title = "Harry Potter", Price = 25},
                new Book() {Id = 2, Title = "Lord Of The Rings", Price = 51},
                new Book() {Id = 3, Title = "Scherlock Holmes", Price = 72},
            };
        }
            
       
    }
}
