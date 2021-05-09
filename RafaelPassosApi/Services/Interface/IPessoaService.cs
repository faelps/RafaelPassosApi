using RafaelPassosApi.Dto;
using RafaelPassosApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RafaelPassosApi.Services.Interface
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> ObterPessoas();
        Task CadastrarPessoa(PessoaDto pessoaDto);
        Task Editar(PessoaDto pessoaDto);
        Task Exluir(int id);
        Task<Pessoa> ObterPorId(int id);
    }
}
