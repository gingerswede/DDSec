using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDDSec.Models
{
    /// <summary>
    /// Implementation of integer values with only basic functionality and
    /// mocking of primary type.
    /// </summary>
    public class Year
    {
        private int _value;

        public Year(string value)
        {
            _value = int.Parse(value);
        }

        public Year(int value)
        {
            _value = value;
        }

        /// <summary>
        /// Auto instantiate a new Name object as if it were a regular String through
        /// Email mail = "e-mail@example.com" instead of Email mail = new Email("e-mail@example.com").
        /// </summary>
        /// <param name="value">Value to give to the object</param>
        public static implicit operator Year(int value)
        {
            return new Year(value);
        }

        public static implicit operator int(Year self)
        {
            return self._value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
