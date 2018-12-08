namespace TestApp.Models.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="T"/></returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="item">The item<see cref="T"/></param>
        void Add(T item);

        /// <summary>
        /// The AddRange
        /// </summary>
        /// <param name="items">The items<see cref="IEnumerable{T}"/></param>
        void AddRange(IEnumerable<T> items);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="item">The item<see cref="T"/></param>
        void Update(T item);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task DeleteAsync(int id);
    }
}
