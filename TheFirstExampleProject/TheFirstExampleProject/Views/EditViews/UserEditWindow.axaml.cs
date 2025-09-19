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
    public UserEditWindow()
    {
        InitializeComponent();
        
        // Загружаем все роли
        var allRoles = App.DbContext.Roles.ToList();
        ComboBoxRoles.ItemsSource = allRoles;

        if (UserVariableData.selectedUser != null)
        {
            DataContext = UserVariableData.selectedLogin;

            // Устанавливаем выбранную роль
            var selectedRole = allRoles.FirstOrDefault(r => r.IdRole == UserVariableData.selectedUser.IdRole);
            ComboBoxRoles.SelectedItem = selectedRole;
        }
        
        if (UserVariableData.selectedUser != null)
        {
            // var loginInSelectedUser =
            //     App.DbContext.Logins.FirstOrDefault(x => x.IdUser == UserVariableData.selectedUser.IdUser);
            // FioTextBox.Text = UserVariableData.selectedUser.Fio;
            // PhoneNumberTextBox.Text = UserVariableData.selectedUser.PhoneNumber;
            // DescriptionTextBox.Text = UserVariableData.selectedUser.Description;
            // ComboBoxRoles.SelectedValue =
            //     App.DbContext.Roles.FirstOrDefault(x => x.IdRole == UserVariableData.selectedUser.IdRole);
            // LoginTextBox.Text = loginInSelectedUser.Login1;
            // PasswordTextBox.Text = loginInSelectedUser.Password;
        }
        else
        {
            UserVariableData.selectedLogin = new Login()
            {
                IdUserNavigation = new User()
            };
        }
        
        DataContext = UserVariableData.selectedLogin;
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

        if (UserVariableData.selectedUser != null)
        {
            Console.WriteLine("Edit user " + UserVariableData.selectedUser.IdUser);

            var idUser = UserVariableData.selectedUser.IdUser;
            var selectedUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);
            var selectedRole = ComboBoxRoles.SelectedItem as Role;
            selectedUser.IdRoleNavigation = selectedRole;
            var selectedLogin =
                App.DbContext.Logins.FirstOrDefault(x =>
                    x.IdUser == UserVariableData.selectedUser.IdUser);

            var userChange = DataContext as User;
            selectedUser = userChange;

            // if (selectedUser == null) return;
            //
            // selectedUser.Fio = FioTextBox.Text;
            // selectedUser.PhoneNumber = PhoneNumberTextBox.Text;
            // selectedUser.Description = DescriptionTextBox.Text;
            //
            // selectedLogin.Login1 = LoginTextBox.Text;
            // selectedLogin.Password = PasswordTextBox.Text;
            //
            // var selectedRole = ComboBoxRoles.SelectedValue as Role;
            // selectedUser.IdRole = selectedRole.IdRole;
        }
        else
        {
            Console.WriteLine("Create new user");

            var selectedRole = ComboBoxRoles.SelectedValue as Role;

            var login = DataContext as Login;
            if (login == null) return;

            var user = login.IdUserNavigation;
            user.IdRoleNavigation = selectedRole;
            if (user == null) return;

            App.DbContext.Add(login);
            App.DbContext.Add(user);
            
        }

        App.DbContext.SaveChanges();

        Close();
    }
}