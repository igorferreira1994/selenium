using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Text;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace TestSelenium
{
    public class UnitTest1
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [Fact]
        public void TestComCPF_ReturnSucesso()
        {
            var option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };
            option.AddArguments("--start-maximized");
            //option.AddArgument("--headless");
            driver = new ChromeDriver(option);
            //driver = new ChromeDriver();
            baseURL = "https://www.katalon.com/";

            driver.Navigate().GoToUrl("https://www.aec.com.br/");
            driver.FindElement(By.ClassName("buscar")).Click();
            driver.FindElement(By.Name("s")).Clear();
            driver.FindElement(By.Name("s")).SendKeys("Automação");
            driver.FindElement(By.ClassName("me-3")).Click();
            var area = driver.FindElement(By.ClassName("hat")).Text;
            var tiulo = driver.FindElement(By.ClassName("tres-linhas")).Text;
            var publicacao = driver.FindElement(By.TagName("small")).Text;
            var descricao = driver.FindElement(By.ClassName("duas-linhas")).Text;

            string[] separador = publicacao.Split(' ');

            bool autorFlag = false;
            bool dataFlag = false;
            string autor = "";
            string data = "";
            int count = 0;

            foreach (var item in separador)
            {
                if (autorFlag && count < 2)
                {
                    if (autor == "")
                        autor = item;
                    else
                        autor += " " + item;
                    count++;
                }

                if (dataFlag)
                    data = item;

                if (item == "por")
                    autorFlag = true;
                if (item == "em")
                    dataFlag = true;
            }

            ;

            


            //Assert.IsNotNull(driver.FindElement(By.XPath("//pre[contains(text(),'Sucesso')]")));
        }
    }
}