using System.Text.Json.Serialization;

namespace WebApi_Video.Enums
{


    // Atributo que especifica como a enumeração deve ser convertida para JSON.
    // O JsonStringEnumConverter converte o enum para uma string durante a serialização para JSON
    // e converte uma string de volta para o enum durante a desserialização.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        // Representa o departamento de Recursos Humanos.
        RH,

        // Representa o departamento Financeiro.
        Financeiro,

        // Representa o departamento de Compras.
        Compras,

        // Representa o departamento de Atendimento ao Cliente.
        Atendimento,

        // Representa o departamento de Zeladoria.
        Zeladoria
    }

}
