using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;
using TheFirstExampleProject.Views.EditViews;

namespace TheFirstExampleProject.Views;

public partial class UserEditWindow : Window
{
    public UserWindowViewModel OwnerViewModel { get; set; }

    public UserEditWindow()
    {
        InitializeComponent();

        DataContext = new UserWindowViewModel();

        if (UserVariableData.selectedUserInMainWindow != null)
        {
            var loginInSelectedUser =
                App.DbContext.Logins.FirstOrDefault(x => x.IdUser == UserVariableData.selectedUserInMainWindow.IdUser);
            FioTextBox.Text = UserVariableData.selectedUserInMainWindow.Fio;
            PhoneNumberTextBox.Text = UserVariableData.selectedUserInMainWindow.PhoneNumber;
            DescriptionTextBox.Text = UserVariableData.selectedUserInMainWindow.Description;
            ComboBoxRoles.SelectedValue =
                App.DbContext.Roles.FirstOrDefault(x => x.IdRole == UserVariableData.selectedUserInMainWindow.IdRole);
            LoginTextBox.Text = loginInSelectedUser.Login1;
            PasswordTextBox.Text = loginInSelectedUser.Password;
        }
    }

    private void Create_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (
            string.IsNullOrEmpty(FioTextBox.Text) ||
            string.IsNullOrEmpty(PhoneNumberTextBox.Text) ||
                string.IsNullOrEmpty(DescriptionTextBox.Text) ||
                string.IsNullOrEmpty(LoginTextBox.Text) ||
                string.IsNullOrEmpty(PasswordTextBox.Text) ||
                ComboBoxRoles.SelectedValue == null
        ) return;
        
            if (UserVariableData.selectedUserInMainWindow != null)
            {
                Console.WriteLine("Edit user " + UserVariableData.selectedUserInMainWindow.IdUser);

                var idUser = UserVariableData.selectedUserInMainWindow.IdUser;
                var selectedUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);
                var selectedLogin =
                    App.DbContext.Logins.FirstOrDefault(x =>
                        x.IdUser == UserVariableData.selectedUserInMainWindow.IdUser);

                if (selectedUser == null) return;

                selectedUser.Fio = FioTextBox.Text;
                selectedUser.PhoneNumber = PhoneNumberTextBox.Text;
                selectedUser.Description = DescriptionTextBox.Text;

                selectedLogin.Login1 = LoginTextBox.Text;
                selectedLogin.Password = PasswordTextBox.Text;

                var selectedRole = ComboBoxRoles.SelectedValue as Role;
                selectedUser.IdRole = selectedRole.IdRole;
            }
            else
            {
                Console.WriteLine("Create new user");

                var selectedRole = ComboBoxRoles.SelectedValue as Role;

                var newUser = new User()
                {
                    Fio = FioTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    IdRole = selectedRole.IdRole
                };

                App.DbContext.Users.Add(newUser);
                App.DbContext.SaveChanges();

                var newLogin = new Login()
                {
                    IdUser = newUser.IdUser,
                    Login1 = LoginTextBox.Text,
                    Password = PasswordTextBox.Text
                };

                App.DbContext.Logins.Add(newLogin);
                App.DbContext.SaveChanges();
            }

            OwnerViewModel?.RefreshData();
            Close();
        }
    
}