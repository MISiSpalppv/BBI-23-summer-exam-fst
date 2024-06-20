using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Variant_6
{
    public class Task2
    {
        private Book[] books;
        public Book[] Books => books;

        public Task2(Book[] books)
        {
            this.books = books;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var book in books)
            {
                result += book.ToString() + "\n";
            }
            return result;
        }

        public abstract class Book
        {
            private static int isbnCounter = 0;

            private string title;
            private int isbn;
            private string author;
            private int year;

            public string Title => title;
            public string Author => author;
            public int Year => year;
            public int ISBN => isbn;

            public Book(string title, string author, int year)
            {
                this.title = title;
                this.isbn = isbnCounter++;
                this.author = author;
                this.year = year;
            }

            public abstract double Cost();

            public override string ToString()
            {
                return $"Type = {this.GetType().Name}, ISBN = {ISBN}";
            }

            public static Book[] Select(Book[] bookArray, string author)
            {
                int count = 0;
                foreach (var book in bookArray)
                {
                    if (book.Author == author)
                    {
                        count++;
                    }
                }
                Book[] result = new Book[count];
                int index = 0;
                foreach (var book in bookArray)
                {
                    if (book.Author == author)
                    {
                        result[index++] = book;

                    }
                }
                return result;
            }
            public static Book[] Select(Book[] bookArray, int year)
            {
                int count = 0;
                foreach (var book in bookArray)
                {
                    if (book.Year == year)
                    {
                        count++;
                    }
                }
                Book[] result = new Book[count];
                int index = 0;
                foreach (var book in bookArray)
                {
                    if (book.Year == year)
                    {
                        result[index++] = book;
                    }
                }
                return result;
            }
        }

        public void Sorting()
        {
            books = MergeSort(books, 0, books.Length - 1);
        }


        private Book[] MergeSort(Book[] array, int left, int right)
        {
            if (left >= right)
            {
                return new Book[] { array[left] };
            }
            int mid = (left + right) / 2;

            Book[] leftArray = MergeSort(array, left, mid);
            Book[] rightArray = MergeSort(array, mid + 1, right);

            return Merge(leftArray, rightArray);
        }
        private Book[] Merge(Book[] left, Book[] right)
        {
            Book[] result = new Book[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i].Cost() <= right[j].Cost())
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }
            while (i < left.Length)
            {
                result[k++] = left[i++];
            }
            while (j < right.Length)
            {
                result[k++] = right[j++];
            }
            return result;
        }
        public class PaperBook : Book
        {
            public bool IsHardCover { get; }

            public PaperBook(string title, string author, int year, bool isHardCover)
                : base(title, author, year)
            {
                IsHardCover = isHardCover;
            }

            public override double Cost()
            {
                return 500 + (DateTime.Now.Year - Year) + (IsHardCover ? 150 : 0);
            }

            public override string ToString()
            {
                return $"Type = {this.GetType().Name}, ISBN = {ISBN}, spec = {IsHardCover}";
            }
        }

        public class ElectronicBook : Book
        {
            public string Format { get; }

            public ElectronicBook(string title, string author, int year, string format)
                : base(title, author, year)
            {
                Format = format;
            }

            public override double Cost()
            {
                double multiplier = Format switch
                {
                    "pdf" => 0.8,
                    "fb2" => 0.6,
                    "epub" => 0.95,
                    _ => 0.6
                };
                return 500 + (DateTime.Now.Year - Year) * multiplier;
            }

            public override string ToString()
            {
                return base.ToString() + $", Format = {Format}";
            }
        }

        public class AudioBook : Book
        {
            public bool IsStudioRecord { get; }

            public AudioBook(string title, string author, int year, bool isStudioRecord)
                : base(title, author, year)
            {
                IsStudioRecord = isStudioRecord;
            }

            public override double Cost()
            {
                return 500 + (DateTime.Now.Year - Year) * (IsStudioRecord ? 0.8 : 0.6);
            }

            public override string ToString()
            {
                return base.ToString() + $", IsStudioRecord = {IsStudioRecord}";
            }
        }
    }
}