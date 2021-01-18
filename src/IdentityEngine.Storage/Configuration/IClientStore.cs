using System.Threading;
using System.Threading.Tasks;
using IdentityEngine.Models.Configuration;

namespace IdentityEngine.Storage.Configuration
{
    /// <summary>
    ///     Retrieval of client configuration.
    /// </summary>
    public interface IClientStore
    {
        /// <summary>
        ///     Finds a client by id.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="cancellationToken">
        ///     The <see cref="CancellationToken" /> used to propagate notifications that the operation
        ///     should be canceled.
        /// </param>
        /// <returns>The client.</returns>
        Task<Client?> FindClientByIdAsync(string clientId, CancellationToken cancellationToken = default);
    }
}