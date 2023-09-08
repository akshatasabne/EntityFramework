namespace CrudUsingEntityFramework.Models
{
    public class BookCrud
    {
        ApplicationDbContext context;
        private IConfiguration configuration;

        public BookCrud(ApplicationDbContext context)
        {
            this.context = context;
        }

        public BookCrud(IConfiguration configuration)
        {
            this.configuration = configuration;


        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.Where(x => x.IsActive == 1).ToList();
        }
        public Book GetBookById(int id)
        {
            var book = context.Books.Where(x => x.Id==id).FirstOrDefault();
            return book;
        }
        public int AddBook(Book book)
        {
            book.IsActive = 1;
            int result = 0;
            context.Books.Add(book);
            result=context.SaveChanges();
            return result;
        }
        public int UpdateBook(Book book)
        {
            int result = 0;
            var b=context.Books.Where(x=>x.Id==book.Id).FirstOrDefault();
            if (b != null)
            {
                b.Name = book.Name;
                b.Author=book.Author;
                b.Price=book.Price;
                b.IsActive = 1;
                result=context.SaveChanges();
            }
            return result;
        }
        public int DeleteBook(int id)
        {


            int result = 0;
            // search from dbset
            var b = context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (b != null)
            {
                b.IsActive = 0;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }


            return result;
        }

    }
}
