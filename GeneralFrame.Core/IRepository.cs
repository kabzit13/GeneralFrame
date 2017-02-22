namespace GeneralFrame.Core
{
    /// <summary>
    /// Base interface for storing entities of same type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>IUnitOfWork.</returns>
        IUnitOfWork GetUnitOfWork();

        // Marks an entity as new
        void Add(T entity);

        //TODO: Impelement all CRUD operations.
    }
}
