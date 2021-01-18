using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IdentityEngine.Models.Configuration
{
    /// <summary>
    ///     Models a user identity resource.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class IdentityResource : Resource
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IdentityResource" /> class.
        /// </summary>
        public IdentityResource()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="IdentityResource" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="userClaims">Associated user claims that should be included when this resource is requested.</param>
        public IdentityResource(string name, IEnumerable<string> userClaims)
            : this(name, name, userClaims)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="IdentityResource" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="userClaims">Associated user claims that should be included when this resource is requested.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        /// <exception cref="System.ArgumentException">Must provide at least one claim type - claimTypes.</exception>
        public IdentityResource(string name, string? displayName, IEnumerable<string> userClaims)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (userClaims == null)
            {
                throw new ArgumentException("Must provide at least one claim type", nameof(userClaims));
            }

            Name = name;
            DisplayName = displayName;
            var claimsProvided = false;
            foreach (var type in userClaims)
            {
                UserClaims.Add(type);
                claimsProvided = true;
            }

            if (!claimsProvided)
            {
                throw new ArgumentException("Must provide at least one claim type", nameof(userClaims));
            }
        }

        [SuppressMessage("ReSharper", "ConstantNullCoalescingCondition")]
        private string DebuggerDisplay => Name ?? $"{{{typeof(IdentityResource)}}}";

        /// <summary>
        ///     Specifies whether the user can de-select the scope on the consent screen (if the consent screen wants to implement
        ///     such a feature). Defaults to false.
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        ///     Specifies whether the consent screen will emphasize this scope (if the consent screen wants to implement such a
        ///     feature).
        ///     Use this setting for sensitive or important scopes. Defaults to false.
        /// </summary>
        public bool Emphasize { get; set; } = false;
    }
}