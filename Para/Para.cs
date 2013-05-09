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
            return this.format_para(text);
        }

        private String format_para(String text)
        {
            text = Regex.Replace(text, @"\A\s+", "");
            text = Regex.Replace(text, @"\s+\Z", "");
            String[] result = Regex.Split(text, @"\s+");
            return String.Join(" ", result);
        }
    }
}
