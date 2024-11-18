using System.Collections.ObjectModel;

namespace Gorosel_Odevi;

public partial class Tasks: ContentPage
{
    private ObservableCollection<string> notes;
    private const string NotesFileName = "notes.json";

    public Tasks()
    {
        InitializeComponent();
        notes = LoadNotes();
        notesListView.ItemsSource = notes;
    }

    private void OnAddNoteClicked(object sender, EventArgs e)
    {
        string newNote = noteEntry.Text;
        if (!string.IsNullOrEmpty(newNote))
        {
            notes.Add(newNote);
            noteEntry.Text = string.Empty;
            SaveNotes();
            DisplayAlert("Note Added", $"You added the note: {newNote}", "OK");
        }
        else
        {
            DisplayAlert("Error", "Please enter a note.", "OK");
        }
    }

    private void OnEditNoteClicked(object sender, EventArgs e)
    {
        // Handle edit button click
        // You can open a new page for editing the selected note or implement your custom logic
    }

    private async void OnDeleteNoteClicked(object sender, EventArgs e)
    {
        bool deleteConfirmation = await DisplayAlert("Delete Note", "Are you sure you want to delete this note?", "Yes", "No");

        if (deleteConfirmation)
        {
            // Implement your delete logic here
            SaveNotes();
        }
    }

    private void OnDeleteNotesClicked(object sender, EventArgs e)
    {
        notes.Clear();
        SaveNotes();
    }

    private void SaveNotes()
    {
        string json = JsonSerializer.Serialize(notes);
        File.WriteAllText(secrets, json);
    }

    private ObservableCollection<string> LoadNotes()
    {
        try
        {
            if (File.Exists(NotesFileName))
            {
                string json = File.ReadAllText(NotesFileName);
                return JsonSerializer.Deserialize<ObservableCollection<string>>(json);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            DisplayAlert("Error", $"Error loading notes: {ex.Message}", "OK");
        }

        return new ObservableCollection<string>();
    }
}

}