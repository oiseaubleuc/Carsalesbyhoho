using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using Carsalesbyhoho.Views;

namespace Carsalesbyhoho
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserControl huidigeView;

        private readonly bool _isAdmin;

        public MainViewModel(bool isAdmin)
        {
            _isAdmin = isAdmin;
            HuidigeView = new HomeView();
        }

        [RelayCommand]
        public void NavigeerNaarHome() => HuidigeView = new HomeView();

        [RelayCommand]
        public void NavigeerNaarCarView()
        {
            if (_isAdmin)
                HuidigeView = new CarView();
        }

        [RelayCommand]
        public void NavigeerNaarBrandView()
        {
            if (_isAdmin)
                HuidigeView = new BrandView();
        }

        [RelayCommand]
        public void NavigeerNaarVisitor() => HuidigeView = new VisitorView();
    }
}
