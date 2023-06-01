using SeleniumDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumService.Interface
{
    public interface IDadosService
    {
        public Task<string> GravarDados(Dados dados);
        public Task<IEnumerable<Dados>> LerDados();
    }
}
