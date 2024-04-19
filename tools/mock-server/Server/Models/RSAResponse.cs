using System.Text.Json.Serialization;
namespace Server.Models
{
  public class RSAResponse
  {

    public string StoreId { get; set; }
    public string TerminalId { get; set; }
    public bool DisabledEFTMerchantReceipt { get; set; }
    public string ServiceUrl { get; set; }
    public string ESKey { get; set; }
  }

}