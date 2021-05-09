using RafaelPassosApi.Dto;
using RafaelPassosApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RafaelPassosApi.Factory
{
    public static class PessoaFactory
    {
        internal static Pessoa MontarGravarPessoa(PessoaDto pessoaDto)
        {
            var pessoaMontada = new Pessoa(pessoaDto.Id, pessoaDto.Nome, pessoaDto.Cpf, pessoaDto.Email, pessoaDto.Telefone, pessoaDto.Sexo, pessoaDto.DataNascimento, false);
            return pessoaMontada;
        }

        public static async Task<List<Pessoa>> ListaPessoasEstaticas()
        {
            var listaDePessoas = new List<Pessoa>();
            listaDePessoas.Add(new Pessoa(1, "Rafael", "12345678910", "email@email.com", "6999999999", Models.Enums.Sexo.Masculino, new DateTime(1988, 4, 17), false));
            listaDePessoas.Add(new Pessoa(2, "Maria", "10987654321", "mariaemail@email.com", "6999999999", Models.Enums.Sexo.Feminino, new DateTime(1990, 12, 28), false));
            listaDePessoas.Add(new Pessoa(3, "Mario", "10232524269", "marioemail@email.com", "6999999999", Models.Enums.Sexo.Masculino, new DateTime(1960, 1, 20), false));
            return listaDePessoas;
        }
    }
}
