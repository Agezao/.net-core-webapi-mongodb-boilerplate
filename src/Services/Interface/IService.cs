using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Services.Interface
{
    public interface IService<T>
    {
        /// <summary>
        /// Save the received entity
        /// </summary>
        /// <param name="model">The model to be saved</param>
        /// <returns>Saved entity</returns>
        T Create(T model);

        /// <summary>
        /// Delete received Id
        /// </summary>
        /// <param name="id">The Id to be deleted</param>
        /// <returns>Affected rows</returns>
        int Delete(ObjectId id);

        /// <summary>
        /// Find entity by Id
        /// </summary>
        /// <param name="id">Id of the item</param>
        /// <returns>Found entity</returns>
        T Find(ObjectId id);

        /// <summary>
        /// List all entities
        /// </summary>
        /// <returns>Found entities</returns>
        List<T> ListAll();
    }
}