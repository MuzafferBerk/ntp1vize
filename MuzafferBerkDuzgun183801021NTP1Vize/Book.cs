using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MuzafferBerkDuzgun183801021NTP1Vize
{
    public class Book
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Genre { get; set; }

        #region Constructors

        public Book(string bookName, string author, DateTime publicationDate, string genre)
        {
            BookName = bookName;
            Author = author;
            PublicationDate = publicationDate;
            Genre = genre;
        }

        #endregion

        internal static void SaveBook(Book book)
        {
            string path = @".\books";
            try
            {
                BookList bookList;

                if (!File.Exists(path))
                {
                    bookList = new BookList();
                    bookList.books = new List<SerializedBook>();
                }
                else
                {
                    bookList = XmlSerialization.ReadFromXmlFile<BookList>(path);
                }

                var serializedBook = new SerializedBook(book);
                bookList.books.Add(serializedBook);
                XmlSerialization.WriteToXmlFile<BookList>( path, bookList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }

    [Serializable]
    public class SerializedBook
    {
        public string BookName, Author, PublicationDate, Genre;

        public SerializedBook()
        {
            
        }
        public SerializedBook(Book bookToSerialize)
        {
            BookName = bookToSerialize.BookName;
            Author = bookToSerialize.Author;
            PublicationDate = bookToSerialize.PublicationDate.Year.ToString();
            Genre = bookToSerialize.Genre;
        }
    }

    [Serializable]
    public class BookList
    {
        public List<SerializedBook> books;
    }
}
