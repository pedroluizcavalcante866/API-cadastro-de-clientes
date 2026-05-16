namespace MyCadastro_Clientes.Models.Repository
{
    public class AppConnection
    {
        public string ConnectionString { get; set; }

        public AppConnection (IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("ConnString");
        }
    }
}
