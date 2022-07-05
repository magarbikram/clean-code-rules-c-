namespace CleanCode
{
    public interface ICryptographer
    {
        string Decrypt(string codedPhrase, string password);
    }
}