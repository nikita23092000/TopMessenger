﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopMessenger.Infrastruckture.Utills;
using TopMessenger.ViewModels.Command;

namespace TopMessenger.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        #region Commangs
        public ActionCommand RegistrationCommand => new ActionCommand(x=>Registration());

        public object ValidationUtills { get; private set; }
        #endregion

        #region Properties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { UpdateValue(ref firstName, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { UpdateValue(ref email, value); }
        }

        private bool isFirstNameValid;

        public bool IsFirstNameValid
        {
            get { return isFirstNameValid; }
            set { UpdateValue(ref isFirstNameValid, value); }
        }
        private bool isEmailValid;

        public bool IsEmailValid
        {
            get { return isEmailValid; }
            set { UpdateValue(ref isEmailValid, value); }
        }


        #endregion

        public RegistrationViewModel()
        {
            
        }

        private void Registration()
        {
            IsFirstNameValid = ValidationUtills.EmptyStrValidate(FirstName, ValidateType.DigitContains, ValidateType.EmptryStr); ;
            IsFirstNameValid = ValidationUtills.EmptyStrValidate(Email, ValidateType.EmptryStr, ValidateType.IsEmailValidate); ;

        }
    }
}
