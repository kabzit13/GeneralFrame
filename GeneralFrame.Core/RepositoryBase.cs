namespace GeneralFrame.Core
{
    /// <summary>
    /// Class RepositoryBase.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The database context unit of work
        /// </summary>
        private readonly IDbContextUnitOfWork dbContextUnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="dbContextUnitOfWork">The database context unit of work.</param>
        protected RepositoryBase(IDbContextUnitOfWork dbContextUnitOfWork)
        {
            this.dbContextUnitOfWork = dbContextUnitOfWork;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>IUnitOfWork.</returns>
        public IUnitOfWork GetUnitOfWork()
        {
            return this.dbContextUnitOfWork;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(T entity)
        {
            this.dbContextUnitOfWork.Add(entity);
        }

        public virtual string[] GetAllItems()
        {
            return this.dbContextUnitOfWork.GetAllData();
        }

        //TODO: Implement other CRUD operations
    }
}
