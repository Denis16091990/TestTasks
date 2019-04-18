namespace Task3.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T> : IDisposable
    where T : class
    {
        /// <summary>
        ///     Create item
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        ///     Delete Item
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        ///     Get ofject by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        ///     Get all objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Save changes
        /// </summary>
        void Save();

        // Update Item
        void Update(T item);
    }
}