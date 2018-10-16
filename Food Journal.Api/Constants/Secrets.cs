namespace Food_Journal.Api.Constants
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
