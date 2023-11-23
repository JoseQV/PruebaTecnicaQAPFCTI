using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace PruebaTecnicaQAPFCTI.PageObject
{
    public class Base
    {
       //Hereda a otras clases los datos necesarios para el WEB Driver.
        public IWebDriver _webDriver;
        public string baseUrl;

        public Base(string url, IWebDriver driver)
        {
            this.baseUrl = url;
            this._webDriver = driver;

        }
        public Base(IWebDriver driver)
        {

            this._webDriver = driver;

        }
        public void comprobarTexto(string palabra, IWebElement elemento)
        {
            Assert.AreEqual(palabra.ToUpper(), elemento.Text.ToUpper());

        }
    }
}
