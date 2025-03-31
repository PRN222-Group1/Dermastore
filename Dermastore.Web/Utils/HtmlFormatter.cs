using Microsoft.AspNetCore.Components;

namespace Dermastore.Web.Utils
{
    public static class HtmlFormatter
    {
        public static MarkupString FormatContent(string? content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return new MarkupString(string.Empty);
            }

            // Use a more robust way to replace markdown-style bold (**text**) with HTML bold
            content = System.Text.RegularExpressions.Regex.Replace(content, @"\*\*(.+?)\*\*", "<strong>$1</strong>");

            // Replace newlines with <br /> for line breaks
            content = content.Replace("\n", "<br />");

            return new MarkupString(content);
        }

        // New method to truncate the content after formatting
        public static MarkupString FormatContentWithSubstring(string? content, int length)
        {
            // First format the content
            var formattedContent = FormatContent(content);

            // Convert the MarkupString to a raw string
            var rawContent = formattedContent.ToString();

            // Apply Substring and add ellipsis if the content is longer than the specified length
            var truncatedContent = rawContent.Length > length
                ? rawContent.Substring(0, length) + "..."
                : rawContent;

            // Return as a MarkupString
            return new MarkupString(truncatedContent);
        }
    }
}
