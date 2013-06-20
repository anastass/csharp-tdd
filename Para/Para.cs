using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParaNamespace
{
    /// <summary>
    /// Format text
    /// </summary>
    public class Para
    {
        /// <summary>
        /// Number of instances 
        /// </summary>
        public static int count;    // BAD PRACTICE: for testing only

        /// <summary>
        /// Default number of characters
        /// </summary>
        const int DEFAULT_COLUMNS = 72;

        /// <summary>
        /// Detrmines number of characters per line
        /// </summary>
        public int columns { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Para()
        {
            Init(DEFAULT_COLUMNS);
        }

        /// <summary>
        /// Constructor with colums initialization
        /// </summary>
        /// <param name="col">Number of characters per column</param>
        /// <see cref="ParaNamespace.Para.Init"/>
        public Para(int col)
        {
            // to access instance variable use this.<v> [= <value>]; this.columns;
            // to access class variable use <class>.<v> [= <value>]; Para.count;
            Init(col);
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="col">Number of characters per column</param>
        protected void Init(int col)
        {
            Para.count++;   // Init is called for every instance, here we can make a test how to use class property
            if (col > 0) columns = col;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Para()
        {
            Para.count--;
        }

        /// <summary>
        /// Format text containing one or more paragraphs
        /// </summary>
        /// <param name="text">Text to be formatted</param>
        /// <returns>Formatted text</returns>
        public String format(String text)
        {
            String[] lines = Regex.Split(text, @"\n(?:[ \t]*\n)");
            for (int i=0; i < lines.Length; i++ )
            {
                lines[i] = format_para(lines[i]);
            }
            return String.Join("\n\n", lines);
        }

        /// <summary>
        /// Format paragraph
        /// </summary>
        /// <param name="text">Paragraph to be formatted</param>
        /// <returns>Formatted paragraph</returns>
        /// <seealso cref="Para.format"/>
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
