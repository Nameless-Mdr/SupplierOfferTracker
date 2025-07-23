using System.Text.Json.Serialization;

namespace Host.Models.ErrorsModels;

/// <summary>
/// Объект, возвращаемый API в случае возникновения ошибки.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Код.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; } = string.Empty;
}