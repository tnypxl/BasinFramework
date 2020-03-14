namespace Basin.Utils.CssToXpath.Selectors {
    public class CombinedSelector : ISelector {
        private readonly char _combinator;
        private readonly ISelector _selector;
        private readonly ISelector _subselector;

        public CombinedSelector(ISelector selector, char combinator, ISelector subselector) {
            this._selector = selector;
            this._combinator = combinator;
            this._subselector = subselector;
        }

        public XPathExpr GetXPath()
        {
            return this._combinator switch
            {
                ' ' => this.MakeSimpleJoined("/descendant::"),
                '>' => this.MakeSimpleJoined("/"),
                '+' => this.MakeDirectAdjacent(),
                '~' => this.MakeSimpleJoined("/following-sibling::"),
                _ => throw new ExpressionException($"Unknown combinator: {this._combinator}")
            };
        }

        private XPathExpr MakeSimpleJoined(string combiner) {
            var result = this._selector.GetXPath();
            result.Join(combiner, this._subselector.GetXPath());
            return result;
        }

        private XPathExpr MakeDirectAdjacent() {
            var result = this.MakeSimpleJoined("/following-sibling::");
            result.AddNameTest();
            result.AddCondition("position() = 1");
            return result;
        }
    }
}