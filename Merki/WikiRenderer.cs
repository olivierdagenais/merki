using Textile;

namespace Merki
{
    public class WikiRenderer
    {
        StringBuilderTextileFormatter output;
        TextileFormatter formatter;

        public WikiRenderer()
        {
            output = new StringBuilderTextileFormatter();
            formatter = new TextileFormatter(output);
        }

        public string Render(string text)
        {
            formatter.Format(text);
            var result = output.GetFormattedText();
            return result;
        }
    }
}
