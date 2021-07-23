using System;

using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "JsonLayout")
            {
                layout = new JsonLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else if (type == "JsonLayout")
            {
                layout = new JsonLayout();
            }
            else
            {
                throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}
