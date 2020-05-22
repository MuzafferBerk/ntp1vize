using System;
using System.Collections.Generic;
using System.Text;

namespace MuzafferBerkDuzgun183801021NTP1Vize
{
    class ConsoleHandler
    {
        #region Singleton
        
        private static ConsoleHandler _instance;
        public static ConsoleHandler Instance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleHandler();
            }

            return _instance;
        }

        #endregion
        
        bool _exit = false;
        
        public void Open_Menu_Main()
        {
            while (!_exit)
            {
                Console.Clear();
                Console.WriteLine("--UYGULAMA-ARAYÜZÜ--");
                Console.WriteLine("Kitap ekleme menüsü için '1'");
                Console.WriteLine("Kitap listesini görüntülemek için '2'");
                Console.WriteLine("Cikis icin '3'");

                var newInput = Console.ReadLine(); //ReadKey();

                switch (newInput)
                {
                    case "1":
                        Open_Menu_AddBooks();
                        break;
                    case "2":
                        Open_Menu_BooksList();
                        break;
                    case "3":
                        _exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("HATALI GİRİŞ YAPTINIZ.");
                        Console.WriteLine("Devam için ENTER");
                        Console.ReadLine();
                        Open_Menu_Main();
                        break;
                }
            }
            
            Environment.Exit(0);
        }
        private void Open_Menu_BooksList()
        {
            var bookList = XmlSerialization.ReadFromXmlFile<BookList>(@".\books");
            var books = bookList.books;

            Console.Clear();
            Console.WriteLine("Toplam kitap sayısı : " + books.Count);
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*");
            foreach (var book in books)
            {
                Console.WriteLine("Kitap Adı : " + book.BookName);
                Console.WriteLine("Yazar Adı : " + book.Author);
                Console.WriteLine("Yayınlanma Yılı : " + book.PublicationDate);
                Console.WriteLine("Türü : " + book.Genre);
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*");
            }

            Console.WriteLine("---");
            Console.WriteLine("---DEVAM ETMEK İÇİN ENTER---");
            Console.WriteLine("---");
            Console.ReadLine();
        }

        private void Open_Menu_AddBooks()
        {
            Console.Clear();
            Console.WriteLine("Eklenecek kitap sayısını giriniz");

            int bookToAddCount = 0;

            try
            {
                var bookToAddCountString = Console.ReadLine();
                bookToAddCount = Int32.Parse(bookToAddCountString);
                if (bookToAddCount <= 0)
                    throw new Exception();

            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
                Console.WriteLine("Gecerli bir deger girmediginiz icin ana menüye yönlendiriliyorsunuz.");
                Open_Menu_Main();
            }

            

            for (int i=0; i<bookToAddCount; i++)
            {
                
                AddBook((bookToAddCount - i));
            }

        }

        private void AddBook(int bookLeftCounter)
        {
            Console.Clear();

            Console.WriteLine("Eklenecek kitap sayisi : " + bookLeftCounter);

            try
            {
                Console.WriteLine("Kitap adı giriniz");
                string bookName = string.Empty;
                Console.In.Close();
                bookName = Console.In.ReadLine();

                Console.Clear();
                Console.WriteLine("Yazar adı giriniz.");
                string authorName = string.Empty;
                authorName = Console.ReadLine();
                
                Console.Clear();
                Console.WriteLine("Kitap basım tarihini sadece yıl olarak giriniz.");
                string pubYearString = Console.ReadLine();
                int pubYear = Int32.Parse(pubYearString);
                if(pubYear > 2020)
                    throw new Exception();
                var authDate = new DateTime(pubYear, 1, 1);

                Console.Clear();
                Console.WriteLine("Kitap türünü giriniz.");
                string genre = Console.ReadLine();

                Book newBookToAdd = new Book(bookName, authorName, authDate, genre);
                Book.SaveBook(newBookToAdd);

                Console.WriteLine("Kitap basariyla eklendi. Devam etmek icin ENTER");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                Console.WriteLine("Gecersiz giris yaptiniz lutfen kitabi bastan dogru sekilde ekleyiniz.");
                //throw;
                Console.WriteLine("Devam etmek için ENTER");
                Console.Read();
                Open_Menu_AddBooks();
            }
        }
    }
}