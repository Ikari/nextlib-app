using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextLibApp
{
	public interface IDataStore<T>
	{
		Task<bool> AddBookAsync(T book);
		Task<bool> UpdateBookAsync(T book);
        Task<bool> DeleteBookAsync(string id);
		Task<T> GetBookAsync(string id);
		Task<IEnumerable<T>> GetBooksAsync(bool forceRefresh = false);
	}
}
