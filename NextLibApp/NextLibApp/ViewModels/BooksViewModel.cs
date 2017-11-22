using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NextLibApp
{
    public class BooksViewModel : BaseViewModel
    {
        public ObservableCollection<Book> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public BooksViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Book>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Book>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Book;
                Items.Add(_item);
                await DataStore.SaveBookAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetBooksAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
