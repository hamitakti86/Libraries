using Domain;

namespace Persistance
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Books.Any())
            {
                var author = new Author { Name = "Dan Brown" };
                var author1 = new Author { Name = "Malcolm Gladwell" };
                await context.Authors.AddAsync(author);
                await context.Authors.AddAsync(author1);

                var library = new Library()
                {
                    Name = "Library-1",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Angel and Demond", ISBN = "456", Author = author },
                        new Book { Title = "Outliers", ISBN = "123", Author = author1 }
                    }
                };

                var library2 = new Library()
                {
                    Name = "Library-2",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Da Vinci Code", ISBN = "333", Author = author },
                        new Book { Title = "Blink", ISBN = "444", Author = author1 }
                    }
                };



                await context.Libraries.AddRangeAsync(library);
                await context.Libraries.AddRangeAsync(library2);

                await context.SaveChangesAsync();
            }
        }
    }
}