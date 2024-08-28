using System.Text.Json.Serialization;

namespace WebApi_Video.Enums
{
    // Atributo que especifica como o enum deve ser convertido para JSON.
    // O JsonStringEnumConverter converte o enum para uma string durante a serialização para JSON
    // e converte uma string de volta para o enum durante a desserialização.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        // Representa o turno da manhã.
        Manha,

        // Representa o turno da tarde.
        Tarde,

        // Representa o turno da noite.
        Noite
    }
}

