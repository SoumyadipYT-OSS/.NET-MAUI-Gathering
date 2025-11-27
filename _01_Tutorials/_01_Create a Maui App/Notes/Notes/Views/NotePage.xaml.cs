using System;

namespace Notes.Views;


[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
	public NotePage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appDataPath, randomFileName));
	}

	public string ItemId 
	{
		set { LoadNote(value); }
	}


	private async void SaveButton_Clicked(object sender, EventArgs e) 
	{
		if (BindingContext is Models.Note note)
		{
			try
			{
				// ensure the editor text is persisted and model updated
				File.WriteAllText(note.FileName, TextEditor.Text ?? string.Empty);

				// update the model's Date to reflect save time
				note.Date = File.GetLastWriteTime(note.FileName);
			}
			catch (Exception ex)
			{
				// use Shell.Current.DisplayAlert in Shell apps instead of the Page-level DisplayAlert
				await Shell.Current.DisplayAlertAsync("Save failed", $"Unable to save note: {ex.Message}", "OK");
				return;
			}
		}

		await Shell.Current.GoToAsync("..");
	}

	private async void DeleteButton_Clicked(object sender, EventArgs e) 
	{
		if (BindingContext is Models.Note note) 
		{
			try
			{
				if (File.Exists(note.FileName))
					File.Delete(note.FileName);
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlertAsync("Delete failed", $"Unable to delete note: {ex.Message}", "OK");
				return;
			}
		}

		await Shell.Current.GoToAsync("..");
	}

	private void LoadNote(string fileName) 
	{
		Models.Note noteModel = new Models.Note
		{
			FileName = fileName
		};

		if (File.Exists(fileName)) 
		{
			// prefer last-write time for "last edited"
			noteModel.Date = File.GetLastWriteTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;
	}
}
