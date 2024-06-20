using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Variant_6
{
    public class Task1
    {
        private Book[] books;
        public Book[] Books => books;

        public Task1(Book[] books)
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
        public struct Book
        {
            private static int ISBNCounter = 0;

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
                isbn = ISBNCounter++;
                this.author = author;
                this.year = year;
            }
            public override string ToString()
            {
                return $"Title = {Title}, ISBN = {ISBN}, author = {Author}, year = {Year}";
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
            int mid = (left+right) / 2;

            Book[] leftArray = MergeSort(array, left, mid);
            Book[] rightArray = MergeSort(array, mid + 1, right);

            return Merge(leftArray, rightArray);
        }
        private Book[] Merge(Book[] left, Book[] right)
        {
            Book[] result = new Book[left.Length+right.Length];
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i].Year <= right[j].Year)
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
    }
}
