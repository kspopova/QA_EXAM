using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace ExamDemoQA
{
    [TestClass]
    public class ExamTest
    {
        [TestClass]
        public class Exercise
        {
            public IWebDriver Driver;

            [TestInitialize]
            public void OpenBrowser()
            {
                Driver = new ChromeDriver();

            }

            [TestMethod]
            public void Logout()
            {
                //login
                Driver.Navigate().GoToUrl("http://store.demoqa.com/wp-login.php");
                Driver.FindElement(By.Id("user_login")).SendKeys("kami_93ss@abv.bg");
                Driver.FindElement(By.Id("user_pass")).SendKeys("silistra93");
                Driver.FindElement(By.Id("wp-submit")).Click();
                Thread.Sleep(5000);
                Driver.Navigate().GoToUrl("http://store.demoqa.com");
                Driver.FindElement(By.CssSelector("#account_logout > a:nth-child(1)")).Click();
                Thread.Sleep(5000);
                Driver.FindElement(By.Id("account")).Click();
                var register = Driver.FindElement(By.CssSelector("#meta > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1)")).Text;
                Assert.AreEqual(register, "Register");
            }
            [TestMethod]
            public void Register()
            {
                this.Driver.Navigate().GoToUrl("http://store.demoqa.com/wp-login.php?action=register");

                Driver.FindElement(By.Id("user_login")).SendKeys(Faker.Internet.UserName());

                Driver.FindElement(By.Id("user_email")).SendKeys(Faker.Internet.UserName() + "@nosuchmail8579.book");

                Driver.FindElement(By.Id("wp-submit")).Click();

                Assert.AreEqual("Registration complete. Please check your email.", Driver.FindElement(By.CssSelector(".message")).Text);

            
            
            [TestCleanup]
            public void CloseBrowser()
            {
                Driver.Close();
            }
        }
    }
}
