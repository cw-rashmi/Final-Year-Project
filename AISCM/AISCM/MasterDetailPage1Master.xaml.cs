﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AISCM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Master : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage1Master()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage1MenuItem> MenuItems { get; set; }

            public MasterDetailPage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                {
                    new MasterDetailPage1MenuItem { Id = 0, Title = "Home" },
                    new MasterDetailPage1MenuItem { Id = 1, Title = "Your Farm"},
                    new MasterDetailPage1MenuItem { Id = 2, Title = "Water Tank Status" },
                    new MasterDetailPage1MenuItem { Id = 3, Title = "Change Language" },
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Update PH" },
                    new MasterDetailPage1MenuItem { Id = 5, Title = "Schemes" },
                    new MasterDetailPage1MenuItem { Id = 6, Title = "Farm Data"},
                    new MasterDetailPage1MenuItem { Id = 7, Title = "Logout" },
                 
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}