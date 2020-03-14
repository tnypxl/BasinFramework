# Basin Framework
An opinionated browser test framework for Selenium WebDriver

Selenium Webdriver's API is decent, but limiting. It's not really designed to be a standalone framework unto itself. It begs to be extended. This framework is one such attempt to do that.

Also 98% of the credit for this framework goes to [ElSnoMan](github.com/ElSnoMan) and [Test Automation University](https://testautomationu.applitools.com/) from Applitools.

Source Code:
https://github.com/ElSnoMan/from-scripting-to-framework

Course:
https://testautomationu.applitools.com/test-automation-framework-csharp/

## Install 

```
dotnet add package BasinFramework.Selenium
```

## Usage

### Add the `using`

```csharp
// SomePage.cs

using Basin.Selenium;

// <Your well-organized, cleanly coded, page object code>
```

### Create a browser instance

```csharp
// Initialize instance chromedriver
Driver.Init("chrome"); 

// Open chrome browser with a provided url
Driver.Goto("https://google.com");

// Return the current instance of the driver
Driver.Current;
```

### Define elements

```csharp
public Element Username => Driver.Locate(By.Id("loginUsername"));
public Element Password => Driver.Locate(By.Id("loginPassword"));
public Element Submit => Driver.Locate(By.CssSelector("button[name='submitLogin']"));
public Elements CategoryList => Driver.LocateAll(By.CssSelector("ul li.productCategory"));
```

### Wait on elements

```csharp
Driver.Wait.Until(WaitConditions.ElementDisplayed(Username));
Driver.Wait.Until(WaitConditions.ElementsNotEmpty(CategoryList));
```


