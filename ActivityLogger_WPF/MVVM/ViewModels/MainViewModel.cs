using ActivityLogger_WPF.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLogger_WPF.MVVM.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            Messages.Add(new MessageModel
            {
                Username = "Allison",
                UsernameColor = "#455245",
                ImageSource = "",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#455245",
                    ImageSource = "",
                    Message = "Test" + i,
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Username",
                UsernameColor = "#485245",
                ImageSource = "",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
                FirstMessage = true
            });


            for (int i = 0; i < 3; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = "User" + i,
                    ImageSource = "",
                    Messages = Messages
                });
            }
        }
    }
}
