namespace GeneralFrame.Data.Infrastructure
{
    public class MainUnitOfWork : DbContextUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainUnitOfWork"/> class.
        /// </summary>
        public MainUnitOfWork()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainUnitOfWork"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public MainUnitOfWork(string filePath) : base(filePath)
        {
        }

        //TODO: Add some additional logic on application init
    }
}
