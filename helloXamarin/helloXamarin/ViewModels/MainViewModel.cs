using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace helloXamarin.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string textLabel;
        public string TextLabel { get { return textLabel; } set { Set(ref textLabel, value); } }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = default(string))
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }

        public MainViewModel()
        {
        }
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = default(string))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand NavigateFirtsCommand { get { return new RelayCommand(NavigateFirts); } }

        
        private async void NavigateFirts()
        {
            await App.Current.MainPage.Navigation.PushAsync(new FirtsPage());
            
        }
    }
}
