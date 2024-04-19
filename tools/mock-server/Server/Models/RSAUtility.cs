using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Server.Models;
using System.Security.Cryptography;

public static class RSAUtility
{
  // This method imports a PEM-encoded public key into an RSACryptoServiceProvider object.
  public static RSACryptoServiceProvider ImportPublicKey(string pem)
  {
    // Initialise a StringReader to read from the PEM string.
    using var reader = new StringReader(pem);
    // Initialise a PemReader to read the PEM-encoded data.
    var pemReader = new PemReader(reader);
    // Read the PEM object. This can be either an AsymmetricCipherKeyPair or an AsymmetricKeyParameter.
    object pemObject = pemReader.ReadObject();

    AsymmetricKeyParameter publicKeyParameter;

    // Check if the PEM object is an AsymmetricCipherKeyPair (private key + public key).
    if (pemObject is AsymmetricCipherKeyPair keyPair)
    {
      // Extract the public key component.
      publicKeyParameter = keyPair.Public;
    }
    // Check if the PEM object is just an AsymmetricKeyParameter (public key).
    else if (pemObject is AsymmetricKeyParameter keyParameter)
    {
      // Use the public key directly.
      publicKeyParameter = keyParameter;
    }
    else
    {
      // If the PEM object is neither, throw an exception.
      throw new InvalidOperationException("Unsupported PEM object was found: " + pemObject.GetType().FullName);
    }

    // Convert the BouncyCastle public key parameters to RSAParameters.
    var rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKeyParameter);
    var rsa = new RSACryptoServiceProvider();
    rsa.ImportParameters(rsaParams);
    return rsa;
  }

  internal static object ImportPublicKey(RSAPublicKeyData publicKey)
  {
    throw new NotImplementedException();
  }
}
