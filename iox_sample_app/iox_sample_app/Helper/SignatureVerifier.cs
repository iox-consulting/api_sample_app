using System.Security.Cryptography;
using System.Text;

namespace iox_sample_app.Helper
{
    public class SignatureVerifier : ISignatureVerifier
    {
        public SignatureVerifier()
        {
        }

        public bool VerifySignature(string payload, string hmac)
        {
            var tester = payload.ToString();
            var generateedHmac = GenerateHmac(payload);

            return generateedHmac == hmac;
        }

        public static string GenerateHmac(string dataToHash)
        {
            var sharedKey = "YourSharedKeyProvidedWhenSettingUpEndpoint";
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.ASCII.GetBytes(sharedKey)))
            {
                byte[] bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(dataToHash));
                return BytesToHex(bytes);
            }
        }

        private static string BytesToHex(byte[] data)
        {
            StringBuilder hexString = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                hexString.Append(data[i].ToString("x2"));
            }

            return hexString.ToString();
        }
    }
}