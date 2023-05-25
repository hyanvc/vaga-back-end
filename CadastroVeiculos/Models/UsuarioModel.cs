namespace CadastroVeiculos.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        public string? Proprietario { get; set; }
        public string? Senha { get; set; }



        public string? MarcadoCarro { get; set; }

        public string? PlacaDoCarro { get; set; }
        public DateTime DatadeCadastro { get; set; }


    }
}
