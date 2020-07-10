## Release 1.1.3

* **[NEW ✨]** Added an `ElementTimeout` property to `IBrowserConfig` used in the `Element` class as a default inline timeout.
* **[NEW ✨]** Added an `IfTextMatches(string pattern)` method to `Element` class that returns the element if text matches and throws an error if it doesn't.
* **[HOUSEKEEPING 🧹]** Cleaned up `Element` class by removed unnecessary overload constructors. All element locations are based entirely on ILocatorBuilder.
