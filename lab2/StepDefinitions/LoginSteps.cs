using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox; 
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace YourProjectNamespace
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginSteps()
        {
            // Ініціалізуємо драйвер у конструкторі
            driver = new FirefoxDriver();
            loginPage = new LoginPage(driver);
        }

        [Given(@"I am on the SauceDemo login page")]
        public void GivenIAmOnSauceDemoSite()
        {
            loginPage.OpenLoginPage("https://www.saucedemo.com/"); 
        }

        [When(@"I enter the username ""standard_user"" and password ""secret_sauce""")]
        public void WhenISelectLoginAsUserOption()
        {
            loginPage.Login("standard_user", "secret_sauce");
        }



        [Then(@"I should be logged in and see the products page")]
        public void ThenIShouldSeeTheMainDivBlock()
        {
            bool isMainDivVisible = loginPage.IsWelcomeTextVisible("//*[@id=\"shopping_cart_container\"]");
            Assert.IsTrue(isMainDivVisible, "The 'mainBox' block is not visible.");
        }

        [When(@"I add a product to the cart")]

        public void WhenIAddToCart()
        {
            loginPage.AddToCart("Sauce Labs Backpack");
        }

        [Then(@"The product should be in the cart")]
        public void ThenProductInCart() {                             
              bool isMainDivVisible = loginPage.IsWelcomeTextVisible("//*[@id=\"shopping_cart_container\"]/a/span");
            Assert.IsTrue(isMainDivVisible, "The 'mainBox' block is not visible.");

                }

        [Then(@"I should close Firefox")]
        public void CloseFirefox()
        {
            loginPage.CloseDriver();
        }
    }
}
