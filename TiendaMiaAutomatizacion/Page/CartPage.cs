using java.lang;
using OpenQA.Selenium;
using TiendaMiaAutomatizacion.Utils;

namespace TiendaMiaAutomatizacion.Page
{
    public class CartPage : BasePage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        public const string H1_MiCarrito_XPATH = "//h1[text()[contains(.,'Mi carrito -')]]";

        public IWebElement MiCarrito => _driver.FindElement(By.XPath(H1_MiCarrito_XPATH));

        public bool IsMiCarritoVisible()
        {           
            if (_driver.IsElementDisplayed(By.XPath(H1_MiCarrito_XPATH), 5))
                { return true; }
            return false;
        }


    }
}
