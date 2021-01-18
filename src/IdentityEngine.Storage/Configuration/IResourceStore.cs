using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdentityEngine.Models.Configuration;

namespace IdentityEngine.Storage.Configuration
{
    /// <summary>
    ///     Resource retrieval.
    /// </summary>
    public interface IResourceStore
    {
        /// <summary>
        ///     Gets identity resources by scope name.
        /// </summary>
        Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(
            IEnumerable<string> scopeNames,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets API scopes by scope name.
        /// </summary>
        Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(
            IEnumerable<string> scopeNames,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets API resources by scope name.
        /// </summary>
        Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(
            IEnumerable<string> scopeNames,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets API resources by API resource name.
        /// </summary>
        Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(
            IEnumerable<string> apiResourceNames,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets all resources.
        /// </summary>
        Task<Resources> GetAllResourcesAsync(CancellationToken cancellationToken = default);
    }
}