using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMessenger.Infrastruckture.Utills
{
    public enum ValidateType
    {
        EmptryStr,
        /// <summary>
        /// Проверка на отсутствие чисел (нет чисел - валидно)
        /// </summary>
        DigitContains,
        SpecialSymb,
        IsEmailValidate

    }
    public class ValidatuionUtills
    {
        private static event Func<string, bool>  _validateEvent;

        public static bool Validate(string value, params ValidateType[] validateTypes)
        {
            if (validateTypes.Contains(ValidateType.EmptryStr)==true)
            {
                _validateEvent += EmptyStrValidate;
            }
            if (validateTypes.Contains(ValidateType.IsEmailValidate)==true)
            {
                _validateEvent += EmailValidate;
            }
            if (validateTypes.Contains(ValidateType.DigitContains)==true)
            {
                _validateEvent += DigitContainsValidate;
            }
            if (validateTypes.Contains(ValidateType.SpecialSymb)==true)
            {
                _validateEvent += SymbContainsValidate;
            }

            if (_validateEvent != null)
            {
                return _validateEvent(value);
            }
            else
            {
                return false;
            }
        }

       

        public static bool EmptyStrValidate(string value)//
        {
            if (string.IsNullOrEmpty(value)) return false;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool DigitContainsValidate(string value)//
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
