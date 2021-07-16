// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Borton.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Borton.Data;

    /// <summary>
    /// The Repository classes implement it
    /// </summary>
    /// <typeparam name="T">Az entity típusára vonatkozó generikus típus</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Inserts the T object to the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="obj">beszúrandó objektum</param>
        void Insert(BortonEntities entity, T obj);

        /// <summary>
        /// Modifies the value of a T object
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="filteringValue">the value, by which we filter the propertyNameForFiltering property</param>
        /// <param name="modifiedValue">the value, to which we want to modify the propertyNameForModifying property</param>
        /// <param name="propertyNameForFiltering">a property by which we filter</param>
        /// <param name="propertyNameForModifying">a property whose value has to be changed</param>
        void Update(BortonEntities entity, object filteringValue, object modifiedValue, string propertyNameForFiltering, string propertyNameForModifying);

        /// <summary>
        /// Deletes an instance with the "azonositok" primary key
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="azonositok">one or more primary keys</param>
        void Delete(BortonEntities entity, params int[] azonositok);

        /// <summary>
        /// Returns the instances of T objects in an entity
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <returns>Returns the instances</returns>
        IQueryable<T> Listing(BortonEntities entity);
    }
}
