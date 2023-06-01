using Microsoft.AspNetCore.Mvc;
using SeleniumDomain.Domain;
using SeleniumService.Interface;

namespace SeleniumWeb.Controllers
{
    [ApiController]
    [Route("controller")]
    public class DadosController : Controller
    {
        private readonly IDadosService _dadosService;      

        public DadosController(IDadosService dadosService)
        {
            _dadosService = dadosService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Dados>> Get() 
        {
            return await _dadosService.LerDados();
        }

        [HttpPost()]
        public async Task<string> Post()
        {
            Dados dados = new Dados();            
            return await _dadosService.GravarDados(dados);
        }

    }
}
