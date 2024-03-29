
# Basin Framework

![Basin Build](https://github.com/tnypxl/BasinFrameworkDotNetCore/workflows/Basin%20Build/badge.svg)

An opinionated browser test framework for Selenium WebDriver. There are many like this one. The goal here was to build something that was easy to implement while still providing flexibility without over abstracting.

## Getting stared

### Install

```shell
dotnet add package BasinFramework
```

### Configuration

Create a JSON file at the root of your project

```json
{
    "Environment": {
        "Site": "integration",
        "Browser": "Local Chrome",
        "Login": "lebronjaymes"
    },

    "Sites": [
        {
            "Id": "staging",
            "Url": "https://staging.coolapp.com"
        },
        {
            "Id": "integration",
            "Url": "https://integration.coolapp.com"
        },
        {
            "Id": "preprod",
            "Url": "http://preprod.coolapp.com"
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

    "Browsers": [
        {
            "Id": "Local Chrome",
            "Kind": "chrome",
            "Timeout": 10
        }
    ]
}
```

Initialize the config file:

```csharp
BasinEnv.SetConfig("path/to/json/config/file.json");
```

Then you access config data with `BasinEnv`

```csharp
BasinEnv.Site.Id; // returns "integration"
BasinEnv.Site.Url; // returns "https://integration.coolapp.com"
BasinEnv.Browser.Kind; // returns "chrome"
BasinEnv.Login.Username; // returns "lebronjaymes"
```

Or switch to an different configuration

```c#
BasinEnv.UseSite("Some Other Site Id");
BasinEnv.UseBrowser("Some Other Browser Id");
```

Or use a config object

```csharp
BasinEnv.UseSite(new SiteConfig() {
    Id = "My New Site",
    Url = "http://dopesites.example.com"
});
```

Note: If you use these methods before calling `BasinEnv.SetConfig()`, they will be overwritten with settings defined in the JSON config file.

### Start a browser session

By default, all the drivers are configured with a clean slate. That just means there are no browser flags or custom binary paths being set initially. Starting up a browser and going to a url is 2 lines of code.

```c#
// Uses the value defined in `Environment.Browser` by default to load a listed browser config by its `Id`
BrowserSession.Init(); 

// Navigates to a given url
BrowserSession.Goto("http://someurl");
```

For the most part, nothing else is needed. But if you need to access the `IWebDriver` instance, just call `BrowserSession.Current`.

### Use a `IWebDriver` instance directly

Maybe I already have code written to manage driver instances. Just pass in an instance of IWebDriver.

```c#
BrowserSession.Init(new ChromeDriver());
BrowserSession.Goto("http://someurl");
```

### Creating simple page object class

Basin provides classes and interfaces to ease the pain of building page object frameworks. Below is an example login page.

```c#
using Basin.Selenium;
using Basin.Pages;
using OpenQA.Selenium;

namespace Example
{
    public class LoginPage : Page
    { 
        // Page elements
        public Element UsernameField => TextInputTag.WithId("username");
        public Element PasswordField => InputTag.WithAttr("type", "password").WithId("password");
        public Element Submit => ButtonTag.WithAttr("name", "submitLogin");

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

### Creating a page object map

Page object classes can grow very large over time. I've found it incredibly difficult to retain readability and clarity with a single class. So instead of keeping everything in a single massive class, I break it down into to 2 classes. A page class for behaviors and a page map class for storing the element locators. Below its how its accomplished:

```c#
using Basin.Selenium;
using Basin.Pages;
using OpenQA.Selenium;

namespace Example
{
    // This class no longer includes locator methods.
    // The goal is to only put behavior methods in this class.
    public class LoginPage : Page<LoginPageMap>
    {
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
        public Element UsernameField => TextInputTag.WithId("username");
        public Element PasswordField => InputTag.WithAttr("type", "password").WithId("password");
        public Element Submit => ButtonTag.WithAttr("name", "submitLogin");
    }
}
```

Now I have clean separate APIs for calling page elements and behaviors. Page map classes are portable and can be used in other classes that need the same element locators.

How page objects should be organized is quite subjective, but the goal of these interfaces and abstracts classes is to provide some basic structure without getting in the way.

## Contribute

1. Fork the repo
2. Create a branch
3. Create a PR based on your fork branch

## Credit

Thanks to [ElSnoMan](https://github.com/ElSnoMan) and
[Test Automation University](https://testautomationu.applitools.com/)
from Applitools for this [Course](https://testautomationu.applitools.com/test-automation-framework-csharp/)

Basin is based on and heavily inspired by the source code from [this repo](https://github.com/ElSnoMan/from-scripting-to-framework)
