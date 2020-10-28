using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zapisnik2077
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void CreateFakeTable()
        {
            for (int i = 0; i < 20; i++)
            {
                var note = new Note();
                note.Name = "Tobias";
                note.Text = "Burger party";
                note.CreationDate = new DateTime(1979, 07, 28);
                note.LastChange = new DateTime(2020, 07, 28);
                await App.Database.SaveNoteAsync(note);
            }
        }

        async void OpenNote(object sender, EventArgs e)
        {
            Note TmpNote = (Note)listView.SelectedItem;
            await Navigation.PushAsync(new SingleNote(TmpNote));
        }

        async void CreateNewNote(object sender, EventArgs e)
        {
            Note TmpNote = new Note();
            TmpNote.CreationDate = DateTime.Today;
            TmpNote.LastChange = DateTime.Today;
            await App.Database.SaveNoteAsync(TmpNote);
            List<Note> AllNotes = await App.Database.GetNotesAsync();
            await Navigation.PushAsync(
                new SingleNote(AllNotes[AllNotes.Count-1])
                );
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Note> AllNotes = await App.Database.GetNotesAsync();
            AllNotes.Reverse();
            //CreateFakeTable();
            listView.ItemsSource = AllNotes;
            
        }
    }
}
