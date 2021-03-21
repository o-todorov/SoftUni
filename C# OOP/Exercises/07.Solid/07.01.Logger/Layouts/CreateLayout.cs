using System;

namespace Solid.Layouts
{
    class CreateLayout
    {
        public static ILayout GetLayout(string layoutType)
        {
            if (layoutType == nameof(SimpleLayout))
            {
                return new SimpleLayout();
            }
            else if (layoutType == nameof(XmlLayout))
            {
                return new XmlLayout();
            }
            else if (layoutType == nameof(JsonLayout))
            {
                return new JsonLayout();
            }
            else
            {
                throw new ArgumentException($"Layout type: {layoutType} unknown");
            }
        }
    }
}
