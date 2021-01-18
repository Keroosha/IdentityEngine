using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IdentityEngine.Models.Configuration
{
    /// <summary>
    ///     Models a web API resource.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ApiResource : Resource
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResource" /> class.
        /// </summary>
        public ApiResource()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResource" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ApiResource(string name)
            : this(name, name, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResource" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="displayName">The display name.</param>
        [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global")]
        public ApiResource(string name, string? displayName)
            : this(name, displayName, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResource" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="userClaims">Associated user claims that should be included when this resource is requested.</param>
        public ApiResource(string name, IEnumerable<string>? userClaims)
            : this(name, name, userClaims)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResource" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="userClaims">Associated user claims that should be included when this resource is requested.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        public ApiResource(string name, string? displayName, IEnumerable<string>? userClaims)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            DisplayName = displayName;

            if (userClaims != null)
            {
                foreach (var type in userClaims)
                {
                    UserClaims.Add(type);
                }
            }
        }

        [SuppressMessage("ReSharper", "ConstantNullCoalescingCondition")]
        private string DebuggerDisplay => Name ?? $"{{{typeof(ApiResource)}}}";

        /// <summary>
        ///     The API secret is used for the introspection endpoint. The API can authenticate with introspection using the API
        ///     name and secret.
        /// </summary>
        public ICollection<Secret> ApiSecrets { get; set; } = new HashSet<Secret>();

        /// <summary>
        ///     Models the scopes this API resource allows.
        /// </summary>
        public ICollection<string> Scopes { get; set; } = new HashSet<string>();

        /// <summary>
        ///     Signing algorithm for access token. If empty, will use the server default signing algorithm.
        /// </summary>
        public ICollection<string> AllowedAccessTokenSigningAlgorithms { get; set; } = new HashSet<string>();
    }
}