using Scrypt;

namespace TodoListApp.Services
{
    public interface IPasswordHasherService
    {
        string HashPassword(string password);
        bool ComparePasswordToHash(string providedPassword, string hashedPassword);
    }

    internal class PasswordHasherService : IPasswordHasherService
    {
        private static readonly ScryptEncoder _encoder = new();

        public string HashPassword(string password)
        {
            return _encoder.Encode(password);
        }

        public bool ComparePasswordToHash(string providedPassword, string hashedPassword)
        {
            return _encoder.Compare(providedPassword, hashedPassword);
        }
    }
}
