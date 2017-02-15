namespace Razor
{
    using System;
    using System.IO;
    using System.Text;

    public abstract class Page
    {
        private readonly StringBuilder htmlContent;

        protected Page(string htmlPath)
        {
            this.htmlContent = new StringBuilder(File.ReadAllText(htmlPath));
        }

        public void AddStyleByPath(string cssPath)
        {
            int headClosingIndex = this.htmlContent.ToString().IndexOf("</head", StringComparison.Ordinal);
            this.htmlContent.Insert(headClosingIndex, $"<link rel=\"stylesheet\" href=\"{cssPath} \"/>");
        }

        public override string ToString()
        {
            return this.htmlContent.ToString();
        }
    }
}
