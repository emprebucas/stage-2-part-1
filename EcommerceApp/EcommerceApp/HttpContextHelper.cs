namespace EcommerceApp
{
    /// <summary>
    /// HttpContextHelper used to access and retrieve the 'x-user-id' from the HTTP context
    /// </summary>
    public class HttpContextHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// HttpContextHelper constructor.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// The `GetUserId` method is used to retrieve the user ID from the HTTP context. 
        /// It returns a `Guid` representing the user ID.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public Guid GetUserId()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                // attempts to retrieve the value of the "x-user-id" header from the request headers then tries to parse the retrieved value as a GUID
                if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("x-user-id", out var userIdHeader) && Guid.TryParse(userIdHeader, out var userId))
                {
                    return userId;
                }
            }

            throw new UnauthorizedAccessException("Invalid user ID.");
        }
    }

}
