using RafaelPassosApi.Models.Enums;
using System;

namespace RafaelPassosApi.Models
{
    public class Pessoa
    {
        public Pessoa()
        {

        }
        public Pessoa(int id, string nome, string cpf, string email, string telefone, Sexo sexo, DateTime dataNascimento, bool excluido)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Excluido = false;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public Sexo Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Excluido { get; set; }

        public void ExcluirPessoa()
        {
            this.Excluido = true;
        }
    }
}
