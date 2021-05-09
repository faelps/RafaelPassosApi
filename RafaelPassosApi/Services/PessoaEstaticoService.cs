using RafaelPassosApi.Factory;
using RafaelPassosApi.Models;
using RafaelPassosApi.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RafaelPassosApi.Services
{
    public class PessoaEstaticoService : IPessoaEstaticoService
    {
        public async Task Excluir(int id)
        {
           var pessoas = await PessoaFactory.ListaPessoasEstaticas();
            var pessoa = pessoas.Find(x => x.Id == id);
            pessoa.ExcluirPessoa();
        }

        public async Task<Pessoa> ObterPessoaPorId(int id)
        {
            var pessoas = await PessoaFactory.ListaPessoasEstaticas();
            return pessoas.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<List<Pessoa>> ObterPessoas()
        {
            return await PessoaFactory.ListaPessoasEstaticas();
        }
    }
}
