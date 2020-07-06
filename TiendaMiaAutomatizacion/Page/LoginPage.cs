using AventStack.ExtentReports;
using OpenQA.Selenium;
using TiendaMiaAutomatizacion.Report;
using TiendaMiaAutomatizacion.Test;
using TiendaMiaAutomatizacion.Utils;

namespace TiendaMiaAutomatizacion.Page
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver _driver;


        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public const string BTN_Login_XPATH = "//div[@id='login-form-container']//button[@class='button-register']";
        public const string BTN_User_ID = "email_address_register";
        public const string BTN_Pass_ID = "password-log";
        public const string FORM_Login_ID = "login-form-container";

        public IWebElement FormLogin => _driver.FindElement(By.Id(FORM_Login_ID));
        public IWebElement User => FormLogin.FindElement(By.Id(BTN_User_ID));
        public IWebElement Pass => FormLogin.FindElement(By.Id(BTN_Pass_ID));
        public IWebElement Login => FormLogin.FindElement(By.XPath(BTN_Login_XPATH));


        public ProductsPage LoginTiendaMia(string user, string pass, ExtentTest test)
        {
           // _driver.IsElementEnable(By.Id(BTN_User_ID), 3);
            CompleteField(User, user);
            CompleteField(Pass, pass);
            test.Log(Status.Info, "Insertando usuario y contraseña", ReportManager.ScreenShot(_driver));
            _driver.TryToClick(By.XPath(BTN_Login_XPATH), 3);

            return new ProductsPage(_driver);
        }
    }
}
