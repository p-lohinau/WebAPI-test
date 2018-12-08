namespace TestApp.Models.Interface
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IUnitOfWork" />
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The SaveChangesAsync
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        Task SaveChangesAsync();

        /// <summary>
        /// The Dispose
        /// </summary>
        void Dispose();
    }
}
