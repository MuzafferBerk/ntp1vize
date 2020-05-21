using System;

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
                        Console.WriteLine("HATALI GİRİŞ YAPTINIZ.");
                        Open_Menu_Main();
                        break;
                }
            }
            
            Environment.Exit(0);
        }
        private void Open_Menu_BooksList()
        {
            
        }

        private void Open_Menu_AddBooks()
        {
            
        }
        
    }
    
}