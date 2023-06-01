using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumDomain.Domain;
using SeleniumRepository.Interface;
using SeleniumService.Interface;
using System.Threading;

namespace SeleniumService.Service
{
    public class DadosService : IDadosService
    {
        private static IWebDriver driver;
        private readonly IDadosRepository _dadosRepository;

        public DadosService(IDadosRepository dadosRepository)
        {
            _dadosRepository = dadosRepository;
        }
        public async Task<string> GravarDados(Dados dados)
        {
            var option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };

            option.AddArguments("--start-maximized");    
            driver = new ChromeDriver(option);                   ;

            driver.Navigate().GoToUrl("https://www.aec.com.br/");
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.ClassName("buscar")).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Name("s")).Clear();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Name("s")).SendKeys("Automação");
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.ClassName("me-3")).Click();
            dados.Area = driver.FindElement(By.ClassName("hat")).Text;
            dados.Titulo = driver.FindElement(By.ClassName("tres-linhas")).Text;
            var publicacao = driver.FindElement(By.TagName("small")).Text;
            dados.Descricao = driver.FindElement(By.ClassName("duas-linhas")).Text;

            string[] separador = publicacao.Split(' ');

            bool autorFlag = false;
            bool dataFlag = false;
            int count = 0;

            foreach (var item in separador)
            {
                if (autorFlag && count < 2)
                {
                    if (dados.Autor == "")
                        dados.Autor = item;
                    else
                        dados.Autor += " " + item;
                    count++;
                }

                if (dataFlag)
                    dados.Publicacao = item;

                if (item == "por")
                    autorFlag = true;
                if (item == "em")
                    dataFlag = true;
            }
            return await _dadosRepository.GravarDados(dados);
        }

        public async Task<IEnumerable<Dados>> LerDados()
        {
            return await _dadosRepository.LerDados();
        }
    }
}
