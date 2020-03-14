using System.Text.RegularExpressions;

namespace Basin.Utils.CssToXpath {
    public static class Converter {
        private static readonly Regex ElementRegex = new Regex(@"^\w+\s*$");
        private static readonly Regex IdRegex = new Regex(@"^(\w*)#(\w+)\s*$");
        private static readonly Regex ClassRegex = new Regex(@"^(\w*)\.(\w+)\s*$");

        public static string CSSToXPath(string expr, string prefix = "descendant-or-self::") {
            var elementMatch = ElementRegex.Match(expr);
            if (elementMatch.Success) {
                return $"{prefix}{elementMatch.Value.Trim()}";
            }

            var idMatch = IdRegex.Match(expr);
            if (idMatch.Success) {
                return
                    $"{prefix}{(string.IsNullOrEmpty(idMatch.Groups[1].Value) ? "*" : idMatch.Groups[1].Value)}[@id = '{idMatch.Groups[2].Value}']";
            }

            var classMatch = ClassRegex.Match(expr);
            if (classMatch.Success) {
                return
                    $"{prefix}{(string.IsNullOrEmpty(classMatch.Groups[1].Value) ? "*" : classMatch.Groups[1].Value)}[contains(concat(' ', normalize-space(@class), ' '), ' {classMatch.Groups[2].Value} ')]";
            }

            var selector = Parser.Parse(expr);
            var xpath = selector.GetXPath();
            if (!string.IsNullOrEmpty(prefix)) {
                xpath.AddPrefix(prefix);
            }

            return xpath.ToString();
        }
    }
}
