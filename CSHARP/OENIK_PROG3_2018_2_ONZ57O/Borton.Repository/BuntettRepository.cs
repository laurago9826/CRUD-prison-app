// <copyright file="BuntettRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Borton.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Borton.Data;

    /// <summary>
    /// operation BUNTETT type intances
    /// </summary>
    public class BuntettRepository : IRepository<BUNTETT>
    {
        /// <summary>
        /// Deletes the instance of the proper key from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="azonositok">one element buntett_ID identifier</param>
        public void Delete(BortonEntities entity, params int[] azonositok)
        {
            int szam = azonositok[0];
            BUNTETT torlendo = entity.BUNTETT.SingleOrDefault(x => x.buntett_ID == szam);
            if (torlendo == null)
            {
                throw new InvalidFilterCriteriaException();
            }

            entity.BUNTETT.Remove(torlendo);
            entity.SaveChanges();
        }

        /// <summary>
        /// Inserts an BUNTETT instance to the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="row">insert instance</param>
        public void Insert(BortonEntities entity, BUNTETT row)
        {
            entity.BUNTETT.Add(row as BUNTETT);
            entity.SaveChanges();
        }

        /// <summary>
        /// Returns the instances of BUNTETT from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <returns>result as IQueryable</returns>
        public IQueryable<BUNTETT> Listing(BortonEntities entity)
        {
            return entity.BUNTETT;
        }

        /// <summary>
        /// Entity módosítását végzi egy BUNTETT típusú példányon
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="filteringValue">érték, ami alapján szűrni szeretnénk a propertyNameForFiltering értékei között</param>
        /// <param name="modifiedValue">érték, amire módosítani szeretnénk a propertyNameForModifying értékét</param>
        /// <param name="propertyNameForFiltering">tulajdonság, ami alapján szűrünk</param>
        /// <param name="propertyNameForModifying">tulajdonság, amit módosítunk</param>
        public void Update(BortonEntities entity, object filteringValue, object modifiedValue, string propertyNameForFiltering, string propertyNameForModifying)
        {
            foreach (var i in entity.BUNTETT)
            {
                var x = i.GetType().GetProperty(propertyNameForFiltering);
                if (x.GetValue(i).ToString().Equals(filteringValue.ToString()))
                {
                    var y = i.GetType().GetProperty(propertyNameForModifying);
                    Type t = Nullable.GetUnderlyingType(y.PropertyType) ?? y.PropertyType;

                    object safeValue = (i == null) ? null : Convert.ChangeType(modifiedValue, t);

                    y.SetValue(i, safeValue, null);
                }
            }

            entity.SaveChanges();
        }
    }
}
