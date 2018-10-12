namespace Food_Journal.DB.Constants
{
    public interface ISecrets
    {
        string GoogleMapsKey { get; }
        string DbConnectionString { get; }
    }

    public static class Secrets
    {
        public static ISecrets MySecrets => new MySecrets();
    }
}
