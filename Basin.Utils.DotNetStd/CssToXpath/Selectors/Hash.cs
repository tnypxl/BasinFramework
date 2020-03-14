namespace Basin.Utils.CssToXpath.Selectors {
    public class Hash : ISelector {
        private readonly string _id;
        private readonly ISelector _selector;

        public Hash(ISelector selector, string id) {
            this._selector = selector;
            this._id = id;
        }

        public XPathExpr GetXPath() {
            var path = this._selector.GetXPath();
            path.AddCondition($"@id = '{this._id}'");
            return path;
        }
    }
}