using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestSolution.Tests
{
    [TestFixture]
    public class SeleninuTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            //it is just a trial to turn of bas flash survey popup but didn't work
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("plugin.state.flash", 0);
                        
            driver = new FirefoxDriver(profile);
            baseURL = "http://localhost:63342/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void SeachWithJDPower_withNormalInput_returnsGoodTitle()
        {
            driver.Navigate().GoToUrl(baseURL + "SPWebApplication/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys("Seller");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("Address");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("City");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("1231231234");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("a@b.c");
            driver.FindElement(By.Id("maker")).Clear();
            driver.FindElement(By.Id("maker")).SendKeys("Ford");
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys("F-150");
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("2013");
            driver.FindElement(By.Id("btnSave")).Click();
            driver.FindElement(By.Id("link")).Click();
            
            //wait until flash survey window pops up
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement autocomplete = wait.Until(x => x.FindElement(By.Id("WebIbtnNo")));
            //click "no thanks" button
            driver.FindElement(By.Id("WebIbtnNo")).Click();
            //finally checking what this test is looking for
            Assert.AreEqual("2013 Ford F-150", driver.FindElement(By.ClassName("car-title")).Text);
        }
        [Test]
        public void PhoneNumber_1231231234_shouldPass()
        {
            driver.Navigate().GoToUrl(baseURL + "SPWebApplication/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys("Seller");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("Address");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("City");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("1231231234");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("a@b.c");
            driver.FindElement(By.Id("maker")).Clear();
            driver.FindElement(By.Id("maker")).SendKeys("Ford");
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys("F-150");
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("2013");
            driver.FindElement(By.Id("btnSave")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.Title.StartsWith("Display Entered"); });
        }
        [Test]
        public void PhoneNumber_111_222_3333_shouldPass()
        {
            driver.Navigate().GoToUrl(baseURL + "SPWebApplication/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys("Seller");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("Address");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("City");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("111-222-3333");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("a@b.c");
            driver.FindElement(By.Id("maker")).Clear();
            driver.FindElement(By.Id("maker")).SendKeys("Ford");
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys("F-150");
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("2013");
            driver.FindElement(By.Id("btnSave")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.Title.StartsWith("Display Entered"); });
        }
        [Test]
        public void PhoneNumber_444_555_6666_shouldPass()
        {
            driver.Navigate().GoToUrl(baseURL + "SPWebApplication/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys("Seller");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("Address");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("City");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("(444)555-6666");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("a@b.c");
            driver.FindElement(By.Id("maker")).Clear();
            driver.FindElement(By.Id("maker")).SendKeys("Ford");
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys("F-150");
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("2013");
            driver.FindElement(By.Id("btnSave")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.Title.StartsWith("Display Entered"); });
        }
        [Test]
        public void invalidPhoneNumber_shouldFail()
        {
            driver.Navigate().GoToUrl(baseURL + "SPWebApplication/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys("Seller");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("Address");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("City");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("1231231234999");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("a@b.c");
            driver.FindElement(By.Id("maker")).Clear();
            driver.FindElement(By.Id("maker")).SendKeys("Ford");
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys("F-150");
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("2013");
            driver.FindElement(By.Id("btnSave")).Click();
            Assert.AreEqual("Valid", driver.FindElement(By.Id("phone-error")).Text.Substring(0, 5));
        }
        
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
