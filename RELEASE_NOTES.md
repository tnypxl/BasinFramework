## v1.2.0

* **[NEW ✨]** Add `Precedes()`, `Follows()`, `Child()`, and `Parent()` methods to `Locator() and Element()` classes.
  * Ex: `DivTag.Parent()` => Locates the parent of a `div` tag.
  * Ex: `DivTag.Child()` => Locates the child of a `div` tag.
  * Ex: `DivTag.Precedes(SpanTag)` => Locates a `div` tag that precedes another `span` tag.
  * Ex: `DivTag.Follows(SpanTag)` => Locates a `div` tag that follows another `span` tag.
* **[REFACTOR 🛠]** YET ANOTHER overhaul to web driver management. Here is the short list:
  * Added mapper classes that map the APIs of driver options and services for Firefox, Chrome, and IE to a common API. This has always been the goal with each iteration of this part of the framework. But this time I prioritized clarity and maintainability. 
  * Renamed Browser to BrowserSession to prevent namespace collisions with classes in `Basin.Core`.
