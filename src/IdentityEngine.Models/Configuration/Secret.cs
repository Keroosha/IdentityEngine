using System;
using System.Diagnostics.CodeAnalysis;
using IdentityEngine.Models.Internal;

namespace IdentityEngine.Models.Configuration
{
    /// <summary>
    ///     Models a client secret with identifier and expiration
    /// </summary>
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Secret
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Secret" /> class.
        /// </summary>
        public Secret()
        {
            Type = InternalIdentityEngineConstants.SecretTypes.SharedSecret;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Secret" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="expiration">The expiration.</param>
        public Secret(string value, DateTimeOffset? expiration = null)
            : this()
        {
            Value = value;
            Expiration = expiration;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Secret" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="description">The description.</param>
        /// <param name="expiration">The expiration.</param>
        public Secret(string value, string description, DateTimeOffset? expiration = null)
            : this()
        {
            Description = description;
            Value = value;
            Expiration = expiration;
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public string Value { get; set; } = null!;

        /// <summary>
        ///     Gets or sets the expiration.
        /// </summary>
        /// <value>
        ///     The expiration.
        /// </value>
        public DateTimeOffset? Expiration { get; set; }

        /// <summary>
        ///     Gets or sets the type of the client secret.
        /// </summary>
        /// <value>
        ///     The type of the client secret.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        [SuppressMessage("ReSharper", "ConstantConditionalAccessQualifier")]
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (Value?.GetHashCode() ?? 0);
                hash = hash * 23 + (Type?.GetHashCode() ?? 0);
                return hash;
            }
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is Secret other))
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return string.Equals(other.Type, Type, StringComparison.Ordinal)
                   && string.Equals(other.Value, Value, StringComparison.Ordinal);
        }
    }
}