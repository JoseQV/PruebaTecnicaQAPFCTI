using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using AventStack.ExtentReports.Reporter;
using NUnit.Framework;




namespace PruebaTecnicaQAPFCTI.Test
{
    class BaseTest
    {

        // Se definen las rutas necesarias para realizar los Test
        public IWebDriver driver;
        public string baseUrl = "https://www.clubpromerica.com/costarica/";


        public void seleccionarUrl(int seleccion)
        {

            switch (seleccion)
            {
                case 1:
                    baseUrl = "https://www.clubpromerica.com/costarica/";
                    break;

                case 2:
                    baseUrl = "https://www.clubpromerica.com/costarica/contactus";
                    break;

            }


        }



        public string baseUrl2 = "https://www.clubpromerica.com/costarica/contactus";

        public static ExtentTest reporte;
        public static ExtentReports extent;

        [SetUp]
        public void iniciarNavegador()
        {

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //implicit wait
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
        }

        public void iniciarNavegador2()
        {
            driver.Navigate().GoToUrl(baseUrl2); 
        }




        [TearDown]
        public void cerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }
        

        // Encargado de los reportes 
        [OneTimeSetUp]

        public void ExtentStart()
        {
            extent = new ExtentReports();
            ExtentV3HtmlReporter htmlreporter = new ExtentV3HtmlReporter(@"..\..\..\Reportes\Test" + this.GetType().ToString() + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            htmlreporter.Config.DocumentTitle = "Prueba PFCTI";
            htmlreporter.Config.ReportName = "Prueba JoseQuesada";
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            extent.AttachReporter(htmlreporter);


        }
        [OneTimeTearDown]
        public void AfterClass()
        {
            extent.Flush();
        }



    }
}
