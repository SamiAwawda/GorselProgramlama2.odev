using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.Threading.Tasks;

namespace Gorosel_Odevi
{


    public partial class Task : ContentPage
    {
        //private const string NotesFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/secrets.json";
        string dataFile = Path.Combine(FileSystem.Current.AppDataDirectory, "kisilerData.json");
        public ObservableCollection<string> Notes { get; set; } = new ObservableCollection<string>();
        public string CurrentNote { get; set; }

        public Task()
        {
            InitializeComponent();
            LoadNotes();

            NoteListView.ItemsSource = Notes;
        }
        private async void TakeNote(object sender, EventArgs e)
        {
            var result = await DisplayPromptAsync("Take a Note", "Enter your note:");

            if (!string.IsNullOrWhiteSpace(result))
            {
                Notes.Add(result);
                SaveNotes();
                NoteListView.ItemsSource = null;
                NoteListView.ItemsSource = Notes;
            }
        }





        private async void DeleteNote(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var note = button?.BindingContext as string;
            bool answer = await DisplayAlert("Silmeyi Onayla", $"{note} silinsin mi", "Evet", "Hayır");

            if (answer)
            {

                if (!string.IsNullOrWhiteSpace(note))
                {
                    Notes.Remove(note);
                    SaveNotes();
                    NoteListView.ItemsSource = null;
                    NoteListView.ItemsSource = Notes;
                }
            }
        }
        private async void EditNote(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var note = button?.BindingContext as string;
         

          /*  TaskDetils page = new TaskDetils(note);
             {
                 //Title = "Kişi Ekle",
              //   AddMethod = AddKisi

             };*/

           // await Navigation.PushModalAsync(page, true);

        }

            private void SaveNotes()
            {
                var notesJson = JsonSerializer.Serialize(Notes);
                File.WriteAllText(dataFile, notesJson);
            }

            private void LoadNotes()
            {
                if (File.Exists(dataFile))
                {
                    var notesJson = File.ReadAllText(dataFile);
                    Notes = JsonSerializer.Deserialize<ObservableCollection<string>>(notesJson);
                }
            }
        }
    public class Tasks : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private string id, not;
        public string ID
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value; }
        }
        public string Not
        {
            get => not;
            set
            {
                not = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("nott");
            }
        }
    }
    }
    

        
