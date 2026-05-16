namespace MyCadastro_Clientes.Models
{
    public class Clientes
    {
        public int IdClientes { get; set; }
        public string Documento{  get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string UF { get; set; }
    }
}
