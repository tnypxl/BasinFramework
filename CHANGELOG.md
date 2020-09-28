## v1.2.7.1
* :green_heart: Add support for traditional By locators (#74)

## v1.2.7
* :heavy_plus_sign: Locate elements by multiple classes in an element's class attribute (#72) 

## v1.2.6
* :heavy_plus_sign: ::: Implemented `Locator.AtPosition(int position)` to allow choosing an element at a specific index when there are multiple with the same locator properties.
* :green_heart: ::: Updated GitHub build workflow to use docker-compose to spin up Selenoid and a custom version of The Internet (https://the-internet.herokuapp.com).
* :x: ::: Make `Element.Exists` obsolete and use the same code in `Element.Displayed`.

## v1.2.5
* **[NEW ✨]** Elements can be located based on properties it doesn't have.
  * To find a div tag with "foo" as a class name: `DivTag.WithClass("foo")`
  * To find a div tag without "foo" as a class name: `DivTag.WithClass("foo", false)`
* **[HOUSEKEEPING 🧹]** Added ability to configure "HideCommandPromptWindow". It is true by default.

## v1.2.4.1

* **[HOUSEKEEPING 🧹]** Add missing `Screen` and `ScreenComponent` base classes.

## v1.2.4

* **[NEW ✨]** Added `Use<TPage>()` method to PageCollection
* **[NEW ✨]** Added overloads for `Use<TPage>()` that returns the page instance

## v1.2.3

* **[NEW ✨]** Added `Screen` type equivalents for `PageMap`, `Page` and `Page<TPageMap>`
* **[HOUSEKEEPING 🧹]** Changed PageMap property protection level from public to protected (#58)
* **[HOUSEKEEPING 🧹]** Removed IHtmlElements interface
* **[HOUSEKEEPING 🧹]** Removed Interfaces directory
* **[HOUSEKEEPING 🧹]** Some minor cleanup

## v1.2.2

* **[FIX 💪🏾]** `Element.WithText("$|someString")` was not using the correct xpath to locate elements with text that ends with a given string

## v1.2.1

* **[NEW ✨]** Add capabilities from JSON config

## v1.2.0

* **[NEW ✨]** Add `Precedes()`, `Follows()`, `Child()`, and `Parent()` methods to `Locator() and Element()` classes.
  * Ex: `DivTag.Parent()` => Locates the parent of a `div` tag.
  * Ex: `DivTag.Child()` => Locates the child of a `div` tag.
  * Ex: `DivTag.Precedes(SpanTag)` => Locates a `div` tag that precedes another `span` tag.
  * Ex: `DivTag.Follows(SpanTag)` => Locates a `div` tag that follows another `span` tag.
* **[REFACTOR 🛠]** YET ANOTHER overhaul to web driver management. Here is the short list:
  * Added mapper classes that map the APIs of driver options and services for Firefox, Chrome, and IE to a common API. This has always been the goal with each iteration of this part of the framework. But this time I prioritized clarity and maintainability. 
  * Renamed Browser to BrowserSession to prevent namespace collisions with classes in `Basin.Core`.


## v1.1.3

* **[NEW ✨]** Added an `ElementTimeout` property to `IBrowserConfig` used in the `Element` class as a default inline timeout.
* **[NEW ✨]** Added an `IfTextMatches(string pattern)` method to `Element` class that returns the element if text matches and throws an error if it doesn't.
* **[HOUSEKEEPING 🧹]** Cleaned up `Element` class by removed unnecessary overload constructors. All element locations are based entirely on ILocatorBuilder.

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