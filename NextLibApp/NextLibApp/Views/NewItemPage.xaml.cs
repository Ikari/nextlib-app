using System;

using Xamarin.Forms;

namespace NextLibApp
{
    public partial class NewItemPage : ContentPage
    {
        public Book Book { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Book = new Book
            {
                Title = "Título do novo livro",
                Description = "Breve descrição do livro."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Book);
            await Navigation.PopToRootAsync();
        }
    }
}
