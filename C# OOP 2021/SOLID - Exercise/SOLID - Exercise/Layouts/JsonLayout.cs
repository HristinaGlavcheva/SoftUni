using System.Text;

namespace SOLID___Exercise.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Format
            => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine("{{")
                .AppendLine("log: ")
                .AppendLine("date: {0}")
                .AppendLine("level: {1}")
                .AppendLine("message: {2}")
                .AppendLine("}}");

            return sb.ToString().TrimEnd();
        }
    }
}
