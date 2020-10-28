using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zapisnik2077
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleNote : ContentPage
    {
        Note OpenedNote;
        public SingleNote(Note Note)
        {
            InitializeComponent();
            OpenedNote = Note;
            Name.Text = Note.Name;
            Text.Text = Note.Text;
            Created.Text =  String.Format("{0:MMMM dd, yyyy}", Note.CreationDate);
            LastUpdate.Text = String.Format("{0:MMMM dd, yyyy}", Note.LastChange);
        }

        async void UpdateNote(object sender, EventArgs e)
        {
            OpenedNote.LastChange = DateTime.Today;
            OpenedNote.Name = Name.Text;
            OpenedNote.Text = Text.Text;
            LastUpdate.Text = String.Format("{0:MMMM dd, yyyy}", OpenedNote.LastChange);
            await App.Database.SaveNoteAsync(OpenedNote);
        }

        async void DeleteNote(object sender, EventArgs e)
        {
            await App.Database.DeleteNoteAsync(OpenedNote);
            await Navigation.PopAsync();
        }
    }
}