using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IdentityEngine.Models.Configuration
{
    /// <summary>
    ///     Models the common data of API and identity resources.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverQueried.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public abstract class Resource
    {
        [SuppressMessage("ReSharper", "ConstantNullCoalescingCondition")]
        private string DebuggerDisplay => Name ?? $"{{{typeof(Resource)}}}";

        /// <summary>
        ///     Indicates if this resource is enabled. Defaults to true.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     The unique name of the resource.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        ///     Display name of the resource.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        ///     Description of the resource.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        ///     Specifies whether this scope is shown in the discovery document. Defaults to true.
        /// </summary>
        public bool ShowInDiscoveryDocument { get; set; } = true;

        /// <summary>
        ///     Associated user claims that should be included when this resource is requested.
        /// </summary>
        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();

        /// <summary>
        ///     Gets or sets the custom properties for the resource.
        /// </summary>
        /// <value>
        ///     The properties.
        /// </value>
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}