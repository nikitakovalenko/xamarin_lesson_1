using System.ComponentModel;
using Xamarin.Forms;

namespace TestApplication.ViewModels
{
    public class DetailsPageViewModel : INotifyPropertyChanged
    {
        private string _note;

        public DetailsPageViewModel()
        {
            DismissCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                var args = new PropertyChangedEventArgs(nameof(Note));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command DismissCommand { get; set; }
    }
}
