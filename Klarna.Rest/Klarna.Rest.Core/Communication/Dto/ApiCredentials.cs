namespace Klarna.Rest.Core.Communication.Dto
{
    /// <summary>
    /// DTO class for Klarna API Credentials
    /// </summary>
    public class ApiCredentials
    {
        /// <summary>
        /// Consists of your Merchant ID (eid) - a unique number that identifies your e-store, combined
        /// with a random string.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// a string which is associated with your Merchant ID and is used to authorize use of Klarna's APIs
        /// </summary>
        public string Password { get; set; }
    }
}
