using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TopMessenger.Infrastruckture.Services;
using TopMessenger.ModelShels;
using TopMessenger.ViewModels.Command;

namespace TopMessenger.ViewModels
{
    public class AddFriendViewMidel : BaseViewModel
    {
        #region Propertis
        private string name;

		public string Name
		{
			get { return name; }
			set { name = value; UpdateValue<string>(ref name, value); }
		}

		private string lastName;

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; UpdateValue<string>(ref lastName, value); }
		}
		private ObservableCollection<UserAddFriendShell> allUsers;
		
		public ObservableCollection<UserAddFriendShell> AllUsers
		{
			get { return allUsers; }
			set { UpdateValue(ref allUsers, value); }
		}

		private readonly UserService _userService;

		#endregion

		#region Commands
		public ActionCommand CloseWindowCommand => new ActionCommand(x => Application.Current.Windows[Application.Current.Windows.Count -1].Close());
		public ActionCommand AddGriendCommand => new ActionCommand(x => MessageBox.Show("Check"));
        #endregion

       private AddFriendViewMidel()
		{
			_userService = new UserService();
			LoadInfo().GetAwaiter();
		}

		private async Task LoadInfo()
		{
			AllUsers = await _userService.GetAllUsersForAddFriend(await _userService.GetUser(20));
		}
      

    }
}
