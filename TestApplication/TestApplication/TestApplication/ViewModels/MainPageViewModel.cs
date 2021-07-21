using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace TestApplication.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _note;
        
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();
            
            EraseCommand = new Command(() =>
            {
                Note = string.Empty;
            });

            SaveCommand = new Command(() =>
            {
                if (string.IsNullOrWhiteSpace(Note))
                    return;
                AllNotes.Add(Note);
                Note = string.Empty;
            });

            SelectedNoteChangedCommand = new Command(async () => {
                var detailsVM = new DetailsPageViewModel()
                {
                    Note = SelectedNote
                };
                var detailsPage = new DetailsPage();

                detailsPage.BindingContext = detailsVM;

                await Application.Current.MainPage.Navigation.PushAsync(detailsPage);
            });
        }

        public ObservableCollection<string> AllNotes { get; set; }
        
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

        public string SelectedNote { get; set; }    

        public Command SaveCommand { get; set; }
        public Command EraseCommand { get; set; }
        public Command SelectedNoteChangedCommand { get; set; }
    }
}
