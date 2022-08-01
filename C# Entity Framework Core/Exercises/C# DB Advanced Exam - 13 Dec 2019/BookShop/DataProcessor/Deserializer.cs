namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var books = new List<Book>();

            var deserialized = XmlConverter.Deserializer<BookImportModel>(xmlString, "Books");

            foreach (var currentBook in deserialized)
            {
                if (!IsValid(currentBook))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidDate = DateTime.TryParseExact(currentBook.PublishedOn,
                    "MM/dd/yyyy",
                  CultureInfo.InvariantCulture,
                  DateTimeStyles.None,
                  out DateTime publishedOn);

                var book = new Book
                {
                    Name = currentBook.Name,
                    Genre = Enum.Parse<Genre>(currentBook.Genre),
                    Price = currentBook.Price,
                    Pages = currentBook.Pages,
                    PublishedOn = publishedOn
                };

                books.Add(book);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var authors = new List<Author>();

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<AuthorImportModel>>(jsonString);

            foreach (var currentAuthor in deserialized)
            {
                if (!IsValid(currentAuthor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(a => a.Email == currentAuthor.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = currentAuthor.FirstName,
                    LastName = currentAuthor.LastName,
                    Phone = currentAuthor.Phone,
                    Email = currentAuthor.Email
                };

                foreach (var bookId in currentAuthor.Books)
                {
                    if (!bookId.Id.HasValue)
                    {
                        continue;
                    }

                    var book = context.Books.FirstOrDefault(x => x.Id == bookId.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count()));
            }

            context.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}