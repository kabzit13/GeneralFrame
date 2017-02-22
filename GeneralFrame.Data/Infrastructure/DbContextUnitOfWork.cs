using System;
using System.Collections.Generic;
using System.IO;
using GeneralFrame.Core;

namespace GeneralFrame.Data.Infrastructure
{
    /// <summary>
    /// Class DbContextUnitOfWork.
    /// </summary>
    /// <seealso cref="IDbContextUnitOfWork" />
    public abstract class DbContextUnitOfWork: IDbContextUnitOfWork
    {
        /// <summary>
        /// The file path
        /// </summary>
        readonly string filePath;

        /// <summary>
        /// The data set
        /// </summary>
        List<string> dataSet = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextUnitOfWork"/> class.
        /// </summary>
        protected DbContextUnitOfWork()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextUnitOfWork"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="System.ArgumentException">Such pass is not exists - filePath</exception>
        public DbContextUnitOfWork(string filePath)
        {
            if(!this.IsPathExist(filePath))
                throw new ArgumentException("Such pass is not exists", nameof(filePath));

            this.filePath = filePath;
        }

        /// <summary>
        /// Commit all changes made in a container.
        /// </summary>
        public void Commit()
        {
            //TODO: Implement locking the directory

            using (var writer = File.AppendText(this.filePath))
            {
                foreach (var line in this.dataSet)
                {
                    writer.WriteLine(line);
                }
            }
            this.dataSet = new List<string>();
        }

        /// <summary>
        /// Add entity to dataset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<T>(T entity) where T : class
        {
            this.dataSet.Add(entity.ToString());
        }

        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <returns>System.String[].</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string[] GetAllData()
        {
            if (!File.Exists(this.filePath))
            {
                throw new Exception("File DB not exists");
            }

            return File.ReadAllLines(this.filePath);
        }
        /// <summary>
        /// Determines whether [is path exist] [the specified file path].
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns><c>true</c> if [is path exist] [the specified file path]; otherwise, <c>false</c>.</returns>
        private bool IsPathExist(string filePath)
        {
            return !string.IsNullOrEmpty(filePath) && Directory.Exists(Path.GetPathRoot(filePath));
        }

       
    }
}
