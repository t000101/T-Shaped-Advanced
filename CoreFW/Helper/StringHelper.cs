using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreFW.Helper
{
    public class StringHelper
    {
        public static string GenerateDownloadedFileName(string name, string photoId)
        {
            Regex regex = new Regex("[^a-zA-Z0-9]");
            name = regex.Replace(name, "-").Replace("--", "-").ToLower();
            string filename = $"{name}-{photoId}-unsplash.jpg";
            return filename;

        }

        public static string GenerateRandomString(int lenght)
        {
            Random rnd = new Random();
            // String that contain both alphabets and numbers
            string str = "abcdefghijklmnopqrstuvwxyz0123456789";
            // Initializing the empty string
            string randomstring = "";

            for (int i = 0; i < lenght; i++)
            {
                // Selecting a index randomly
                int x = rnd.Next(str.Length);
                // Appending the character at the 
                // index to the random alphanumeric string.
                randomstring = randomstring + str[x];
            }

            return randomstring;
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }
        public static string CapitalizeString(string text, string[] wordWantLower)
        {
            string[] splipString = text.Split(' ');
            List<string> listChar = new List<string>();
            var response = new StringBuilder(); 
            int temp = 0;
            for (int i = 0; i < splipString.Length; i++)
            {
                for (int j = 0; j < wordWantLower.Length; j++)
                {
                    if (splipString[i] == wordWantLower[j])
                    {
                        string newWord = splipString[i].ToLower();
                        listChar.Add(newWord);
                        temp += 1;
                    }
                }
                if (temp < splipString.Length)
                {
                    listChar.Add(splipString[i]);
                    temp+=1;
                }
            }
            foreach(var word in listChar)
            {
                response.Append(word).Append(" ");
            }
           return response.Replace(" ","").ToString();
        }
    }
}
