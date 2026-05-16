using MyCadastro_Clientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCadastro_Clientes.Models.Repository;
using System.Net;

namespace MyCadastro_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();

        [HttpPost("Salvar")]
        public object Salvar([FromBody] Clientes cliente)
        {
            try
            {
                var appConfig = new AppConnection(configuration);

                ClientesRepository clientes = new ClientesRepository(appConfig);

                var retorno = clientes.GetCliente(cliente.IdClientes);

                if (retorno != null)
                {
                    clientes.Atualizar(cliente);
                }
                else
                {
                    clientes.Salvar(cliente);
                }
             }
            catch (Exception ex)
            {
            }

            return null;
        }

        [HttpPost("Alterar")]
        public object Alterar([FromBody] Clientes cliente)
        {
            try
            {
                var appConfig = new AppConnection(configuration);

                ClientesRepository clientes = new ClientesRepository(appConfig);
                clientes.Atualizar(cliente);
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        [HttpGet("Listar")]
        public object Listar()
        {
            List<Clientes> ListaCli = null;
            try
            {
                var appConfig = new AppConnection(configuration);
                ClientesRepository clientesRepo = new ClientesRepository(appConfig);
                ListaCli = clientesRepo.Listar();
            }
            catch (Exception ex)
            {
            }

            return ListaCli;
        }

        [HttpDelete("Deletar")]
        public object Deletar(int IdClientes)
        {
            try
            {
                var appConfig = new AppConnection(configuration);
                ClientesRepository clientes = new ClientesRepository(appConfig);
                bool retornoDelete = clientes.Deletar(IdClientes);
                return retornoDelete;
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        [HttpGet("GetCliente")]
        public object GetCliente(int IdClientes)
        {
            try
            {
                var appConfig = new AppConnection(configuration);
                ClientesRepository cliente = new ClientesRepository(appConfig);
                var retorno = cliente.GetCliente(IdClientes);
                return retorno;
            }
            catch (Exception ex)
            {
            }

            return null;
        }
    }
}