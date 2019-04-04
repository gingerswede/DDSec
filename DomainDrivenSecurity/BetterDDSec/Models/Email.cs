using System;
using System.Collections;
using System.Collections.Generic;

namespace BetterDDSec.Models
{
    /// <summary>
    /// A more viable example than the overkill.
    /// </summary>
    public class Email : IComparable<Email>
    {
        private string _value;

        private string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (ValidateValue(value))
                {
                    _value = value;
                }
            }
        }

        public bool IsValid => ValidateValue(Value);

        public Email()
        {

        }
        public Email(string value)
        {
            Value = value;
        }

        private bool ValidateValue(string value)
        {
            //Valid email specification: https://www.ietf.org/rfc/rfc5322.txt
            //Will allow source: https://en.wikipedia.org/wiki/Email_address#Examples):
            //simple@example.com
            //very.common @example.com
            //disposable.style.email.with + symbol@example.com
            //other.email - with - hyphen@example.com
            //fully - qualified - domain@example.com
            //user.name + tag + sorting@example.com(may go to user.name@example.com inbox depending on mail server)
            //x @example.com(one - letter local - part)
            //example - indeed@strange - example.com
            //admin @mailserver1(local domain name with no TLD, although ICANN highly discourages dotless email addresses)
            //example @s.example(see the List of Internet top - level domains)
            //" "@example.org(space between the quotes)
            //"john..doe"@example.org
            //
            //Are all these needed to validate against?

            //Built in C# validation
            //Good enough?
            try
            {
                var mail = new System.Net.Mail.MailAddress(value);
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Not a valid e-mail address.");
            }

            //Regular expressions (a more classical approach that will work in
            //other languages as well. Including alphanumerical, period (.), 
            //dash (-) and underscore (_).
            string emailRegex = @"^(?:(\w|\d|-|\.)+@(\w|-)+\.\w{2,})$";

            if (System.Text.RegularExpressions.Regex.IsMatch(value, emailRegex) && value.Length < 255)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Not a valid e-mail address.");
            }
        }

        /// <summary>
        /// Auto instantiate a new Name object as if it were a regular String through
        /// Email mail = "e-mail@example.com" instead of Email mail = new Email("e-mail@example.com").
        /// </summary>
        /// <param name="value">Value to give to the object</param>
        public static implicit operator Email(string value)
        {
            try
            {
                return (value == null) ? null : new Email(value);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Make the class act as if it was a regular string when
        /// only variable name is used in for example binding in 
        /// a usercontrol.
        /// </summary>
        /// <param name="self">This</param>
        public static explicit operator string(Email self)
        {
            return self?._value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        #region Interface implemetation

        public int CompareTo(Email other)
        {
            return _value.CompareTo(other.ToString());
        }

        #endregion
    }
}