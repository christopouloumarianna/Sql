using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;


namespace ContentManagement
{
    public class SimpleText : IContect
    {

        List<string> setences
            = new List<string>();

        public SimpleText()
        {
        }

        //string sente = "ola einai";
        //string [] words = sente.Split(" ");
        public int CountWords()
        {
            int numberOfWords = 0;
            foreach (string sentence in setences)
            {
                string[] words = sentence.Split(' ');
                numberOfWords += words.Length;

            }

            return numberOfWords;

        }

        public string GetLengthiestWords()
        {
            int numberOfWords = 0;
            string maxValue = null;
            foreach (string sentence in setences)
            {
                string[] words = sentence.Split(' ');
                numberOfWords += words.Length;

                foreach (string w in words)
                {
                    if (maxValue.Length < w.Length)
                    {
                        maxValue = w;
                    }
                }


            }


            return maxValue;
        }


        public bool LoadText(string filename)
        {
            try
            {

                var list = new List<string>();
                var fileStream = new FileStream(@"file.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                foreach (String l in list)
                {
                    Console.WriteLine("....................");
                    Console.WriteLine(l);
                }

            }

            catch (Exception e)
            {
                return false;

            }
            return true;


        }

        public bool SaveText(string filename)
        {
            throw new NotImplementedException();
        }
    }
}