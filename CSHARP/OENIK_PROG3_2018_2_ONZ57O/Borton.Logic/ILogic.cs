// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Borton.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Borton.Data;
    using Borton.Repository;

    /// <summary>
    /// The interface of the Logic class
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the FEGYENC entity
        /// </summary>
        IRepository<FEGYENC> Fegyenc { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the BORTONOR entity
        /// </summary>
        IRepository<BORTONOR> Bortonor { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the BUNTETT entity
        /// </summary>
        IRepository<BUNTETT> Buntett { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the ITELET entity
        /// </summary>
        IRepository<ITELET> Itelet { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the ELHELYEZES entity
        /// </summary>
        IRepository<ELHELYEZES> Elhelyezes { get; set; }

        /// <summary>
        /// Listing the data of the table
        /// </summary>
        /// <param name="melyiktabla">The identifier of the table</param>
        /// <returns>List of the entities of the table in a string </returns>
        string Listing(int melyiktabla);

        /// <summary>
        /// Adding a new entity
        /// </summary>
        /// <param name="melyiktabla">The identifier of the table</param>
        /// <param name="values">the values we want to insert</param>
        void Insert(int melyiktabla, string[] values);

        /// <summary>
        /// Updating an entity
        /// </summary>
        /// <param name="melyiktabla">The identifier of the table</param>
        /// <param name="filteringValue">the value by which we want to filter</param>
        /// <param name="modifiedValue">the value to which we want to modify the current one</param>
        /// <param name="propertyNameForModifying">the property we want to modify</param>
        /// <param name="propertyNameForFiltering">the property by which we filter</param>
        void Update(int melyiktabla, object filteringValue, object modifiedValue, string propertyNameForModifying, string propertyNameForFiltering);

        /// <summary>
        /// Deleting an entity
        /// </summary>
        /// <param name="melyiktabla">he identifier of the table</param>
        /// <param name="azonosito">the identifier(s) of the instance we want to remove</param>
        void Delete(int melyiktabla, params string[] azonosito);

        /// <summary>
        /// Handles the response of the Java part of the project
        /// </summary>
        /// <param name="letoltendo_ido">The jailtime of the convict which is passed to another method</param>
        /// <param name="fegyencnev">The name of the convict which is passed to another method</param>
        /// <param name="fegyenc_id">The identifier of the convict which is passed to another method</param>
        /// <returns>Returns the result as string</returns>
        string Java(string letoltendo_ido, string fegyencnev, string fegyenc_id);

        /// <summary>
        /// One of the non-CRUD methods, returns which convict committed which crime and how many years of jailtime it got.
        /// </summary>
        /// <param name="entity">BortonEntities instance for the Listing operation</param>
        /// <returns>returns the result as IEnumerable</returns>
        IEnumerable<BuntettekEsFegyencek> BuntettekEsFegyencekListazasa(BortonEntities entity);

        /// <summary>
        /// One of the non-CRUD methods, returns which convict lives in which cell, on which floor and on which section.
        /// </summary>
        /// <param name="entity">BortonEntities instance for the Listing operation</param>
        /// <returns>returns the result as IEnumerable</returns>
        IEnumerable<FegyencElhelyezesek> FegyencEsElhelyezesListazas(BortonEntities entity);

        /// <summary>
        /// One of the non-CRUD methods, returns what kind of crimes have the convicts committed, the average jailtime and the number of convicts in for the crime.
        /// </summary>
        /// <param name="entity">BortonEntities instance for the Listing operation</param>
        /// <returns>returns the result as IEnumerable</returns>
        IEnumerable<Buntettek> HanyfeleBuntettListazas(BortonEntities entity);
    }
}
