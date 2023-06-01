using SeleniumDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumRepository.Interface
{
    public interface IDadosRepository
    {
        public Task<string> GravarDados(Dados dados);
        public Task<IEnumerable<Dados>> LerDados();
    }
}
