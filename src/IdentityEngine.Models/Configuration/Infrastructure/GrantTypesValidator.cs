using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using IdentityEngine.Models.Configuration.Constants;

namespace IdentityEngine.Models.Configuration.Infrastructure
{
    /// <summary>
    ///     Helper class to validate grant types.
    /// </summary>
    public static class GrantTypesValidator
    {
        /// <summary>
        ///     Validates the grant types.
        /// </summary>
        /// <param name="grantTypes">The grant types.</param>
        /// <exception cref="ArgumentNullException">Grant types collection is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Grant types collection is empty or contain spaces or contains duplicate
        ///     values or contains incompatible values.
        /// </exception>
        public static void ValidateGrantTypes(ICollection<string> grantTypes)
        {
            if (grantTypes == null)
            {
                throw new ArgumentNullException(nameof(grantTypes));
            }

            // spaces are not allowed in grant types
            foreach (var type in grantTypes)
            {
                if (type.Contains(' '))
                {
                    throw new InvalidOperationException("Grant types cannot contain spaces");
                }
            }

            // single grant type, seems to be fine
            if (grantTypes.Count == 1)
            {
                return;
            }

            // don't allow duplicate grant types
            if (grantTypes.Count != grantTypes.Distinct().Count())
            {
                throw new InvalidOperationException("Grant types list contains duplicate values");
            }

            // would allow response_type downgrade attack from code to token
            DisallowGrantTypeCombination(GrantType.Implicit, GrantType.AuthorizationCode, grantTypes);
            DisallowGrantTypeCombination(GrantType.Implicit, GrantType.Hybrid, grantTypes);
            DisallowGrantTypeCombination(GrantType.AuthorizationCode, GrantType.Hybrid, grantTypes);
        }

        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        private static void DisallowGrantTypeCombination(string value1, string value2, ICollection<string> grantTypes)
        {
            if (grantTypes.Contains(value1, StringComparer.Ordinal)
                && grantTypes.Contains(value2, StringComparer.Ordinal))
            {
                throw new InvalidOperationException($"Grant types list cannot contain both {value1} and {value2}");
            }
        }
    }
}