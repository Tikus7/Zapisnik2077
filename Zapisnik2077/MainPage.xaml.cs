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


        async void CreateNewNote(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SingleNote());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //CreateFakeTable();
            listView.ItemsSource = await App.Database.GetNotesAsync();
            
        }
    }
}
