using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace ParaNamespace
{
    public class Para
    {
        public int columns { get; set; }

        public Para()
        {
            columns = 72;
        }

        public Para(int col)
        {
            if (col > 0) columns = col;
        }

        public String format(String text)
        {
            String[] lines = Regex.Split(text, @"\n(?:[ \t]*\n)");
            for (int i=0; i < lines.Length; i++ )
            {
                lines[i] = format_para(lines[i]);
            }
            return String.Join("\n\n", lines);
        }

        private String format_para(String text)
        {
            text = Regex.Replace(text, @"\A\s+", "");
            text = Regex.Replace(text, @"\s+\Z", "");
            Queue<String> words = new Queue<String>(Regex.Split(text, @"\s+"));
            
            String para = "";
            int cols_left = columns;

            while (words.Count > 0) {
                String word = words.Dequeue();
                int word_lenght = word.Length;
                if (cols_left > word_lenght)
                {
                    if (cols_left < columns) { para = String.Concat(para, " "); }
                    para = String.Concat(para, word);
                    cols_left -= word_lenght;
                }
                else if (word_lenght <= columns)
                {
                    para = String.Concat(para, "\n", word);
                    cols_left = columns - word_lenght;
                }
                else // word_lenght > columns
                {
                    String part = word.Substring(0, columns - 1);
                    para = String.Concat(para, "\n", part, "-\n");
                    cols_left = columns;
                    word = word.Substring(part.Length, word.Length - part.Length);
                    words.Enqueue(word);
                }
            }
            return para;
        }
    }
}
