namespace GeneralFrame.Core
{
    /// <summary>
    /// Interface for unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commit all changes made in a container.
        /// </summary>
        void Commit();
    }
}
