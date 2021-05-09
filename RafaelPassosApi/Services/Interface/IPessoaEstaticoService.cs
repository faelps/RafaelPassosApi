using RafaelPassosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RafaelPassosApi.Services.Interface
{
    public interface IPessoaEstaticoService
    {
        Task<List<Pessoa>> ObterPessoas();
        Task Excluir(int id);
        Task<Pessoa> ObterPessoaPorId(int id);
    }
}
