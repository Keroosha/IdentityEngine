using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IdentityEngine.Models.Configuration
{
    /// <summary>
    ///     Models a collection of identity and API resources..
    /// </summary>
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class Resources
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Resources" /> class.
        /// </summary>
        public Resources()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Resources" /> class.
        /// </summary>
        /// <param name="other">The other.</param>
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        public Resources(Resources other)
        {
            if (other.IdentityResources != null)
            {
                foreach (var identityResource in other.IdentityResources)
                {
                    IdentityResources.Add(identityResource);
                }
            }

            if (other.ApiResources != null)
            {
                foreach (var apiResource in other.ApiResources)
                {
                    ApiResources.Add(apiResource);
                }
            }

            if (other.ApiScopes != null)
            {
                foreach (var apiScope in other.ApiScopes)
                {
                    ApiScopes.Add(apiScope);
                }
            }

            OfflineAccess = other.OfflineAccess;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Resources" /> class.
        /// </summary>
        /// <param name="identityResources">The identity resources.</param>
        /// <param name="apiResources">The API resources.</param>
        /// <param name="apiScopes">The API scopes.</param>
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        public Resources(
            IEnumerable<IdentityResource> identityResources,
            IEnumerable<ApiResource> apiResources,
            IEnumerable<ApiScope> apiScopes)
        {
            if (identityResources != null)
            {
                foreach (var identityResource in identityResources)
                {
                    IdentityResources.Add(identityResource);
                }
            }

            if (apiResources != null)
            {
                foreach (var apiResource in apiResources)
                {
                    ApiResources.Add(apiResource);
                }
            }

            if (apiScopes != null)
            {
                foreach (var apiScope in apiScopes)
                {
                    ApiScopes.Add(apiScope);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [offline access].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [offline access]; otherwise, <c>false</c>.
        /// </value>
        public bool OfflineAccess { get; set; }

        /// <summary>
        ///     Gets or sets the identity resources.
        /// </summary>
        public ICollection<IdentityResource> IdentityResources { get; set; } = new HashSet<IdentityResource>();

        /// <summary>
        ///     Gets or sets the API resources.
        /// </summary>
        public ICollection<ApiResource> ApiResources { get; set; } = new HashSet<ApiResource>();

        /// <summary>
        ///     Gets or sets the API scopes.
        /// </summary>
        public ICollection<ApiScope> ApiScopes { get; set; } = new HashSet<ApiScope>();
    }
}