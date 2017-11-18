using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextLibApp
{
	public interface IDataStore<T>
	{
		Task<int> SaveBookAsync(T book);
        Task<int> DeleteBookAsync(int id);
		Task<T> GetBookAsync(int id);
		Task<List<T>> GetBooksAsync();
	}
}
