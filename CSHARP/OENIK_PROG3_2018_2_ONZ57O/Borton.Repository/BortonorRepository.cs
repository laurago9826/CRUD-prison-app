// <copyright file="BortonorRepository.cs" company="PlaceholderCompany">
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
    public class BortonorRepository : IRepository<BORTONOR>
    {
        /// <summary>
        /// Deletes the instance of the proper key from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="azonositok">one element bortonor_ID identifier</param>
        public void Delete(BortonEntities entity, params int[] azonositok)
        {
            int szam = azonositok[0];
            BORTONOR torlendo = entity.BORTONOR.SingleOrDefault(x => x.bortonor_ID == szam);
            if (torlendo == null)
            {
                throw new InvalidFilterCriteriaException();
            }

            entity.BORTONOR.Remove(torlendo);
            entity.SaveChanges();
        }

        /// <summary>
        /// Inserts an BUNTETT instance to the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="row">insert instance</param>
        public void Insert(BortonEntities entity, BORTONOR row)
        {
            entity.BORTONOR.Add(row as BORTONOR);
            entity.SaveChanges();
        }

        /// <summary>
        /// Returns the instances of BUNTETT from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <returns>result as IQueryable</returns>
        public IQueryable<BORTONOR> Listing(BortonEntities entity)
        {
            return entity.BORTONOR;
        }

        /// <summary>
        /// Executes the updating of the entity model on the BORTONOR table
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="filteringValue">value, by which we want to filter</param>
        /// <param name="modifiedValue">the new modified value for the propertyNameForModifying property</param>
        /// <param name="propertyNameForFiltering">property, by which we want to filter</param>
        /// <param name="propertyNameForModifying">preoperty, which we want to modify</param>
        public void Update(BortonEntities entity, object filteringValue, object modifiedValue, string propertyNameForFiltering, string propertyNameForModifying)
        {
            foreach (var i in entity.BORTONOR)
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
