using OpenQA.Selenium;
using TiendaMiaAutomatizacion.Utils;

namespace TiendaMiaAutomatizacion.Page
{
    public class SearchResultsPage : BasePage
    {
        private readonly IWebDriver _driver;


        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public const string DIV_FirstResult_XPATH = "//div[@class='body-result ']//div[@class='item button-border'][1]";

        public IWebElement FirstResult => _driver.FindElement(By.XPath(DIV_FirstResult_XPATH));

        public SelectedProductPage SelectFirstResult()
        {
            _driver.TryToClick(By.XPath(DIV_FirstResult_XPATH), 20);
            return new SelectedProductPage(_driver);
        }

    }
}
