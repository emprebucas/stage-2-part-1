using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Models;
using MySqlConnector;
using Dapper;

namespace EcommerceApp
{
    /// <summary>
    /// BasicAuthenticationHandler is an authentication handler.
    /// </summary>
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// BasicAuthenticationHandler constructor which takes in various dependencies 
        /// such as options, logger, encoder, clock, and configuration.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <param name="encoder"></param>
        /// <param name="clock"></param>
        /// <param name="configuration"></param>
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IConfiguration configuration)
            : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// AuthenticateResult implements the authentication logic. 
        /// This method is responsible for authenticating the user based on the provided headers.
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // if the "x-user-id" header is not present in the request, it returns a
            // failure result with a message indicating the missing authorization header
            if (!Request.Headers.ContainsKey("x-user-id"))
            {
                return AuthenticateResult.Fail("Missing Authorization header.");
            }
                        
            try
            {
                // if the 'x-user-id' header is present, it retrieves the user ID value from the header
                var userId = Request.Headers["x-user-id"].ToString();

                if (string.IsNullOrEmpty(userId))
                {
                    return AuthenticateResult.Fail("Invalid Authorization header.");
                }

                // converting the retrieved userId from the header to GUID so it can be used in the query
                Guid guidUserId = new(userId);

                // connect to the database to query, as a validation if 'x-user-id' will be authorized or not
                var connectionString = _configuration.GetConnectionString("ECommerceDb");
                using var connection = new MySqlConnection(connectionString);

                var query = "SELECT * FROM Users WHERE UserId = @UserId";
                var users = await connection.QueryAsync<UserModel>(query, new { UserId = guidUserId });
                var user = users.FirstOrDefault();

                if (user != null)
                {
                    // if the user is valid, create the claims, identity, and authentication ticket
                    // basically allowing the API operation to start
                    var claims = new[] { new Claim(ClaimTypes.Name, userId) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

                return AuthenticateResult.Fail("Invalid Authorization header. User is null");
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization header.");
            }
        }

    }
}
