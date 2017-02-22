namespace GeneralFrame.Core
{
    /// <summary>
    /// Interface for any DbContextUnitOfWork
    /// </summary>
    /// <seealso cref="IUnitOfWork" />
    public interface IDbContextUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Add entity to dataset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Add<T>(T entity) where T : class;

        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <returns>System.String[].</returns>
        string[] GetAllData();

        //TODO: Add other needed implementation
    }
}
