using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Метод для відкриття сторінки в браузері
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для логіну на сторінку
    public void Login(string username, string password)
    {
        // Заходимо на сторінку логіну
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        // Знаходимо поле для введення імені користувача за допомогою XPath
        IWebElement usernameField = driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));

        // Знаходимо поле для введення пароля за допомогою XPath
        IWebElement passwordField = driver.FindElement(By.XPath("//*[@id=\"password\"]"));

        // Знаходимо кнопку логіну за допомогою XPath
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));

        // Вводимо ім'я користувача та пароль
        usernameField.SendKeys(username);
        Thread.Sleep(2000);
        passwordField.SendKeys(password);
        Thread.Sleep(2000);
        // Натискаємо кнопку логіну
        loginButton.Click();
        Thread.Sleep(1000);
    }
    public bool IsWelcomeTextVisible(string xpath)
    {
        try
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            return true;
            Thread.Sleep(1000);
        }
        catch (NoSuchElementException)
        {
            return false;
            Thread.Sleep(1000);
        }
    }


    public void AddToCart(string productName)
    {
        Thread.Sleep(2000);
        // Знаходимо кнопку "Add to cart" за допомогою ID
        string addToCartButtonId = $"add-to-cart-{productName.Replace(" ", "-").ToLower()}";
        IWebElement addToCartButton = driver.FindElement(By.Id(addToCartButtonId));

        // Клікаємо на кнопку "Add to cart"
        addToCartButton.Click();
        Thread.Sleep(1000);
    }

    public void CloseDriver()
    {
        driver.Quit();
    }

}
