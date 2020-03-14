using System;
using System.Collections.Generic;

namespace Basin.Utils.CssToXpath {
    public class TokenStream : Queue<Token> {
        public TokenStream(IEnumerable<Token> items) : base(items) { }

        public Token Next() {
            Token next;
            try {
                next = this.Dequeue();
            } catch (InvalidOperationException) {
                return new Token("");
            }

            return next;
        }

        public new Token Peek() {
            Token peek;
            try {
                peek = base.Peek();
            } catch (InvalidOperationException) {
                return new Token("");
            }

            return peek;
        }
    }
}