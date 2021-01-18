using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace IdentityEngine.Models.Configuration
{
    /// <summary>
    ///     A client claim.
    /// </summary>
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ClientClaim
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ClientClaim" /> class.
        /// </summary>
        public ClientClaim()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ClientClaim" /> class.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        public ClientClaim(string type, string value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ClientClaim" /> class.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        /// <param name="valueType">The claim value type.</param>
        public ClientClaim(string type, string value, string valueType)
        {
            Type = type;
            Value = value;
            ValueType = valueType;
        }

        /// <summary>
        ///     The claim type.
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        ///     The claim value.
        /// </summary>
        public string Value { get; set; } = null!;

        /// <summary>
        ///     The claim value type.
        /// </summary>
        public string ValueType { get; set; } = ClaimValueTypes.String;

        /// <inheritdoc />
        [SuppressMessage("ReSharper", "ConstantConditionalAccessQualifier")]
        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + Value?.GetHashCode() ?? 0;
                hash = hash * 23 + Type?.GetHashCode() ?? 0;
                hash = hash * 23 + ValueType?.GetHashCode() ?? 0;
                return hash;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj switch
            {
                null => false,
                ClientClaim c => string.Equals(Type, c.Type, StringComparison.Ordinal)
                                 && string.Equals(Value, c.Value, StringComparison.Ordinal)
                                 && string.Equals(ValueType, c.ValueType, StringComparison.Ordinal),
                _ => false
            };
        }
    }
}