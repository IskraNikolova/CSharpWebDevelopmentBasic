namespace Razor
{
    using System;
    using System.IO;
    using System.Text;

    public class Page
    {
        private readonly StringBuilder htmlContent;

        public Page(string htmlPath)
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
            if (Cookies.cookies["theme"] == "dark")
            {
                this.AddStyleByPath("css/dark-nav.css");
            }
            else
            {
                this.AddStyleByPath("css/light-nav.css");
            }
            return this.htmlContent.ToString();
        }
    }
}
