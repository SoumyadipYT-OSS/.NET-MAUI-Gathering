
using System.Collections.ObjectModel;


namespace Notes.Models;

internal class AllNotes 
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

    public AllNotes()
    {
        // do not block the constructor; caller (page) will call LoadNotesAsync in OnAppearing
        // Keep constructor lightweight
    }

    public async Task LoadNotesAsync()
    {
        try
        {
            // perform disk I/O off the UI thread
            string appDataPath = FileSystem.AppDataDirectory;

            var notesList = await Task.Run(() =>
            {
                if (!Directory.Exists(appDataPath))
                    return Array.Empty<Note>();

                return Directory
                    .EnumerateFiles(appDataPath, "*.notes.txt")
                    .Select(filename =>
                    {
                        // perform individual file reads on worker thread
                        string text = string.Empty;
                        DateTime date = DateTime.MinValue;

                        try
                        {
                            text = File.Exists(filename) ? File.ReadAllText(filename) : string.Empty;
                            date = File.Exists(filename) ? File.GetLastWriteTime(filename) : DateTime.MinValue;
                        }
                        catch
                        {
                            // swallow per-file exceptions to avoid breaking the whole load
                        }

                        return new Note
                        {
                            FileName = filename,
                            Text = text,
                            Date = date
                        };
                    })
                    // newest first
                    .OrderByDescending(note => note.Date)
                    .ToArray();
            });

            // update the ObservableCollection on the main thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Notes.Clear();
                foreach (var n in notesList)
                    Notes.Add(n);
            });
        }
        catch (Exception)
        {
            // Top-level: avoid crashing the UI. Optionally log.
        }
    }
}