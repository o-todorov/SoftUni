namespace Solid.Layouts
{
    class JsonLayout : ILayout
    {
        public string Template
        {
            get
            {
                return @"""log"": {{
  ""date"": ""{0}"",
  ""level"": ""{1}"",
  ""message"": ""{2}""
}},";
            }
        }
    }
}
