namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();

		BindingContext = new Models.AllNotes();
	}

    protected override async void OnAppearing() 
	{
		base.OnAppearing();
		// call the async loader so file I/O doesn't block the UI
		await ((Models.AllNotes)BindingContext).LoadNotesAsync();
    }

	private async void Add_Clicked(object sender, EventArgs e) 
	{
		await Shell.Current.GoToAsync(nameof(NotePage));
	}

	private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e) 
	{
		if (e.CurrentSelection.Count != 0) 
		{
			var note = (Models.Note)e.CurrentSelection[0];
			await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={Uri.EscapeDataString(note.FileName)}");
		}

		notesCollection.SelectedItem = null;
	}
}