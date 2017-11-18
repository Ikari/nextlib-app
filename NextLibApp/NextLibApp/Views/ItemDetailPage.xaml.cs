using Xamarin.Forms;

namespace NextLibApp
{
    public partial class ItemDetailPage : ContentPage
    {
        BookDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Book
            {
                Title = "Book 1",
                Description = "This is an book description."
            };

            viewModel = new BookDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(BookDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
