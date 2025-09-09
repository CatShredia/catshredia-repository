using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;

namespace TheFirstExampleProject.Views;

public partial class UserEditWindow : Window
{
    public UserEditWindow()
    {
        InitializeComponent();
        
        DataContext = new UserWindowViewModel();

        if (UserVariableData.selectedUserInMainWindow != null)
        {
            FirstNameTextBox.Text = UserVariableData.selectedUserInMainWindow.FirstName;
            SecondNameTextBox.Text = UserVariableData.selectedUserInMainWindow.SecondName;
        }
    }

    private void Create_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (UserVariableData.selectedUserInMainWindow != null)
        {
            Console.WriteLine("Edit user "  + UserVariableData.selectedUserInMainWindow.IdUser);
            
            var idUser = UserVariableData.selectedUserInMainWindow.IdUser;
            var selectedUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

            if (selectedUser == null) return;

            selectedUser.FirstName = FirstNameTextBox.Text;
            selectedUser.SecondName = SecondNameTextBox.Text;
        }
        else
        {
            Console.WriteLine("Create new user");
            
            var newUser = new User()
            {
                FirstName = FirstNameTextBox.Text,
                SecondName = SecondNameTextBox.Text,
            };
            App.DbContext.Users.Add(newUser);
        }
        App.DbContext.SaveChanges();
        Close();
    }
}