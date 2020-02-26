namespace LoanApi.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using LoanApi.Commands;
    using LoanApi.Constants;
    using LoanApi.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using Swashbuckle.AspNetCore.Annotations;

    [Route("[controller]")]
    [ApiController]
    [ApiVersion(ApiVersionName.V1)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA1062 // Validate arguments of public methods
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Deletes the user with the specified unique identifier.
        /// </summary>
        /// <param name="command">The action command.</param>
        /// <param name="userId">The users unique identifier.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 204 No Content response if the user was deleted or a 404 Not Found if a user with the specified
        /// unique identifier was not found.</returns>
        [HttpDelete("{userId}", Name = UsersControllerRoute.DeleteUser)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The user with the specified unique identifier was deleted.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "A user with the specified unique identifier was not found.", typeof(ProblemDetails))]
        public Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteUserCommand command,
            int userId,
            CancellationToken cancellationToken) => command.ExecuteAsync(userId, cancellationToken);

        /// <summary>
        /// Gets the user with the specified unique identifier.
        /// </summary>
        /// <param name="command">The action command.</param>
        /// <param name="userId">The users unique identifier.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 200 OK response containing the user or a 404 Not Found if a user with the specified unique
        /// identifier was not found.</returns>
        [HttpGet("{userId}", Name = UsersControllerRoute.GetUser)]
        [SwaggerResponse(StatusCodes.Status200OK, "The user with the specified unique identifier.", typeof(User))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "A user with the specified unique identifier could not be found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
        public Task<IActionResult> GetAsync(
            [FromServices] IGetUserCommand command,
            int userId,
            CancellationToken cancellationToken) => command.ExecuteAsync(userId, cancellationToken);

         /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="command">The action command.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 200 OK response containing the user or a 404 Not Found if a user with the specified unique
        /// identifier was not found.</returns>
        [HttpGet(Name = UsersControllerRoute.GetUsers)]
        [SwaggerResponse(StatusCodes.Status200OK, "All users.", typeof(List<User>))]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
        public Task<IActionResult> GetAsync(
            [FromServices] IGetUsersCommand command,
            CancellationToken cancellationToken) => command.ExecuteAsync(cancellationToken);


        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="command">The action command.</param>
        /// <param name="user">The user to create.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 201 Created response containing the newly created user or a 400 Bad Request if the user is
        /// invalid.</returns>
        [HttpPost("", Name = UsersControllerRoute.PostUser)]
        [SwaggerResponse(StatusCodes.Status201Created, "The user was created.", typeof(User))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The user is invalid.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status415UnsupportedMediaType, "The MIME type in the Content-Type HTTP header is unsupported.", typeof(ProblemDetails))]
        public Task<IActionResult> PostAsync(
            [FromServices] IPostUserCommand command,
            [FromBody] SaveUser user,
            CancellationToken cancellationToken) => command.ExecuteAsync(user, cancellationToken);

        /// <summary>
        /// Updates an existing user with the specified unique identifier.
        /// </summary>
        /// <param name="command">The action command.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="user">The user to update.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 200 OK response containing the newly updated user, a 400 Bad Request if the user is invalid or a
        /// or a 404 Not Found if a user with the specified unique identifier was not found.</returns>
        [HttpPut("{userId}", Name = UsersControllerRoute.PutUser)]
        [SwaggerResponse(StatusCodes.Status200OK, "The user was updated.", typeof(User))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The user is invalid.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "A user with the specified unique identifier could not be found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status415UnsupportedMediaType, "The MIME type in the Content-Type HTTP header is unsupported.", typeof(ProblemDetails))]
        public Task<IActionResult> PutAsync(
            [FromServices] IPutUserCommand command,
            int userId,
            [FromBody] SaveUser user,
            CancellationToken cancellationToken) => command.ExecuteAsync(userId, user, cancellationToken);
    }
}
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore CA1822 // Mark members as static
