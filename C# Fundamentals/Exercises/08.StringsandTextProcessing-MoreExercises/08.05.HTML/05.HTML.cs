using System;
using System.Text;

namespace _08._05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<h1>")
                .Append("\t")
                .AppendLine(Console.ReadLine())
                .AppendLine("</h1>");

            sb.AppendLine("<article>")
                .Append("\t")
                .AppendLine(Console.ReadLine())
                .AppendLine("</article>");

            string comment;

            while ((comment = Console.ReadLine())!= "end of comments")
            {
                sb.AppendLine("<div>")
                    .Append("\t")
                    .AppendLine(comment)
                    .AppendLine("</div>");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}


//SoftUni Article
//Some content of the SoftUni article
//some comment
//more comment
//last comment
//end of comments


//<h1>
//    SoftUni Article
//</h1>
//<article>
//    Some content of the SoftUni article
//</article>
//<div>
//    some comment
//</div>
//<div>
//    more comment
//</div>
//<div>
//    last comment
//</div>
