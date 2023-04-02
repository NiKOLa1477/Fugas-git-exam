using static OOP.Program;
using static System.Reflection.Metadata.BlobBuilder;

namespace OOP
{
    internal class Program
    {
        public class Person
        {         
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Sex { get; private set; }
            public int Age { get; private set; }
            public Person() { FirstName = "Unknown"; LastName = "Unknown"; Sex = "Unknown"; Age = 0; }
            public Person(string firstName, string lastName, string sex, int age)
            { FirstName = firstName; LastName = lastName; Sex = sex; Age = age; }
        }
        public class Student : Person
        {
            public string Group { get; private set; }
            public int Id { get; private set; }
            public string Email { get; private set; }
            public Student() : base() { Group = "None"; Id = 0; Email = "Unknown"; }
            public Student(string firstName, string lastName, string sex, int age,
                string group, int id, string email) : base(firstName, lastName, sex, age)
            { Group = group; Id = id; Email = email; }
        }
        public class Professor : Person
        {
            public string Email { get; private set; }
            public string Rank { get; private set; }
            public Professor() : base() { Email = "Unknown"; Rank = "Unknown"; }
            public Professor(string firstName, string lastName, string sex, int age,
                string email, string rank) : base(firstName, lastName, sex, age)
            { Email = email; Rank = rank; }
        }
        public class Subject
        {
            public string SubjectName { get; private set; }
            private Professor Professor;
            private Student[] Students;
            public Subject() { SubjectName = "Unknown"; Professor = new Professor(); Students = new Student[0]; Students[0] = new Student(); }
            public Subject(string subjectName, Professor professor)
            { SubjectName = subjectName; Professor = professor; Students = new Student[1]; Students[0] = new Student(); }
            public void AddStudent(Student student)
            {
                if (Students[0].Id > 0)
                {
                    Student[] temp = new Student[Students.Length + 1];
                    for (int i = 0; i < Students.Length; i++)
                        temp[i] = Students[i];
                    temp[Students.Length] = student;
                    Students = temp;
                }
                else
                    Students[0] = student;
            }
            public void ShowInfo()
            {
                Console.WriteLine($"Subject: {SubjectName}\nProfessor: {Professor.LastName} {Professor.FirstName}");
                Console.WriteLine("Students:");
                foreach(var student in Students)
                    Console.WriteLine($"{student.LastName} {student.FirstName}");
            }
        }

        public class Book
        {
            public string Name { get; private set; }
            public string Author { get; private set; }
            public Book() { Name = "Unknown"; Author = "Unknown"; }
            public Book(string name, string author) { Name = name; Author = author; }
        }
        public class Library
        {
            private Book[] Books;
            public Library(Book[] books) { Books = books; }
            public Book findByName(string name)
            {
                foreach (var book in Books)
                    if(book.Name == name)
                        return book;                
                return new Book();
            }
            public Book[] findByAuthor(string author)
            {
                int authorBooksCount = 0;
                foreach (var book in Books)
                    if (book.Author == author)
                        authorBooksCount++;
                Book[] findedBooks = new Book[authorBooksCount];
                if (authorBooksCount == 0)
                    return findedBooks;
                else
                {
                    authorBooksCount = 0;
                    for (int i = 0; i < Books.Length; i++) 
                        if (Books[i].Author == author)
                        {
                            findedBooks[authorBooksCount] = Books[i];
                            authorBooksCount++;
                        }
                    return findedBooks;
                }
            }
        }

        public class Video
        {
            public string Name { get; private set; }
            public int Duration { get; private set; }
            public Video() { Name = "Unknown"; Duration = 0; }
            public Video(string name, int duration) { Name = name; Duration = duration; }
            public string getConvertedDuration()
            {
                int hours, minutes, seconds;
                seconds = Duration % 60;
                minutes = (Duration / 60) % 60;
                hours = Duration / 60 / 60;
                return $"{hours}:{minutes}:{seconds}";
            }
        }
        public class Playlist
        {
            private Video[] Videos;
            public int PlaylistDuration { get; private set; }
            public Playlist(Video[] videos) { Videos = videos; PlaylistDuration = videos.Sum(i => i.Duration); }
            public void AddVideo(Video video)
            {
                Video[] temp = new Video[Videos.Length + 1];
                for (int i = 0; i < Videos.Length; i++)
                    temp[i] = Videos[i];
                temp[Videos.Length] = video;
                Videos = temp;
                PlaylistDuration = Videos.Sum(i => i.Duration);
            }
            public void RemoveVideo()
            {
                Video[] temp = new Video[Videos.Length - 1];
                for (int i = 0; i < Videos.Length - 1; i++)
                    temp[i] = Videos[i];
                Videos = temp;
                PlaylistDuration = Videos.Sum(i => i.Duration);
            }
            public void ShowInfo()
            {
                foreach (var video in Videos)
                    Console.WriteLine($"{video.Name} Duration: {video.getConvertedDuration()}");
                Console.WriteLine($"Total Duration: {getConvertedDuration()}");               
            }
            public void SavePlaylist()
            {
                string[] lines = new string[Videos.Length + 1];
                for (int i = 0; i < Videos.Length; i++) 
                    lines[i] = $"{Videos[i].Name} Duration: {Videos[i].getConvertedDuration()}";                  
                lines[Videos.Length] = $"Total Duration: {getConvertedDuration()}";
                File.WriteAllLines("Playlist.txt", lines);
            }
            public string getConvertedDuration()
            {
                int hours, minutes, seconds;
                seconds = PlaylistDuration % 60;
                minutes = (PlaylistDuration / 60) % 60;
                hours = PlaylistDuration / 60 / 60;
                return $"{hours}:{minutes}:{seconds}";
            }
        }

        public class Message
        {
            public int Index { get; private set; }
            public int ParentIndex { get; private set; }
            public string Text { get; private set; }
            public string Author { get; private set; }
            public int Time { get; set; }
            public Message() { Index = 0; ParentIndex = 0; Text = ""; Author = ""; Time = 0; }
            public Message(int index, int parentIndex, string text, string author, int time)
            { Index = index; ParentIndex = parentIndex; Text = text; Author = author; Time = time; }
            public string ConvertTime()
            {
                int minutes, hours;
                minutes = Time % 60;
                hours = Time / 60;
                string lineH = hours < 10 ? "0" :"";
                string lineM = minutes < 10 ? "0" : "";
                return $"{lineH}{hours}:{lineM}{minutes}";
            }
        }
        public class Chat
        {
            private Message[] Messages;
            public Chat(Message[] messages) { Messages = messages; }
            public Message[] findByAuthor(string author)
            {
                int authorMessCount = 0;
                foreach (var Mess in Messages)
                    if (Mess.Author == author)
                        authorMessCount++;
                Message[] findedMessages = new Message[authorMessCount];
                if (authorMessCount == 0)
                    return findedMessages;
                else
                {
                    authorMessCount = 0;
                    for (int i = 0; i < Messages.Length; i++)
                        if (Messages[i].Author == author)
                        {
                            findedMessages[authorMessCount] = Messages[i];
                            authorMessCount++;
                        }
                    return findedMessages;
                }
            }
            public void sortByTime()
            {
                var temp = new Message[Messages.Length];
                var tempTime = new int[Messages.Length];
                for (int j = temp.Length - 1; j >= 0; j--)
                {
                    int tempMax = Messages.Max(m => m.Time);
                    for (int i = 0; i < Messages.Length; i++)
                    {
                        if (tempMax == Messages[i].Time)
                        {
                            temp[j] = Messages[i];
                            tempTime[j] = Messages[i].Time;
                            Messages[i].Time = 0;
                        }
                    }
                }
                for (int i=0; i<temp.Length;i++)
                    temp[i].Time = tempTime[i];
                Messages = temp;
            }
            public string findAnswer(Message message)
            {
                foreach (var mess in Messages)
                    if (mess.ParentIndex == message.Index)
                        return mess.Text;
                return "";
            } 
            public void ShowMessages()
            {
                foreach (var mess in Messages)
                    Console.WriteLine($"{mess.Author}: {mess.Text}\tT:{mess.ConvertTime()}");
            }            
        }

        public class WebPage
        {
            public string Name { get; private set; }
            public WebPage() { Name = "Unknown"; }
            public WebPage(string name) { Name = name; }           
        }
        public class WebSite
        {
            private WebPage[] Pages;
            public WebSite(WebPage[] webPages) { Pages = webPages; }
            public void AddPage(WebPage page)
            {
                var temp = new WebPage[Pages.Length + 1];
                for (int i = 0; i < Pages.Length; i++)
                    temp[i] = Pages[i];
                temp[Pages.Length] = page;
                Pages = temp;
            }
            public void RemovePageAt(int index)
            {
                var temp = new WebPage[Pages.Length - 1];
                for (int i = 0; i < Pages.Length; i++)
                {
                    if (i == index)
                        continue;
                    int ind = i > index ? i - 1 : i;
                    temp[ind] = Pages[i];
                }                
                Pages = temp;
            }
            public void ShowPages()
            {
                foreach (var page in Pages)
                    Console.WriteLine(page.Name);
            }
        }
        static void Main(string[] args)
        {
            //Task1 Person Student Professor Subject
            Student st1 = new Student("Nick", "Koval", "Male", 23, "PM", 01, "MyEmail@gmail.com");
            Student st2 = new Student("Ivan", "Mohyla", "Male", 23, "PM", 02, "IvanEmail@gmail.com");
            Student st3 = new Student("Kate", "Bomba", "Female", 24, "PM", 03, "KateEmail@gmail.com");
            Professor professor = new Professor("Snape", "Severus", "Male", 42, "ProfessorEmail@gmail.com", "Professor");
            Subject subject = new Subject("DefenceFromDarkArts", professor);
            subject.AddStudent(st1);
            subject.AddStudent(st2);
            subject.AddStudent(st3);
            subject.ShowInfo();
            Console.WriteLine();

            //Task2 Book Library
            Book book1 = new Book("Foundation", "I. Asimov");
            Book book2 = new Book("Hourglass", "S. Nedorub");
            Book book3 = new Book("The Last Kingdom", "B. Cornwell");
            Book book4 = new Book("End of Eternity", "I. Asimov");
            Book book5 = new Book("Game of Thrones", "G. R. R. Martin");
            Book[] books = { book1, book2, book3, book4, book5 };
            Library library = new Library(books);
            Book Hourglass = library.findByName("Hourglass");
            Console.WriteLine($"Finded book {Hourglass.Name} by {Hourglass.Author}");
            Book[] Asimov = library.findByAuthor("I. Asimov");
            foreach (var book in Asimov)
                Console.WriteLine($"Finded book {book.Name} by {book.Author}");
            Console.WriteLine();

            //Task3. Video Playlist
            Video vid1 = new Video("Video1", 345);
            Video vid2 = new Video("Video2", 567);
            Video vid3 = new Video("Video3", 4777);
            Video[] videos = { vid1, vid2, vid3 };
            Playlist playlist = new Playlist(videos);
            playlist.ShowInfo();
            playlist.AddVideo(vid1);
            Console.WriteLine("Added vid1");
            playlist.ShowInfo();
            playlist.RemoveVideo();
            Console.WriteLine("Removed last vid");
            playlist.ShowInfo();
            playlist.SavePlaylist();
            Console.WriteLine();

            //Task4. Message Chat
            Message mess4 = new Message(4, 3, "My name? I've had a few. You can call me Root.", "Root", 543);
            Message mess1 = new Message(1, 0, "Hello", "Root", 540);
            Message mess3 = new Message(3, 2, "Who are you?", "Harold", 542);
            Message mess7 = new Message(7, 6, "And say I'm looking forward to the next time...", "Root", 546);
            Message mess2 = new Message(2, 1, "FBI paid me a visit. Good thing I travel light...", "Root", 541);
            Message mess6 = new Message(6, 5, "I wanted to acknowledge a worthy opponent.", "Root", 545);
            Message mess5 = new Message(5, 4, "Why did you contact me?", "Harold", 544);
            Message mess8 = new Message(8, 7, "...Harold.", "Root", 547);
            Message[] messages = { mess4, mess1, mess3, mess7, mess2, mess6, mess5, mess8 };
            Chat chat = new Chat(messages);
            Console.WriteLine("Unsorted Messages");
            chat.ShowMessages();
            Message[] Harold = chat.findByAuthor("Harold");
            Console.WriteLine("\nHarold Messages:");
            foreach (var mess in Harold)
                Console.WriteLine($"{mess.Text}\tT:{mess.ConvertTime()}");
            Console.WriteLine("\nAnswer to \"Who are you?\"");
            Console.WriteLine(chat.findAnswer(mess3));
            chat.sortByTime();
            Console.WriteLine("\nSorted Messages:");
            chat.ShowMessages();
            Console.WriteLine();

            //Task5. WebPage WebSite
            Console.WriteLine("SiteMap");
            WebPage page1 = new WebPage("Page1");
            WebPage page2 = new WebPage("Page2");
            WebPage page3 = new WebPage("Page3");
            WebPage page4 = new WebPage("Page4");
            WebPage[] webPages = { page1, page2, page3, page4 };
            WebSite webSite = new WebSite(webPages);
            webSite.ShowPages();
            Console.WriteLine("Added page2");
            webSite.AddPage(page2);
            webSite.ShowPages();
            Console.WriteLine("Removed page2 at position 2");
            webSite.RemovePageAt(1);
            webSite.ShowPages();
        }
    }
}