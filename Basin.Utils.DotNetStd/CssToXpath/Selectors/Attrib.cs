using System;

namespace Basin.Utils.CssToXpath.Selectors {
    public class Attrib : ISelector {
        private readonly string _attrib;
        private readonly string _namespace;
        private readonly string _operator;
        private readonly ISelector _selector;
        private readonly string _value;

        public Attrib(ISelector selector, string xNamespace, string attrib, string oper, string value) {
            this._selector = selector;
            this._namespace = xNamespace;
            this._attrib = attrib;
            this._operator = oper;
            this._value = value;
        }

        public XPathExpr GetXPath() {
            var result = this._selector.GetXPath();
            var attribute = this._namespace == "*" ? ("@" + this._attrib) : $"@{this._namespace}:{this._attrib}";

            switch (this._operator) {
                case "exists":
                    if (!string.IsNullOrEmpty(this._value)) {
                        throw new ExpressionException("Value should be empty");
                    }
                    result.AddCondition(attribute);
                    break;
                case "=":
                    result.AddCondition($"{attribute} = '{this._value}'");
                    break;
                case "!=":
                    if (string.IsNullOrEmpty(this._value)) {
                        result.AddCondition($"{attribute} != '{this._value}'");
                    } else {
                        result.AddCondition($"not({attribute}) or {attribute} != '{this._value}'");
                    }
                    break;
                case "~=":
                    result.AddCondition($"contains(concat(' ', normalize-space({attribute}), ' '), ' {this._value} ')");
                    break;
                case "|=":
                    result.AddCondition($"{attribute} = '{this._value}' or starts-with({attribute}, '{this._value}-')");
                    break;
                case "^=":
                    result.AddCondition($"starts-with({attribute}, '{this._value}')");
                    break;
                case "$=":
                    result.AddCondition($"substring({attribute}, string-length({attribute})-{this._value.Length - 1}) = '{this._value}'");
                    break;
                case "*=":
                    result.AddCondition($"contains({attribute}, '{this._value}')");
                    break;
                default:
                    throw new NotImplementedException($"Operator {this._operator} is not supported");
            }

            return result;
        }
    }
}