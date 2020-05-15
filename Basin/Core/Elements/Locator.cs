using System.Runtime.InteropServices;

namespace Basin.Core.Elements
{
    public static class Locator
    {
        private static string _xpathUrlAttrs = "@href|@src";
        private static string _xpathNSUri = "ancestor-or-self::*[last()]/@url";
        private static string _xpathLowerCase = XPathToLower();
        private static string _xpathNSPath = XPathUrlPath(_xpathNSUri);
        private static string _xpathHasProtocol = $"(starts-with({_xpathUrlAttrs},'http://') or starts-with({_xpathUrlAttrs},'https://'))";
        private static string _xpathIsInternal = $"starts-with({XPathUrl()},{XPathUrlDomain(_xpathNSUri)}) or {XPathEndsWith(XPathUrlDomain(), XPathUrlDomain(_xpathNSUri))}";
        private static string _xpathIsLocal = $"({_xpathHasProtocol} and starts-with({XPathUrl()},{XPathUrl(_xpathNSUri)}))";
        private static string _xpathIsPath = $"starts-with('{_xpathUrlAttrs}','/')";
        private static string _xpathIsLocalPath = $"starts-with({XPathUrlPath()},{_xpathNSPath})";
        private static string _xpathNormalizeSpace = "normalize-space()";
        private static string _xpathInternal = $"[not({_xpathHasProtocol}) or {_xpathIsInternal}]";
        private static string _xpathExternal = $"[{_xpathHasProtocol}) and not({_xpathIsInternal})]";
        private static string _escapeLiteral = char.ConvertFromUtf32(30);
        private static string _escapeParens = char.ConvertFromUtf32(31);
        private static string _regexStringLiteral = @"(""[^""\x1E]*""|'[^'\x1E]*'|=\s*[^\s\]\'\""]+)";
        private static string _regexEscapedLiteral = @"['""]?(\x1E+)['""]?";
        private static string _regexCSSWrapPseudo = @"(\x1F\)|[^\)])\:(first|limit|last|gt|lt|eq|nth)([^\-]|$)";
        private static string _regexSpecialChars = @"[\x1C-\x1F]+";
        private static string _regexFirstAxis = @"^([\s\(\x1F]*)(\.?[^\.\/\(]{1,2}[a-z]*:*)";
        private static string _regexFilterPrefix = @"(^|\/|\:)\[";
        private static string _regexAttrPrefix = @"([^\(\[\/\|\s\x1F])\@";
        private static string _regexNthEquation = @"^([-0-9]*)n.*?([0-9]*)$";
        private static string _cssCombinatorsRegex = @"\s*(!?[+>~,^ ])\s*(\.?\/+|[a-z\-]+::)?([a-z\-]+\()?((and\s*|or\s*|mod\s*)?[^+>~,\s'""\]\|\^\$\!\<\=\x1C-\x1F]+)?";
        private static string _cssPseudoClassesRegex = @":([a-z\-]+)(\((\x1F+)(([^\x1F]+(\3\x1F+)?)*)(\3\)))?";
        
        internal static string XPathToLower([Optional] string str) 
            => $"translate({str ?? "normalize-space()"},'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz')";

        internal static string XPathEndsWith(string str1, string str2) 
            => $"substring({str1}, string-length({str1})-string-length({str2})+1) = {str2}";

        internal static string XPathUrl([Optional] string str) 
            => $"substring-before(concat(substring-after({(str ?? _xpathUrlAttrs)},'://'),'?'),'?')";

        internal static string XPathUrlPath([Optional] string str) 
            => $"substring-after({str ?? _xpathUrlAttrs},'/')";

        internal static string XPathUrlDomain([Optional] string str) 
            => $"substring-before(concat(substring-after({str ?? _xpathUrlAttrs},'://'),'/'),'/')";

    }
}