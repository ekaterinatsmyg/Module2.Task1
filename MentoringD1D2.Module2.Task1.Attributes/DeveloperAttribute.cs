using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MentoringD1D2.Module2.Task1.Logger;
using MentoringD1D2.Module2.Task1.Logger.Enums;

namespace MentoringD1D2.Module2.Task1.Attributes
{
    /// <summary>
    /// The attribute for classes that contain information about developer.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class DeveloperAttribute : Attribute
    {
        /// <summary>
        /// The provider of email validation
        /// </summary>
        private static Regex regex = CreateRegEx();

        /// <summary>
        /// The email of a developer. 
        /// </summary>
        /// <example>example@email.com</example>
        public string  DeveloperEmail { get; private set; }

        /// <summary>
        /// The name of a developer.
        /// </summary>
        public string DeveloperName { get; private set; }
        
        /// <summary>
        /// Creates an attribute that contain informaion about developer.
        /// </summary>
        /// <param name="developerName">The name of a developer.</param>
        /// <param name="developerEmail">The email of a developer.</param>       
        public DeveloperAttribute(string developerName, string developerEmail)
        {
            DeveloperName = developerName;
            if (!IsValid(developerEmail))
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"Invalid email address {developerEmail}. Example of correct email: xxxxxx@example.com. MethodInfo : {MethodBase.GetCurrentMethod()}");
            }
            DeveloperEmail = developerEmail;
        }


        private static bool IsValid(string developerEmail)
        {
            if (String.IsNullOrEmpty(developerEmail))
            {
                return true;
            }

            return regex?.Match(developerEmail).Length > 0;
        }
        

        private static Regex CreateRegEx()
        {
            const string pattern = @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$";

            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            
           return new Regex(pattern, options);
        }
    }
}
