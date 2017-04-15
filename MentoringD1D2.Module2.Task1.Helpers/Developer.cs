using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.Module2.Task1.Helpers
{
    /// <summary>
    /// The information about developer.
    /// </summary>
    public class Developer
    {

        #region Properties

        /// <summary>
        /// The name of a developer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email of a developer.
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The references  equality of objects
        /// </summary>
        /// <param name="obj">The compared developer instance</param>
        /// <returns>If instances of the developers are equality, it will return true, else false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            Developer developer = obj as Developer;
            if (developer == null)
                return false;
            
            return developer.Name == Name && developer.Email == Email;
            
        }

        #endregion
    }
}
