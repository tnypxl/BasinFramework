# Basin Framework

An opinionated browser test framework for Selenium WebDriver. There are
many like this one. The goal here was to build something that was easy
to implement while still providing flexibility without over abstracting.

## Getting stared

### Install 

```
$ dotnet add package BasinFramework
```
### Configuration

Create a JSON file at the root of your project

```json
{
    "DefaultSite": "integration",

    "Sites": [
        {
            "Name": "staging",
            "Url": "https://staging.coolapp.com"
        },
        {
            "Name": "integration",
            "url": "https://integration.coolapp.com"
        },
        {
            "Name": "preprod",
            "url": "http://preprod.coolapp.com"
        }
    ],

    "Logins": [
        {
            "Role": "Customer",
            "Username": "JordanTheGOAT",
            "Password":  "givemetheball" 
        },
        {
            "Role": "Admin",
            "Username": "lebronjaymes",
            "Password": "foulsmakemecry"
        }
    ],

    "Driver": {
        "Browser": "chrome",
        "Timeout": 10
    }
}
```

Initialize the config file:

```csharp
BSN.SetConfig("path/to/json/config/file.json");
```

Then you access config data with `BSN.Config`

```csharp
BSN.Config.DefaultSite; // returns "integration"
BSN.Config.Driver.Browser; // returns "chrome"
BSN.Config.Site.Url; // Gets a site based on DefaultSite
BSN.Config.Login("Admin").Username; // Gets a login by Role
```

### Start a browser session

By default, all the drivers are configured with a clean slate. That just means there are no browser flags or custom binary paths being set initially. Starting up a browser and going to a url is 2 lines of code.

```csharp
// Uses the values defined in `Drivers` from the json config file.
// It also maximizes the window automatically.
Driver.Init(); 

// Just goes to a given url
Driver.Goto("http://someurl");
```

For the most part, nothing else is needed. But if you need to access the `IWebDriver` instance, you just call `Driver.Current`.

### Use your own `IWebDriver` instance

Maybe you already have code written to manage driver instances. Just don't call `Driver.Init()`. Instead just set the instance like this with your own instance of `IWebDriver`.

```csharp
Driver.Current = new FirefoxDriver();
Driver.Goto("http://someurl");
```

Now Basin will use this throughout the rest of the framework.


### Creating simple page object class

Basin provides classes and interfaces to ease the pain of building page object frameworks. Let's say I'm defining a login page.

```csharp
using Basin.Selenium;
using Basin.Pages;
using OpenQA.Selenium;

namespace Example
{
	public class LoginPage : Page
	{	
		// Page elements
		public Element UsernameField => Locate(By.Id("userName"));
		public Element PasswordField => Locate(By.Id("password"));
		public Element Submit => Locate(By.CssSelector("button[name='submitLogin']"));
		
		// Page behavior
		public void Login(string username, string password)
		{
			UsernameField.SendKeys(username);
			PasswordField.SendKeys(password);
			Submit.Click();
		}
	}
}
```

Let's start with the `Page` class that `LoginPage` inherits from. `Page` is an abstract class that provides a handful of locator methods with some overloads. There are 4 locator methods, each with an overload to allow setting an optional timeout.

```csharp
// Gets a single IWebElement
Locate(By by, [int timeout]);

// Gets a single IWebElement inside a parent IWebElement
LocateInside(By by, By parentBy, [int timeout]) 

// Gets multiple IWebElement(s)
LocateAll(By by, [int timeout]) 

// Gets multiple IWebElement(s) inside a parent IWebElement
LocateAllInside(By by, By parentBy, [int timeout]) 
```

### Creating a page object map

Page object classes can grow very large over time. I've found it incredibly difficult to retain readability and clarity with a single class. So instead of keeping everything in a single massive class, I break it down into to 2 classes. A page class for behaviors and a page map class for storing the element locators. Below its how its accomplished:

```csharp
using Basin.Selenium;
using Basin.Pages;
using OpenQA.Selenium;

namespace Example
{
	// This class no longer includes locator methods.
	// The goal is to only put behavior methods in this class.
	
	public class LoginPage : Page<LoginPageMap>
	{
		public LoginPage() 
		{
			Map = new LoginPageMap();
		}
		// Page behavior
		public void LoginWith(string username, string password)
		{
			Map.UsernameField.SendKeys(username);
			Map.PasswordField.SendKeys(password);
			Map.Submit.Click();
		}
	}
	
	// PageMap provides the locator methods.
	// The goal is to only put Element definitions in this class.
	public class LoginPageMap : PageMap
	{
		public Element UsernameField => Locate(By.Id("userName"));
		public Element PasswordField => Locate(By.Id("password"));
		public Element Submit => Locate(By.CssSelector("button[name='submitLogin']"));
	}
}
```

Now I have clean separate APIs for calling page elements and behaviors. Page map classes can be used by other classes that require the same element locators. 

How page objects should be organized is quite subjective, but the goal of these interfaces base abstract classes is to provide a simple foundation.

## Contribute

1. Fork the repo
2. Create a branch
3. Create a PR based on your fork branch

## Credit

Thanks to [ElSnoMan](https://github.com/ElSnoMan) and
[Test Automation University](https://testautomationu.applitools.com/)
from Applitools for this [Course](https://testautomationu.applitools.com/test-automation-framework-csharp/)

Basin is based on and heavily inspired by the source code from [this repo](https://github.com/ElSnoMan/from-scripting-to-framework)



