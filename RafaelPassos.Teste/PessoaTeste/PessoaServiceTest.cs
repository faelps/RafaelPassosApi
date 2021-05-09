using Moq;
using RafaelPassosApi.Dto;
using RafaelPassosApi.Models;
using RafaelPassosApi.Repository.Interface;
using RafaelPassosApi.Services;
using RafaelPassosApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RafaelPassos.Teste.PessoaTeste
{
    public class PessoaServiceTest
    {
        [Fact]
        public async Task DeveObterPessoaPorId()
        {
            var pessoa = new Pessoa(1, "Rafael", "12345678910", "rafaelpassos.web@gmail.com", "69992349403", RafaelPassosApi.Models.Enums.Sexo.Masculino, DateTime.Now, false);
            Mock<IPessoaRepository> pessoaRepositoryMock = new Mock<IPessoaRepository>();
            var pessoaService = new PessoaService(pessoaRepositoryMock.Object);
            pessoaRepositoryMock.Setup(x => x.ObterPorId(1)).Returns(Task.Run(() => pessoa));
            var result = await pessoaService.ObterPorId(pessoa.Id);
            Assert.Equal(pessoa.Id, result.Id);
        }

        [Fact]
        public async Task DeveObterTodasAsPessoa()
        {
            var pessoa = new Pessoa(1, "Rafael", "12345678910", "rafaelpassos.web@gmail.com", "69992349403", RafaelPassosApi.Models.Enums.Sexo.Masculino, DateTime.Now, false);
            var pessoa2 = new Pessoa(2, "Rafael", "12345678910", "rafaelpassos.web@gmail.com", "69992349403", RafaelPassosApi.Models.Enums.Sexo.Masculino, DateTime.Now, false);
            var pessoa3 = new Pessoa(3, "Rafael", "12345678910", "rafaelpassos.web@gmail.com", "69992349403", RafaelPassosApi.Models.Enums.Sexo.Masculino, DateTime.Now, false);
            var listaDePessoas = new List<Pessoa>();
            listaDePessoas.Add(pessoa);
            listaDePessoas.Add(pessoa2);
            listaDePessoas.Add(pessoa3);
            Mock<IPessoaRepository> pessoaRepositoryMock = new Mock<IPessoaRepository>();
            var pessoaService = new PessoaService(pessoaRepositoryMock.Object);
            pessoaRepositoryMock.Setup(x => x.ObterTodas()).Returns(Task.Run(() => listaDePessoas));
            var result = await pessoaService.ObterPessoas();
            Assert.IsType<List<Pessoa>>(result);
        }
    }
}
