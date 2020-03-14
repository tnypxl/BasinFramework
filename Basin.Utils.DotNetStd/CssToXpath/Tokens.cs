namespace Basin.Utils.CssToXpath {
    public class Token {
        private readonly string _contents;

        public Token(string contents) => this._contents = contents;

        public string Contents => this._contents;
    }

    public class Symbol : Token {
        public Symbol(string contents) : base(contents) { }
    }

    public class Str : Token {
        public Str(string contents) : base(contents) { }
    }
}