using AventStack.ExtentReports;
using NUnit.Framework;
using System.Threading;
using TiendaMiaAutomatizacion.Page;
using TiendaMiaAutomatizacion.Report;

namespace TiendaMiaAutomatizacion.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests : BaseTest
    {

        [Test, Order(1)]
        public void Login()
        {
            InitialPage initialPage = new InitialPage(webDriver);
            ProductsPage productsPage = initialPage.selectCountry();

            productsPage.PopUpHandles();
            productsPage.selectMiCuenta();
            test.Log(Status.Info, "Seleccionando Mi Cuenta >> Entrar", ReportManager.ScreenShot(webDriver));
            LoginPage loginPage = productsPage.selectEntrar();

            Thread.Sleep(1000);
            ProductsPage productsPage1 = loginPage.LoginTiendaMia("rosamariaceraosorio@gmail.com", "rosamaria853", test);

            Assert.IsTrue(productsPage1.ValidateLoggedUser(), "Error, usuario no loggeado");
            test.Log(Status.Pass, "Usuario correctamente loggeado", ReportManager.ScreenShot(webDriver));
        }

        [Test, Order(2)]
        public void AddToCart()
        {
            InitialPage initialPage = new InitialPage(webDriver);
            ProductsPage productsPage = initialPage.selectCountry();

            productsPage.PopUpHandles();
            SearchResultsPage searchResultsPage = productsPage.FindProduct("mouse", test);

            SelectedProductPage selectedProductPage = searchResultsPage.SelectFirstResult();
            selectedProductPage.AddToCart(test);
            CartPage cartPage = selectedProductPage.SeeCart();

            Assert.IsTrue(cartPage.IsMiCarritoVisible(), "Error al intentar añadir al carrito");
            test.Log(Status.Pass, "Se añadio al carrito correctamente", ReportManager.ScreenShot(webDriver));
        }

    }
}
