using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace insertToUpdate
{
    class InsertToUpdate
    {

        public String readFile( String file )
        {
            String text = System.IO.File.ReadAllText( file );            
            return text;
        }

        public Boolean saveFile( String file, String text )
        {
            Boolean okConvertion = false;
            try
            {
                System.IO.File.WriteAllText(file, text);
                okConvertion = true;
            }
            catch
            {
                okConvertion = false;
            }
            
            return okConvertion;
        }

        String transform(String text)
        {
            // Delete comments
            String commentPattern = @"\/\*+[\w \n]*\*\/";
            Regex rgx = new Regex(commentPattern);
            text = rgx.Replace(text, "");

            commentPattern = @"\/\/.*";
            rgx = new Regex(commentPattern);
            text = rgx.Replace(text, "");

            commentPattern = @"\t|\n|\r";
            rgx = new Regex(commentPattern);
            text = rgx.Replace(text, ".");

            commentPattern = @"INSERT";
            rgx = new Regex(commentPattern);
            text = rgx.Replace(text, "\nINSERT");

            return text;
        }

        static void Main()
        {
            InsertToUpdate a = new InsertToUpdate();
            String path = @"D:\Downloads";

            

            String text = a.readFile( path + @"\test.sql");
            String textTransform = a.transform(text);
            a.saveFile(path + @"\test1.sql", textTransform);



            text = "One car red car blue car";
            string pat = @"(\w+)\s+(car)";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(text);
            int matchCount = 0;
            while(m.Success)
            {
                Console.WriteLine("Match" + (++matchCount));
                for(int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    Console.WriteLine("Group" + i + "='" + g + "'");
                    CaptureCollection cc = g.Captures;
                    for(int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        System.Console.WriteLine("Capture" + j + "='" + c + "', Position=" + c.Index);
                    }
                }
                m = m.NextMatch();
            }
        }
    }
    // This example displays the following output:
    //       Match1
    //       Group1='One'
    //       Capture0='One', Position=0
    //       Group2='car'
    //       Capture0='car', Position=4
    //       Match2
    //       Group1='red'
    //       Capture0='red', Position=8
    //       Group2='car'
    //       Capture0='car', Position=12
    //       Match3
    //       Group1='blue'
    //       Capture0='blue', Position=16
    //       Group2='car'
    //       Capture0='car', Position=21
}




