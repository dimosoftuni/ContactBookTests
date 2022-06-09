using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace ContactBook.AndroidTests
{
    public class AndroidTest
    {
        private const string AppiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string ContactsBookUrl = "https://contactbook.nakov.repl.co/api";
        private const string appLocation = @"C:\Work\contactbook-androidclient.apk";

        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void StartApp()
        {
            options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);

            driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_SearchContact_VerifyFirstResult()
        {
            // Arrange
            var urlField = driver.FindElement(By.Id("contactbook.androidclient:id/editTextApiUrl"));
            urlField.Clear();
            urlField.SendKeys(ContactsBookUrl);

            var buttonConnect = driver.FindElement(By.Id("contactbook.androidclient:id/buttonConnect"));
            buttonConnect.Click();

            var editTextField = driver.FindElement(By.Id("contactbook.androidclient:id/editTextKeyword"));
            editTextField.SendKeys("steve");

            //Act
            var buttonSearch = driver.FindElement(By.Id("contactbook.androidclient:id/buttonSearch"));
            buttonSearch.Click();

            // Assert
            var firstName = driver.FindElement(By.XPath("//android.widget.TableRow[3]/android.widget.TextView[2]"));
            var lastName = driver.FindElement(By.XPath("//android.widget.TableRow[4]/android.widget.TextView[2]"));

            Assert.That(firstName.Text, Is.EqualTo("Steve"));
            Assert.That(lastName.Text, Is.EqualTo("Jobs"));
        }
    }
}