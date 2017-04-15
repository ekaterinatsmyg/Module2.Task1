using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MentoringD1D2.Module2.Task1.Attributes;
using MentoringD1D2.Module2.Task1.Logger;
using MentoringD1D2.Module2.Task1.Logger.Enums;

namespace MentoringD1D2.Module2.Task1.Helpers
{
    /// <summary>
    /// The helper that collect information about a creator of type.
    /// </summary>
    public static class DeveloperHelper
    {
        /// <summary>
        /// Generate Developer instance based on type attribute.
        /// </summary>
        /// <param name="type">The type that has an attribute Developer.</param>
        /// <returns>The developers that created type <para>type</para>.</returns>
        public static IEnumerable<Developer> GetDeveloperAttributes(Type type)
        {
            if (type == null)
                return null;
            IList<DeveloperAttribute> developerAttributes =
                (IList<DeveloperAttribute>)Attribute.GetCustomAttributes(type, typeof(DeveloperAttribute));

            if (!developerAttributes.Any())
            {
                ApplicationLogger.LogMessage(LogMessageType.Info,
                    $"There aren't any attribytes related to type : {type.FullName}");
                return new List<Developer>();
            }
            return developerAttributes.Select(attribute => new Developer { Name = attribute.DeveloperName, Email = attribute.DeveloperEmail });
        }
    }
}
