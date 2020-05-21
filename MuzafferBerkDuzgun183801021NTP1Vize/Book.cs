using System;

namespace MuzafferBerkDuzgun183801021NTP1Vize
{
    internal class Book
    {
        public string BookName { get; }
        public string Author { get; }
        public DateTime PublicationDate { get; }
        public string Genre { get; }

        #region Constructors

        public Book(string bookName, string author, DateTime publicationDate, string genre)
        {
            BookName = bookName;
            Author = author;
            PublicationDate = publicationDate;
            Genre = genre;
        }

        #endregion

        internal static void SaveBook()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
