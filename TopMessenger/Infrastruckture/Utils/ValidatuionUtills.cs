using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMessenger.Infrastruckture.Utils
{
    public class ValidatuionUtills
    {
        public static bool EmptyStrValidate(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool DigitContainsValidate(string value)
        {
            foreach (var item in value)
            {
                if (char.IsDigit(item)==true)
                {
                    return false;
                }
                
            }
            return true;

        }
        /// <summary>
        /// Значение является валидными сли есть спец. символы
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        
        public static bool SymbContainsValidate(string value)
        {
            foreach (var item in value)
            {
                if (item == '^')
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EmailValidate(string value)
        {
            foreach (var item in value)
            {
                if (item == '@')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
