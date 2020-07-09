## v1.1.2

* [FIX] Classes can't be named identically to namespaces. Renamed `Basin()` class to `BasinEnv()` to fix namespace issues, but also to be more indicitive of its purpose.

## v1.1.1

* **[NEW]** Added more html tags.
* **[STRUCTURAL]** Renamed static `Driver` class to `Browser`
* **[STRUCTURAL]** Renamed `BSN` to `Basin`.

## v1.1.0

This is mostly comprised of underlying structural changes and CI/CD updates.

* **[NEW]** Automated nuget publishing and github releases
* **[BREAKING CHANGE]** ~~`BSN.*` is now `Basin.*`~~
* **[BREAKING CHANGE]** `DriverFactory()` renamed to `BrowserFactory()` and updated to use decorators


## v0.0.8 

* **[FIX]** PageCollections would throw a duplicate key error. It just returns if the key already exists.
* **[NEW]** New `Locator()` class that builds an XPath selector for you and returns `By.XPath`. If more advance XPath usage is need, Just use the existing `Locate` methods.
  * Usage: `new Locator("table").WithId("earningsTable").By;`
* **[NEW]** Add semantic locate methods. Its possible that there are some missing elements not very commonly used for browser automation. These initial methods should cover most if not all use cases. The `Element()` class was updated with an overload constructor that uses the new `Locator()` class.
  * Current: `public Element LoginButton => Locate(By.CssSelector(".loginBtn"))`;
  * New: `public Element LoginButton => Button.WithClass("loginBtn");`