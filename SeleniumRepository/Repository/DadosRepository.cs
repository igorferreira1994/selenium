using Microsoft.EntityFrameworkCore;
using SeleniumDomain.Domain;
using SeleniumRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumRepository.Repository
{
    public class DadosRepository : IDadosRepository
    {
        public readonly Context _context;
        public DadosRepository(Context context)
        {
            _context = context;
        }
        public async Task<string> GravarDados(Dados dados)
        {
            try
            {
                _context.Dados.Add(dados);
                _context.SaveChanges();
                return "Dados gravados com sucesso";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }           

        }

        public async Task<IEnumerable<Dados>> LerDados()
        {
            return await _context.Dados.ToListAsync();
        }
    }
}
