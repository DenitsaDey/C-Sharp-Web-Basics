﻿namespace SUS.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Header(string headerLine)
        {
            // Cache-Control: max-age=0
            var headerParts = headerLine.Split(new string[] { ": " }, 2, System.StringSplitOptions.None);
            this.Name = headerParts[0];
            this.Value = headerParts[1];
        }
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}