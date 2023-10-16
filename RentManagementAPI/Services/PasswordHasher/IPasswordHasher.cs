namespace RentManagementAPI.Services.PasswordHasher
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string InputPassword);   
    }
}
