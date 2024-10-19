namespace TechFarmSystem.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Funcao { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string NivelAcesso { get; set; } = "usuario";
    }
}