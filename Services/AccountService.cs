using PMS_v1.DataAccess;

namespace PMS_v1.Services
{
    // SERVICE for system accounts on the Settings page: the rules around changing and deleting an account.
    // The Settings page calls this; this calls UserAccountData for anything that needs the database.
    public class AccountService
    {
        private readonly UserAccountData _data = new UserAccountData();

        // True when this account is an active admin and no other active admin exists.
        public bool IsLastActiveAdmin(int userId)
        {
            return _data.IsLastActiveAdmin(userId);
        }

        // Saves the account. A blank password keeps the current one; otherwise it is hashed before it is stored.
        public void UpdateAccount(int userId, string username, string role, string status, string password)
        {
            string? passwordHash = password.Length > 0 ? BCrypt.Net.BCrypt.HashPassword(password) : null;
            _data.UpdateAccount(userId, username, role, status, passwordHash);
        }
    }
}
