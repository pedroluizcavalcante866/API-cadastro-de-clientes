using MyCadastro_Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using MyCadastro_Clientes.Models.Repository;

namespace MyCadastro_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppConnection _appConfig;

        // Injeção de dependência nativa do .NET
        public ClientesController(IConfiguration configuration)
        {
            _appConfig = new AppConnection(configuration);
        }

        [HttpPost("Salvar")]
        public IActionResult Salvar([FromBody] Clientes cliente)
        {
            try
            {
                ClientesRepository clientes = new ClientesRepository(_appConfig);
                var retorno = clientes.GetCliente(cliente.IdClientes);

                if (retorno != null)
                {
                    clientes.Atualizar(cliente);
                }
                else
                {
                    clientes.Salvar(cliente);
                }
                return Ok(new { mensagem = "Cliente salvo com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody] Clientes cliente)
        {
            try
            {
                ClientesRepository clientes = new ClientesRepository(_appConfig);
                clientes.Atualizar(cliente);
                return Ok(new { mensagem = "Cliente atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                ClientesRepository clientesRepo = new ClientesRepository(_appConfig);
                var listaCli = clientesRepo.Listar();
                return Ok(listaCli);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar clientes: {ex.Message}");
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult Deletar(int IdClientes)
        {
            try
            {
                ClientesRepository clientes = new ClientesRepository(_appConfig);
                bool retornoDelete = clientes.Deletar(IdClientes);
                return Ok(retornoDelete);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar: {ex.Message}");
            }
        }

        [HttpGet("GetCliente")]
        public IActionResult GetCliente(int IdClientes)
        {
            try
            {
                ClientesRepository cliente = new ClientesRepository(_appConfig);
                var retorno = cliente.GetCliente(IdClientes);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar cliente: {ex.Message}");
            }
        }
    }
}