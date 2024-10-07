namespace Client.Models;

public class AddressBuilder
{
    public static string NoSecureAddress(string address, int port) =>
        "http://" + address + ":" + port;
    
    public static string SecureAddress(string address, int port) =>
        "https://" + address + ":" + port;
}