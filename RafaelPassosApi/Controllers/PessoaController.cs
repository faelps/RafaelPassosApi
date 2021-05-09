using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RafaelPassosApi.Dto;
using RafaelPassosApi.Models;
using RafaelPassosApi.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RafaelPassosApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : BaseController
    {
        private readonly IPessoaService pessoaService;
        private readonly IPessoaEstaticoService pessoaEstaticoService;
        public PessoaController(IPessoaService pessoaService, IPessoaEstaticoService pessoaEstaticoService)
        {
            this.pessoaService = pessoaService;
            this.pessoaEstaticoService = pessoaEstaticoService;
        }
        [HttpGet("obterPessoas")]
        public async Task<List<Pessoa>> ObterPessoas()
        {
            var pessoas = await pessoaService.ObterPessoas();
           // var pessoas = await pessoaEstaticoService.ObterPessoas();
            return pessoas;
        }
        [HttpPost("cadastrar/{pessoa}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarPessoa(PessoaDto pessoaDto)
        {
            try
            {
                await pessoaService.CadastrarPessoa(pessoaDto);
                return Ok(new { Sucesso = true, mensagem = "Pessoa cadastrada com sucesso" });
            }
            catch (System.Exception)
            {
                return BadRequest(new { Sucesso = false, mensagem = "Ocorreu um erro, por favor contate o administrador" });
            }
        }
        [HttpPut("editar/{pessoa}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarPessoa(PessoaDto pessoaDto)
        {
            try
            {
                await pessoaService.Editar(pessoaDto);
                return Ok(new { Sucesso = true, mensagem = "Pessoa editada com sucesso" });
            }
            catch (System.Exception)
            {
                return BadRequest(new { Sucesso = false, mensagem = "Ocorreu um erro, por favor contate o administrador" });
            }
        }

        [HttpGet("obterPorId/{id}")]
        public async Task<Pessoa> ObterPorId(int id)
        {
            var pessoa = await pessoaService.ObterPorId(id);
            //var pessoa = await pessoaEstaticoService.ObterPessoaPorId(id);
            return pessoa;
        }

        [HttpGet("excluir/{id}")]
        public async Task<IActionResult> ExcluirPessoa(int id)
        {
            try
            {
                await pessoaService.Exluir(id);
                //await pessoaEstaticoService.Excluir(id);
                return Ok(new { Sucesso = true, mensagem = "Pessoa excluida com sucesso" });
            }
            catch (System.Exception)
            {
                return BadRequest(new { Sucesso = false, mensagem = "Ocorreu um erro, por favor contate o administrador" });
            }
           
        }
    }
}
