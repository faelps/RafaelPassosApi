using RafaelPassosApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RafaelPassosApi.Repository.Interface
{
    public interface IPessoaRepository
    {
        Task Gravar(Pessoa pessoaModel);
        Task Atualizar(Pessoa pessoaModel);
        Task<Pessoa> ObterPorId(int id);
        Task<List<Pessoa>> ObterTodas();
    }
}
