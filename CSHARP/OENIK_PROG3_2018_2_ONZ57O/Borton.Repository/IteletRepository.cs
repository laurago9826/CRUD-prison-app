// <copyright file="IteletRepository.cs" company="PlaceholderCompany">
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
    /// operation ITELET type intances
    /// </summary>
    public class IteletRepository : IRepository<ITELET>
    {
        /// <summary>
        /// Deletes the instance of the proper key from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="azonositok">one element itelet_ID identifier</param>
        public void Delete(BortonEntities entity, params int[] azonositok)
        {
            int szam = azonositok[0];
            ITELET torlendo = entity.ITELET.SingleOrDefault(x => x.itelet_ID == szam);
            if (torlendo == null)
            {
                throw new InvalidFilterCriteriaException();
            }

            entity.ITELET.Remove(torlendo);
            entity.SaveChanges();
        }

        /// <summary>
        /// Inserts an ITELET instance to the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="row">insert instance</param>
        public void Insert(BortonEntities entity, ITELET row)
        {
            entity.ITELET.Add(row as ITELET);
            entity.SaveChanges();
        }

        /// <summary>
        /// Returns the instances of ITELET from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <returns>result as IQueryable</returns>
        public IQueryable<ITELET> Listing(BortonEntities entity)
        {
            return entity.ITELET;
        }

        /// <summary>
        /// Executes the updating of the entity model on the ITELET table
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="filteringValue">value, by which we want to filter</param>
        /// <param name="modifiedValue">the new modified value for the propertyNameForModifying property</param>
        /// <param name="propertyNameForFiltering">property, by which we want to filter</param>
        /// <param name="propertyNameForModifying">preoperty, which we want to modify</param>
        public void Update(BortonEntities entity, object filteringValue, object modifiedValue, string propertyNameForFiltering, string propertyNameForModifying)
        {
            foreach (var i in entity.ITELET)
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
