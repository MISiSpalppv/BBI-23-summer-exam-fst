using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using System.Linq;

namespace Variant_6
{
    public class Task3
    {
        public class Reverter
        {
            public string Input { get; private set; }
            public string Output { get; private set; }

            public Reverter(string input)
            {
                Input = input;
                Output = ReverseWords(input);
            }

            private string ReverseWords(string input)
            {
                if (string.IsNullOrEmpty(input))
                {
                    return string.Empty;
                }

                var words = input.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    char[] chars = words[i].ToCharArray();
                    Array.Reverse(chars);
                    words[i] = new string(chars);
                }

                return string.Join(' ', words);
            }

            public override string ToString()
            {
                return string.IsNullOrEmpty(Input) ? string.Empty : Output;
            }
        }
    }
}