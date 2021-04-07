using DANMIS_NEW.ViewModel;

namespace DANMIS_NEW.Models
{
    public class UserToken
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public UserViewModel Data { get; set; }
    }
}