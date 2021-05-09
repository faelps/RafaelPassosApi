using Microsoft.EntityFrameworkCore;
using RafaelPassosApi.Models;
using RafaelPassosApi.Models.Context;
using RafaelPassosApi.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RafaelPassosApi.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoaContext context;
        public PessoaRepository(PessoaContext context)
        {
            this.context = context;
        }
        public async Task Atualizar(Pessoa pessoaModel)
        {
            context.Pessoa.Update(pessoaModel);
            await context.SaveChangesAsync();
        }

        public async Task Gravar(Pessoa pessoaModel)
        {
            await context.Pessoa.AddAsync(pessoaModel);
            await context.SaveChangesAsync();
        }

        public async Task<Pessoa> ObterPorId(int id)
        {
            return await context.Pessoa.FindAsync(id);
        }

        public async Task<List<Pessoa>> ObterTodas()
        {
            return await context.Pessoa.Where(x => !x.Excluido).ToListAsync();
        }
    }
}
