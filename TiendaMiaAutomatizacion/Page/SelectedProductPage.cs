using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMiaAutomatizacion.Report;
using TiendaMiaAutomatizacion.Utils;

namespace TiendaMiaAutomatizacion.Page
{
    public class SelectedProductPage : BasePage
    {
        private readonly IWebDriver _driver;


        public SelectedProductPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public const string SPAN_AgregarCarrito_XPATH = "//span[text()[contains(.,'Agregar al carrito')]]";
        public const string SPAN_VerCarrito_XPATH = "//span[text()[contains(.,'Ver carrito')]]";

        

        public IWebElement AgregarCarrito => _driver.FindElement(By.XPath(SPAN_AgregarCarrito_XPATH));
        public IWebElement VerCarrito => _driver.FindElement(By.XPath(SPAN_VerCarrito_XPATH));


        public void AddToCart(ExtentTest test)
        {
            _driver.TryToClick(By.XPath(SPAN_AgregarCarrito_XPATH), 20);
            test.Log(Status.Info, "Añadiendo al carrito", ReportManager.ScreenShot(_driver));
        }

        public CartPage SeeCart()
        {
            _driver.TryToClick(By.XPath(SPAN_VerCarrito_XPATH), 20);
            return new CartPage(_driver);
        }


    }
}
