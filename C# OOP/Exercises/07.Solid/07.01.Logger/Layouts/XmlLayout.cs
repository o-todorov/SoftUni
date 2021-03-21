using System.Text;

namespace Solid.Layouts
{
    class XmlLayout : ILayout
    {
        public string Template 
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine("<log>");
                sb.AppendLine("\t<date>{0}</date>");
                sb.AppendLine("\t<level>{1}</level>");
                sb.AppendLine("\t<message>{2}</message>");
                sb.AppendLine("</log>");

                return sb.ToString();
            }
        } 
    }
}
