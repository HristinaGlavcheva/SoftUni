using System.Text;

namespace _1._Rhombus_of_Stars
{
    public class RhombusAsStringDrawer
    {
        public string Draw(int size)
        {
            StringBuilder sb = new StringBuilder();
            this.DrawTopPart(size, sb);
            this.DrawLineOfStars(size, sb, size);
            this.DrawBottomPart(size, sb);
            
            return sb.ToString();
        }
        
        private void DrawTopPart(int size, StringBuilder sb)
        {
            for (int currentRowNumber = 1; currentRowNumber <= size - 1; currentRowNumber++)
            {
                DrawLineOfStars(size, sb, currentRowNumber);
            }
        }

        private void DrawBottomPart(int size, StringBuilder sb)
        {
            for (int currentRowNumber = size - 1; currentRowNumber >= 1; currentRowNumber--)
            {
                DrawLineOfStars(size, sb, currentRowNumber);
            }
        }

        private void DrawLineOfStars(int size, StringBuilder sb, int currentRowNumber)
        {
            sb.Append(new string(' ', size - currentRowNumber));

            for (int star = 1; star <= currentRowNumber; star++)
            {
                sb.Append("* ");
            }

            sb.AppendLine();
        }
    }
}
