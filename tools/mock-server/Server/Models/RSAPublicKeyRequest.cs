using System.Text.Json.Serialization;
namespace Server.Models
{
  public class RSAPublicKeyRequest
  {
    [JsonPropertyName("RSAPublicKey")]
    public RSAPublicKeyData PublicKey { get; set; }
  }
}