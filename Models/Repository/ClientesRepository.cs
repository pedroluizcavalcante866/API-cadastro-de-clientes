using System.Data;
using Microsoft.Data.SqlClient;

namespace MyCadastro_Clientes.Models.Repository
{
    public class ClientesRepository
    {
        private AppConnection _appConfig;

        public ClientesRepository(AppConnection appConfig)
        {
            _appConfig = appConfig; 
        }

        public void Salvar(Clientes clientes)
            {
            try
            {

                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine(connection.State);
                    using (SqlCommand cmd = new SqlCommand("PROC_INSERIR_CLIENTES", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdClientes", clientes.IdClientes);
                        cmd.Parameters.AddWithValue("@Documento", clientes.Documento);
                        cmd.Parameters.AddWithValue("@Nome", clientes.Nome);
                        cmd.Parameters.AddWithValue("@Sexo", clientes.Sexo);
                        cmd.Parameters.AddWithValue("@Email", clientes.Email);
                        cmd.Parameters.AddWithValue("@Telefone", clientes.Telefone);
                        cmd.Parameters.AddWithValue("@Fax", clientes.Fax);
                        cmd.Parameters.AddWithValue("@UF", clientes.UF);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // ou um breakpoint aqui
                throw; // relança o erro pra você ver no Swagger/Postman

            }
        
      
        }
        public void Atualizar(Clientes clientes) 
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE_CLIENTES",connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdClientes", clientes.IdClientes);
                        cmd.Parameters.AddWithValue("@Documento", clientes.Documento);
                        cmd.Parameters.AddWithValue("@Nome", clientes.Nome);
                        cmd.Parameters.AddWithValue("@Sexo", clientes.Sexo);
                        cmd.Parameters.AddWithValue("@Email", clientes.Email);
                        cmd.Parameters.AddWithValue("@Telefone", clientes.Telefone);
                        cmd.Parameters.AddWithValue("@Fax", clientes.Fax);
                        cmd.Parameters.AddWithValue("@UF", clientes.UF);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
           
            }
        }

        public List<Clientes> Listar()
        {
            List<Clientes> retorno = new List<Clientes>();

            try
            {
                using(SqlConnection connection =new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("PROC_LISTAR_CLIENTES",connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Clientes cliente = new Clientes();

                                cliente.IdClientes = Convert.ToInt32( reader["IdClientes"].ToString());
                                cliente.Documento = reader["Documento"].ToString();
                                cliente.Nome = reader["Nome"].ToString();
                                cliente.Sexo = reader["Sexo"].ToString();
                                cliente.Email = reader["Email"].ToString();
                                cliente.Telefone = reader["Telefone"].ToString();
                                cliente.Fax = reader["Fax"].ToString();
                                cliente.UF = reader["UF"].ToString();

                                retorno.Add(cliente);
                            }

                        }


                    }
                }
            }
            catch (Exception ex)
            {
            }
            return retorno;
        }
        public bool Deletar(int IdClientes)
        {

            bool retorno = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("PROC_DELETAR_CLIENTES",connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdClientes",IdClientes);

                        int linhas = cmd.ExecuteNonQuery();

                        if (linhas > 0)
                        {
                            retorno = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return retorno;
        }
        public Clientes? GetCliente(int IdClientes)
        {
            Clientes cliente = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("PROC_GET_CLIENTES",connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdClientes", IdClientes);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Clientes();
                                cliente.IdClientes = Convert.ToInt32(reader["IdClientes"].ToString());
                                cliente.Documento = reader["Documento"].ToString();
                                cliente.Nome = reader["Nome"].ToString();
                                cliente.Sexo = reader["Sexo"].ToString();
                                cliente.Email = reader["Email"].ToString();
                                cliente.Telefone = reader["Telefone"].ToString();
                                cliente.Fax = reader["Fax"].ToString();
                                cliente.UF = reader["UF"].ToString();


                            }

                        }


                    }
                }  
            }
            catch(Exception ex)
            {

            }
            return cliente;
        }
    }
}