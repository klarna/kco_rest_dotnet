namespace Klarna.Rest.Core.Common
{
    /// <summary>
    /// The API is accessible through a few different URLS. There are different URLs for testing and for making
    /// live purchases as well as different URLs for depending on if you are based in Europe or in the U.S.
    /// </summary>
    public enum KlarnaEnvironment
    {
        /// <summary>
        /// The API for the European live environment (https://api.klarna.com/)
        /// </summary>
        LiveEurope,
        /// <summary>
        /// The API for the U.S. live environment (https://api-na.klarna.com/)
        /// </summary>
        LiveNorthAmerica,
        /// <summary>
        /// The API for the European testing environment (https://api.playground.klarna.com/)
        /// </summary>
        TestingEurope,
        /// <summary>
        /// The API for the U.S. testing environment (https://api-na.playground.klarna.com/)
        /// </summary>
        TestingNorthAmerica,
    }
}