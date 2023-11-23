using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using PruebaTecnicaQAPFCTI.PageObject;
using System.ComponentModel;


namespace PruebaTecnicaQAPFCTI.Test
{
    [TestFixture]
    class InicialTest:BaseTest

    {
        // Clase que contiene todos los TEST


        // Primer test encargado de ingresar a Premia Mall y verificar si este cuenta con Lable, txt o boton con un nombre correcto
        //Se Ingresa al metodo "Comparacion Texto" y si se le modifica el dato va a dar prueba fallida
        [Test, Order(1)]
        public void ingresoPreviaMall()
        {
            seleccionarUrl(1);
            InicialPage test = new InicialPage(baseUrl, driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            test.clicOnPreviaMall();

            string validacionFormulario = test.comparacionTexto();
            reporte = extent.CreateTest("Validar datos").Info("Informacion correcta");

            try
            {
                if (test.comparacionTexto() == null)
                {
                    string file3 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                    reporte.Log(AventStack.ExtentReports.Status.Pass, "Prueba Exitosa al ingresar a Premia Mall");
                    reporte.Log(AventStack.ExtentReports.Status.Pass, "Prueba Exitosa: " + ", " + "Captura del Premial Mall: " + reporte.AddScreenCaptureFromBase64String(file3));
                    Console.WriteLine("Texto Correcto");
                    //Assert.Pass("Texto correcto!!!");
                    test.baseUrl = baseUrl2;
                }
                else
                {
                    Assert.Fail("No es el texto correcto");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                String error = Convert.ToString(ex);
                string file3 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                reporte.Log(AventStack.ExtentReports.Status.Fail, "Prueba fallida en Premia Mall: " + error + ", " + "Captura del error: " + reporte.AddScreenCaptureFromBase64String(file3));
                Assert.Fail(error);
            }

            Thread.Sleep(2000);

        }



        // Segundo test encargado de completar el formulario y enviar los datos necesarios solicitados en este
        //Se Ingresa al metodo "ValidacionDatos" donde se encuentra el label de exitoso. 
        [Test, Order(2)]
        public void ingresoContactenos()
        {


            
            Thread.Sleep(2000);
            seleccionarUrl(2);
            InicialPage test = new InicialPage(baseUrl2, driver);
            iniciarNavegador2();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            
            Thread.Sleep(2000);

            test.ingresardatos("JoseQuesada", "joseprueba@yopmail.com", "PRUEBA QA");

            Thread.Sleep(1000);

            string validacionFormulario = test.validacionEnvioDatos();

            reporte = extent.CreateTest("Validar datos").Info("Informacion correcta");
            try
            {
                if (validacionFormulario == null)
                {

                    string file = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;

                    reporte.Log(AventStack.ExtentReports.Status.Pass, "Prueba Exitosa Al enviar el Formulario");
                    reporte.Log(AventStack.ExtentReports.Status.Pass, "Prueba Exitosa: " + ", " + "Captura del formulario enviado: " + reporte.AddScreenCaptureFromBase64String(file));
                    Console.WriteLine("Texto Correcto");
                   // Assert.Pass("Texto correcto en el formulario!!!");
                }
                else
                {
                    Assert.Fail(validacionFormulario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                String error = Convert.ToString(ex);
                string file = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                reporte.Log(AventStack.ExtentReports.Status.Fail, "Prueba fallida en Formulario: " + error + ", " + "Captura del error: " + reporte.AddScreenCaptureFromBase64String(file));
                Assert.Fail(error);
            }
            


            Thread.Sleep(2000);

        }

        // Tercer test encargado verificar otra funcionalidad de la pagina
        //Se Ingresa al metodo "ComparacionPromociones" donde se encuentra el label de exitoso. 
        [Test, Order(3)]
        public void ingresoPromociones()
        {
            seleccionarUrl(1);
            InicialPage test = new InicialPage(baseUrl, driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            test.clicOnProductos();

            string validacionFormulario = test.comparacionPromociones();
            reporte = extent.CreateTest("Validar datos").Info("Informacion correcta");

            try
            {
                if (test.comparacionPromociones() == null)
                {
                    string file2 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                    reporte.Log(AventStack.ExtentReports.Status.Pass, "Prueba Exitosa al verificar los datos de Promociones");
                    reporte.Log(AventStack.ExtentReports.Status.Pass, "Prueba Exitosa: " + ", " + "Captura de Promociones y Descuentos: " + reporte.AddScreenCaptureFromBase64String(file2));
                    //+Assert.Pass("Texto correcto!!!");
                    Console.WriteLine("Texto Correcto");
                    //test.baseUrl = baseUrl2;
                }
                else
                {
                    Assert.Fail("No es el texto correcto");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                String error = Convert.ToString(ex);
                string file2 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                reporte.Log(AventStack.ExtentReports.Status.Fail, "Prueba fallida Promociones y Descuentos: " + error + ", " + "Captura del error: " + reporte.AddScreenCaptureFromBase64String(file2));
                Assert.Fail(error);
            }

            Thread.Sleep(2000);

        }







    }
}
