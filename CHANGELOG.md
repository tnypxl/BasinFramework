v0.0.8 ==========================================================
* **[FIX]** PageCollections would throw a duplicate key error. It just returns if the key already exists.
* **[NEW]** New `Locator()` class that builds an XPath selector for you and returns `By.XPath`. If more advance XPath usage is need, Just use the existing `Locate` methods.
  * Usage: `new Locator("table").WithId("earningsTable").By;`
* **[NEW]** Add semantic locate methods. Its possible that there are some missing elements not very commonly used for browser automation. These initial methods should cover most if not all use cases. The `Element()` class was updated with an overload constructor that uses the new `Locator()` class.
  * Current: `public Element LoginButton => Locate(By.CssSelector(".loginBtn"))`;
  * New: `public Element LoginButton => Button.WithClass("loginBtn");`