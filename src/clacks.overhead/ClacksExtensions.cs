using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;

namespace clacks.overhead
{
    /// <summary>
    ///     Extension method for adding the <see cref="T:clacks.overhead.ClacksMiddleware" /> middleware to an
    ///     <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />.
    /// </summary>
    public static class ClacksExtensions
    {
        /// <summary>
        ///     Adds a <see cref="T:clacks.overhead.ClacksMiddleware" /> middleware to the specified
        ///     <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" /> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder RememberTerryPratchett([NotNull] this IApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            return builder.UseMiddleware<ClacksMiddleware>();
        }
    }
}
