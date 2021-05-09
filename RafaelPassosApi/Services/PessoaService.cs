using RafaelPassosApi.Dto;
using RafaelPassosApi.Factory;
using RafaelPassosApi.Models;
using RafaelPassosApi.Repository.Interface;
using RafaelPassosApi.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RafaelPassosApi.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }
        public async Task CadastrarPessoa(PessoaDto pessoaDto)
        {
            var pessoaModel = PessoaFactory.MontarGravarPessoa(pessoaDto);
            await pessoaRepository.Gravar(pessoaModel);
        }

        public async Task Editar(PessoaDto pessoaDto)
        {
            var pessoaModel = PessoaFactory.MontarGravarPessoa(pessoaDto);
            await pessoaRepository.Atualizar(pessoaModel);
        }

        public async Task Exluir(int id)
        {
            var pessoa = await pessoaRepository.ObterPorId(id);
            pessoa.ExcluirPessoa();
            await pessoaRepository.Atualizar(pessoa);
        }

        public async Task<List<Pessoa>> ObterPessoas()
        {
            return await pessoaRepository.ObterTodas();
        }

        public async Task<Pessoa> ObterPorId(int id)
        {
            return await pessoaRepository.ObterPorId(id);
        }
    }
}
