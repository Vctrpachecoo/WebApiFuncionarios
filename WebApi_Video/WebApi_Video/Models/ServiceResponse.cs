namespace WebApi_Video.Models
{
    public class ServiceResponse<T>
    {
        // Os dados podem ser nulos 
        public T? Dados { get; set; }

        // Começa sendo uma string vazia 
        public string Mensagem { get; set; } = string.Empty;

        // Começa sendo verdadeiro (sucesso)
        public bool Sucesso { get; set; } = true;


    }
}
