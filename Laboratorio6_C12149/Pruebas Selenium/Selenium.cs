using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]

        public void Enter_To_List_Of_Countried_Test()
        {
            var URL = "http://localhost:8080/";
            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();

            var IrAbotonAgregar = _driver.FindElement(By.XPath("//button[contains(text(),'Agregar pais')]"));
            IrAbotonAgregar.Click();

            var NombrePais = "EstebanPais";

            _driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(NombrePais);

            var continente = "Asia";

            var dropdown = new SelectElement(_driver.FindElement(By.TagName("select")));
            dropdown.SelectByText(continente);

            var idioama = "Portugues";

            _driver.FindElements(By.TagName("input"))[1].SendKeys(idioama);

            _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]")).Click();

            // Solo se anade una espera, si no estaba el assert de abajo se hacia antes de que llegara la informacion.
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.TagName("body")).Text.Contains("EstebanPais"));


            var body = _driver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(body.Contains("EstebanPais"), "El país no fue agregado correctamente.");
        }

    }
}