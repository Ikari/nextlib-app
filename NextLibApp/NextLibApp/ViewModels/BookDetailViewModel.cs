namespace NextLibApp
{
    public class BookDetailViewModel : BaseViewModel
    {
        public Book Item { get; set; }
        public BookDetailViewModel(Book item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
