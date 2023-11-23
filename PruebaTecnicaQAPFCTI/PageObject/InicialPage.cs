using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace PruebaTecnicaQAPFCTI.PageObject
{
    public class InicialPage : Base
    {

        //Clase encargada de realizar validaciones internas y definir los selectores CSS

        private By spnPreviaMallId = By.XPath("/html/body/div[7]/div[1]/div/div[2]/div[2]/div/ul[1]/li[2]/a/span");
        private By spnTextoProdcuto = By.XPath("/html/body/app-root/ion-app/div/ion-router-outlet/app-home-page/ion-content/app-home/div[2]/div[1]/div[1]/span");

        private By txtNombre = By.Id("FullName");
        private By txtEmail = By.Id("Email");
        private By txtComentario = By.Id("Enquiry");

        private By btnEnviar = By.Name("send-email");

        private By txtConfirmacion = By.CssSelector(".result");

        private By spnProductos = By.XPath("/html/body/div[7]/div[1]/div/div[2]/div[2]/div/ul[1]/li[4]/a/span");


        private By txtPromociones = By.XPath("/html/body/div[7]/div[3]/div[4]/div[2]/div/div/div[2]/div/div[1]/div/div[2]/h2/a");



        // driver.findElement(By.cssSelector(“#<id value>”));
        public InicialPage(string url, IWebDriver driver) : base(url, driver)
        {
            
        }
       
        //set de datos de la pagina
        public IWebElement setpreviaMall()
        {
            return _webDriver.FindElement(this.spnPreviaMallId);
        }

        public IWebElement setTexto()
        {
            return _webDriver.FindElement(this.spnTextoProdcuto);
        }

        public IWebElement setNombreContacto()
        {
            return _webDriver.FindElement(this.txtNombre);
        }

        public IWebElement setEmailContacto()
        {
            return _webDriver.FindElement(this.txtEmail);
        }
        public IWebElement setComentarioContacto()
        {
            return _webDriver.FindElement(this.txtComentario);
        }

        public IWebElement setbtnEnviar()
        {
            return _webDriver.FindElement(this.btnEnviar);
        }

        public IWebElement settxtConfirmar()
        {
            return _webDriver.FindElement(this.txtConfirmacion);
        }


        public IWebElement setspnProductos()
        {
            return _webDriver.FindElement(this.spnProductos);
        }

        public IWebElement settxtPromociones()
        {
            return _webDriver.FindElement(this.txtPromociones);
        }


        public void clicOnPreviaMall()
        {
            setpreviaMall().Click();
        }

        // Comparacion del punto 1 para validacion de datos. 
        public string comparacionTexto()
        {
            if(setTexto().GetAttribute("textContent") != "Productos nuevos")
            {
                return "Texto obntenido distinto al esperado";
            }
            return null;
        }


        //Datos para ingresar en el formulario. 
        public void ingresardatos(string nombre, string email, string comentario)
        {
            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5)).Until(_webDriver =>setNombreContacto().Displayed == true);
            setNombreContacto().Clear();
            setNombreContacto().SendKeys(nombre);

            setEmailContacto().Clear();
            setEmailContacto().SendKeys(email);

            setComentarioContacto().Clear();
            setComentarioContacto().SendKeys(comentario);

            setbtnEnviar().Click();
        }

        //Metodo para la validacion de los datos del punto del formulario cuando es correcto
        public string validacionEnvioDatos()
        {
            if (settxtConfirmar().GetAttribute("textContent").Contains("Su comentario ha sido enviado con éxito al propietario de la tienda.")==false)
            {
                return "Texto obntenido distinto al esperado en el formulario";
            }
            return null;
        }

        //Metodo encargado de entrar a las Promociones y Descuentos
        public void clicOnProductos()
        {
            setspnProductos().Click();
        }

        // Metodo para comprar las promociones del punto 3 
        public string comparacionPromociones()
        {
            if (settxtPromociones().GetAttribute("textContent").Contains( "Tus millas y puntos saben 25% más con Spice UP")==false)
            {
                return "Texto obntenido distinto al esperado";
            }
            return null;
        }

        


    }
}
