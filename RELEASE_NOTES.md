==== v1.1.0-alpha2
* Refactored driver instance management to use decorators which provides a common api between all the browsers.
* Moved majority of browser/driver code out of `Basin.Selenium` namespace to `Basin.Core.Browsers`.
* [BREAKING CHANGE] `Driver()` class has been renamed to `Browser()`.


