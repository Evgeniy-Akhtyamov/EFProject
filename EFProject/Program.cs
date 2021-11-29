using System;
using System.Collections.Generic;

namespace EFProject
{
    class Program
    {
        static void ShowUsers()
        {
            var allUsers = UserRepository.GetAllUsers();
            Console.WriteLine("Список всех пользователей:");
            foreach (User u in allUsers)
                Console.WriteLine($"{u.Id}.{u.Name} {u.Email} ");
        }
        static void ShowBooks()
        {
            var allBooks = BookRepository.GetAllBooks();
            Console.WriteLine("Список всех книг:");
            foreach (Book b in allBooks)
                Console.WriteLine($"{b.Id}. {b.Title} {b.Author} {b.Genre} {b.Year}");
        }

        static void ShowUser()
        {
            Console.WriteLine("Введите Id пользователя для получения его данных");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = UserRepository.GetUserById(id);
            if (user == null) Console.WriteLine("Такого пользователя нет в базе данных"); 
            else Console.WriteLine($"Пользователь с Id = {id}: {user.Name} {user.Email} ");
        }
        static void ShowBook()
        {
            Console.WriteLine("Введите Id книги для получения ее данных");
            int id = Convert.ToInt32(Console.ReadLine());
            var book = BookRepository.GetBookById(id);
            if(book == null) Console.WriteLine("Такой книги нет в базе данных");
            else Console.WriteLine($"Книга с Id = {id}: {book.Title} {book.Author} {book.Genre} {book.Year}");
        }
        static void AddUser()
        {
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите email пользователя");
            var email = Console.ReadLine();
            var user = new User { Name = name, Email = email };
            try
            {
                UserRepository.AddUser(user);
                Console.WriteLine("Пользователь добавлен");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Произошла ошибка добавления пользователя");
                Console.WriteLine(ex.Message);
            }            
        }
        static void AddBook()
        {
            Console.WriteLine("Введите название книги");
            var title = Console.ReadLine();
            Console.WriteLine("Введите автора");
            var author = Console.ReadLine();
            Console.WriteLine("Введите жанр");
            var genre = Console.ReadLine();
            Console.WriteLine("Введите год издания");
            var year = Convert.ToInt32(Console.ReadLine());
            var book = new Book { Title = title, Author = author, Genre = genre, Year = year };
            try
            {
                BookRepository.AddBook(book);
                Console.WriteLine("Книга добавлена");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Произошла ошибка добавления книги");
                Console.WriteLine(ex.Message);
            }           
        }
        static void DeleteUser()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                UserRepository.DeleteUserById(id);
                Console.WriteLine($"Пользователь с Id {id} удален");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Произошла ошибка удаления пользователя");
                Console.WriteLine(ex.Message);
            }
                 
        }
        static void DeleteBook()
        {
            Console.WriteLine("Введите Id книги, которую хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                BookRepository.DeleteBookById(id);
                Console.WriteLine($"Книга с Id {id} удалена");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка удаления книги");
                Console.WriteLine(ex.Message);
            }           
        }
        static void UpdateUser()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите изменить");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новое имя пользователя");
            var name = Console.ReadLine();
            try
            {
                UserRepository.UpdateUserNameById(id, name);
                Console.WriteLine($"Пользователь с Id {id} изменен");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при изменении имени пользователя");
                Console.WriteLine(ex.Message);
            }            
        }
        static void UpdateBook()
        {
            Console.WriteLine("Введите Id книги, которую хотите изменить");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новый год выпуска");
            var year = Convert.ToInt32(Console.ReadLine());
            try
            {
                BookRepository.UpdateBookYearById(id, year);
                Console.WriteLine($"Книга с Id {id} изменена");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка изменения книги");
                Console.WriteLine(ex.Message);
            }
        }
        static void TakeBook()
        {
            Console.WriteLine("Введите Id пользователя, который берет книгу");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Id книги, которую он берет");
            int idBook = Convert.ToInt32(Console.ReadLine());
            try
            {
                UserRepository.TakeBookOnHands(id, idBook);
                Console.WriteLine($"Книга с Id {idBook} выдана пользователю с Id {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка выдачи книги");
                Console.WriteLine(ex.Message);
            }           
        }
        static void DoCommand1()
        {
            Console.WriteLine("Введите жанр");
            var genre = Console.ReadLine();
            Console.WriteLine("Введите начальный год издания");
            var yearFirst = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите конечный год издания");
            var yearLast = Convert.ToInt32(Console.ReadLine());
            var books = BookRepository.GetBooksByGenreAndYears(genre, yearFirst, yearLast);
            if (books.Count != 0)
            {
                foreach (Book b in books)
                    Console.WriteLine($"{b.Id}. {b.Title}  {b.Author}  {b.Genre}  {b.Year}");
            }
            else Console.WriteLine("С такими параметрами книг нет");
        }

        static void DoCommand2()
        {
            Console.WriteLine("Введите автора");
            var author = Console.ReadLine();
            int count = BookRepository.CountOfBooksByAuthor(author);
            Console.WriteLine($"Количество книг автора {author}: {count}");
        }
        static void DoCommand3()
        {
            Console.WriteLine("Введите жанр");
            var genre = Console.ReadLine();
            int count = BookRepository.CountOfBooksByGenre(genre);
            Console.WriteLine($"Количество книг жанра {genre}: {count}");
        }
        static void DoCommand4()
        {
            Console.WriteLine("Введите автора");
            var author = Console.ReadLine();
            Console.WriteLine("Введите название книги");
            var title = Console.ReadLine();
            bool flag = BookRepository.ContainsByAuthorAndByTitle(author, title);
            if (flag)
            {
                Console.WriteLine("Такая книга есть");
            }   
            else Console.WriteLine("Такой книги нет");
        }
        static void DoCommand5()
        {
            Console.WriteLine("Введите Id книги, которую хотите проверить");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool flag = BookRepository.ChekBookOnHands(id);
                if (flag)
                {
                    Console.WriteLine("Эта книга выдана на руки");
                }
                else Console.WriteLine("Эта книгу еще никто не взял");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка скорее всего в БД нет такой книги");
                Console.WriteLine(ex.Message);
            }            
        }
        static void DoCommand6()
        {
            int count = BookRepository.CountOfBooksOnHands();            
            Console.WriteLine($"Книг на руках у пользователей: {count}");
        }
        static void DoCommand7()
        {
            var bookLast = BookRepository.GetBookLastYear();
            Console.WriteLine("Самая последняя выпущенная книга:");
            Console.WriteLine($"{bookLast.Title}  {bookLast.Author}  {bookLast.Genre}  {bookLast.Year}");
        }
        static void DoCommand8()
        {
            var books = BookRepository.GetAllBooksOrderedByTitle();
            Console.WriteLine("Список всех книг отсортированный в алфавитном порядке по названию:");
            foreach (Book b in books)
                Console.WriteLine($"{b.Title}  {b.Author}  {b.Genre}  {b.Year}");
        }
        static void DoCommand9()
        {
            var books = BookRepository.GetAllBooksOrderedByYearDesc();
            Console.WriteLine("Список всех книг отсортированный в порядке убывания года их выхода:");
            foreach (Book b in books)
                Console.WriteLine($"{b.Year}  {b.Title}  {b.Author}  {b.Genre}");
        }
        static void Main(string[] args)
        {
            //Создаем пользователей
            var user1 = new User { Name = "Arthur", Email = "Artik42@mail.ru" };
            var user2 = new User { Name = "Klim", Email = "Kl88@gmail.com" };
            var user3 = new User { Name = "Pavel", Email = "Pavlik37@gmail.com" };
            var user4 = new User { Name = "Sergey", Email = "Serzh10@mail.ru" };
            var user5 = new User { Name = "Rinat", Email = "Rinat99@mail.ru" };
            var user6 = new User { Name = "Alex", Email = "Alex87@mail.ru" };            
            
            // Создаем книги
            var book1 = new Book { Title = "C# 7.0. Карманный справочник", Author = "Джозеф Албахари", Genre = "Study", Year = 2017 };
            var book2 = new Book { Title = "LINQ. Карманный справочник", Author = "Джозеф Албахари", Genre = "Study", Year = 2009 };
            var book3 = new Book { Title = "Библия C#", Author = "Фленов М. Е.", Genre = "Study", Year = 2020 };
            var book4 = new Book { Title = "Прикладное программирование с использованием языка С Шарп", Author = "Бельков С.А.", Genre = "Study", Year = 2017 };
            var book5 = new Book { Title = "Параллельное программирование с помощью языка C#", Author = "Туральчук К.А.", Genre = "Study", Year = 2016 };
            var book6 = new Book { Title = "C# на примерах", Author = "Евдокимов П.В.", Genre = "Study", Year = 2019 };
            var book7 = new Book { Title = "Отныне и навсегда", Author = "Робертс Нора", Genre = "Novel", Year = 1999 };
            var book8 = new Book { Title = "Возвращение", Author = "Ремарк Эрих Мария", Genre = "Detective", Year = 1931 };
            var book9 = new Book { Title = "Триумфальная арка", Author = "Ремарк Эрих Мария", Genre = "Novel", Year = 1945 };
            var book10 = new Book { Title = "Яд бессмертия", Author = "Робертс Нора", Genre = "Detective", Year = 1996 };
            var book11 = new Book { Title = "Преступление и наказание", Author = "Достоевский Фёдор", Genre = "Novel", Year = 1866 };
            var book12 = new Book { Title = "Анна Каренина", Author = "Толстой Лев", Genre = "Novel", Year = 1875 };
            var book13 = new Book { Title = "Белые ночи", Author = "Достоевский Фёдор", Genre = "Story", Year = 1865 };
            var book14 = new Book { Title = "Собачье сердце", Author = "Михаил Булгаков", Genre = "Story", Year = 1987 };
            var book15 = new Book { Title = "Ревизор", Author = "Гоголь Николай", Genre = "Comedy", Year = 1836 };
                                   
            // Добавляем в базу данных если она пуста
            if(UserRepository.IsEmpty())
            {
                UserRepository.AddUserRange(new List<User> { user1, user2, user3, user4, user5, user6 });
            }            

            if(BookRepository.IsEmpty())
            {
                BookRepository.AddBookRange(
                    new List<Book> { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14, book15 });
            }

            Console.WriteLine("База данных создана");
            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.showBooks + ": просмотр данных по книгам");
            Console.WriteLine(Commands.showUsers + ": просмотр данных по пользователям");
            Console.WriteLine(Commands.showBook + ": просмотр данных по книге");
            Console.WriteLine(Commands.showUser + ": просмотр данных по пользователю");
            Console.WriteLine(Commands.addUser + ": добавление пользователя");
            Console.WriteLine(Commands.addBook + ": добавление книги");
            Console.WriteLine(Commands.deleteUser + ": удаление пользователя");
            Console.WriteLine(Commands.deleteBook + ": удаление книги");
            Console.WriteLine(Commands.updateUser + ": обновление имени пользователя");
            Console.WriteLine(Commands.updateBook + ": обновление года выпуска книги");
            Console.WriteLine(Commands.takeBook + ": получение книги пользователем");
            Console.WriteLine(Commands.command1 + ": показать список книг определенного жанра и вышедших между определенными годами");
            Console.WriteLine(Commands.command2 + ": показать количество книг определенного автора в библиотеке");
            Console.WriteLine(Commands.command3 + ": показать количество книг определенного жанра в библиотеке");
            Console.WriteLine(Commands.command4 + ": показать есть ли книга определенного автора и с определенным названием в библиотеке");
            Console.WriteLine(Commands.command5 + ": показать есть ли определенная книга на руках у пользователя");
            Console.WriteLine(Commands.command6 + ": показать количество книг на руках у пользователя");
            Console.WriteLine(Commands.command7 + ": показать последнюю вышедшею книгу");
            Console.WriteLine(Commands.command8 + ": показать списк всех книг, отсортированный в алфавитном порядке по названию");
            Console.WriteLine(Commands.command9 + ": показать список всех книг, отсортированный в порядке убывания года их выхода");
            
            string command;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Введите команду");
                command = Console.ReadLine();
                Console.WriteLine();
                switch (command)
                {
                    case nameof(Commands.showBooks):
                        {
                            ShowBooks();
                            break;
                        }
                    case nameof(Commands.showUsers):
                        {
                            ShowUsers();
                            break;
                        }
                    case nameof(Commands.showBook):
                        {
                            ShowBook();
                            break;
                        }
                    case nameof(Commands.showUser):
                        {
                            ShowUser();
                            break;
                        }
                    case nameof(Commands.addUser):
                        {
                            AddUser();
                            break;
                        }
                    case nameof(Commands.addBook):
                        {
                            AddBook();
                            break;
                        }
                    case nameof(Commands.deleteUser):
                        {
                            DeleteUser();
                            break;
                        }
                    case nameof(Commands.deleteBook):
                        {
                            DeleteBook();
                            break;
                        }
                    case nameof(Commands.updateUser):
                        {
                            UpdateUser();
                            break;
                        }
                    case nameof(Commands.updateBook):
                        {
                            UpdateBook();
                            break;
                        }
                    case nameof(Commands.takeBook):
                        {
                            TakeBook();
                            break;
                        }
                    case nameof(Commands.command1):
                        {
                            DoCommand1();
                            break;
                        }
                    case nameof(Commands.command2):
                        {
                            DoCommand2();
                            break;
                        }
                    case nameof(Commands.command3):
                        {
                            DoCommand3();
                            break;
                        }
                    case nameof(Commands.command4):
                        {
                            DoCommand4();
                            break;
                        }
                    case nameof(Commands.command5):
                        {
                            DoCommand5();
                            break;
                        }
                    case nameof(Commands.command6):
                        {
                            DoCommand6();
                            break;
                        }
                    case nameof(Commands.command7):
                        {
                            DoCommand7();
                            break;
                        }
                    case nameof(Commands.command8):
                        {
                            DoCommand8();
                            break;
                        }
                    case nameof(Commands.command9):
                        {
                            DoCommand9();
                            break;
                        }
                }
            }
            while (command != nameof(Commands.stop));

        }
    }
}
