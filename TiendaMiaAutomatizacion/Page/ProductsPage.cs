using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading;
using TiendaMiaAutomatizacion.Report;
using TiendaMiaAutomatizacion.Utils;

namespace TiendaMiaAutomatizacion.Page
{


    public class ProductsPage : BasePage
    {
        private readonly IWebDriver _driver;


        public ProductsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public const string LNK_MiCuenta_XPATH = "//a[@class='login-a']";
        public const string LNK_Entrar_XPATH = "//a[@class='lg_button']";
        public const string LNK_PopUp_XPATH = "//a[@class='is-registreded-link modal-registration-home']";
        public const string LNK_Modal_XPATH = "//a[@class='button primary-btn track-ver-mas close-modal']";
        public const string TXT_Buscar_ID = "amz";
        public const string BTN_BuscarAMZ_ID = "button_amz";
        public const string SPAN_User_XPATH = "//span[text()='Rosa']";
        public IWebElement MiCuenta => _driver.FindElement(By.XPath(LNK_MiCuenta_XPATH));
        public IWebElement PopUp => _driver.FindElement(By.XPath(LNK_PopUp_XPATH));
        public IWebElement Modal => _driver.FindElement(By.XPath(LNK_Modal_XPATH));
        public IWebElement Entrar => _driver.FindElement(By.XPath(LNK_Entrar_XPATH));
        public IWebElement Buscar => _driver.FindElement(By.Id(TXT_Buscar_ID));
        public IWebElement BuscarAMZ => _driver.FindElement(By.Id(BTN_BuscarAMZ_ID));
        public IWebElement VerUser => _driver.FindElement(By.XPath(SPAN_User_XPATH));

        public void PopUpHandles()
        {
            _driver.TryToClick(By.XPath(LNK_Modal_XPATH), 3);
            try
            {
                _driver.TryToClick(By.XPath(LNK_PopUp_XPATH), 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void selectMiCuenta()
        {
            _driver.TryToClick(By.XPath(LNK_MiCuenta_XPATH), 1);
        }

        public LoginPage selectEntrar()
        {
            _driver.TryToClick(By.XPath(LNK_Entrar_XPATH), 1);
            return new LoginPage(_driver);
        }

        public SearchResultsPage FindProduct(string value, ExtentTest test)
        {
            _driver.IsElementDisplayed(By.Id(TXT_Buscar_ID), 8);
            CompleteField(Buscar, value);
            test.Log(Status.Info, "Buscando producto: " + value, ReportManager.ScreenShot(_driver));
            ClickElement(BuscarAMZ);

            return new SearchResultsPage(_driver);
        }

        public bool ValidateLoggedUser()
        {
            //Thread.Sleep(4000);
            if (_driver.IsElementDisplayed(By.XPath(SPAN_User_XPATH), 10))
            { return true; }

            return false;
        }

    }
}
