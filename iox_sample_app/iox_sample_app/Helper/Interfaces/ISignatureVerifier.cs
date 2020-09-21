namespace iox_sample_app.Helper.Interfaces
{
    public interface ISignatureVerifier
    {
        bool VerifySignature(string payload, string hmac);
    }
}
