// <copyright file="ElhelyezesRepository.cs" company="PlaceholderCompany">
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
    /// operation FEGYENC type intances
    /// </summary>
    public class ElhelyezesRepository : IRepository<ELHELYEZES>
    {
        /// <summary>
        /// Deletes the instance of the proper key from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="azonositok">two element cellaszam, agy identifier</param>
        public void Delete(BortonEntities entity, params int[] azonositok)
        {
            int szam1 = azonositok[0];
            int szam2 = azonositok[1];
            ELHELYEZES torlendo = entity.ELHELYEZES.SingleOrDefault(x => x.cellaszam == szam1 && x.agy == szam2);
            if (torlendo == null)
            {
                throw new InvalidFilterCriteriaException();
            }

            entity.ELHELYEZES.Remove(torlendo);
            entity.SaveChanges();
        }

        /// <summary>
        /// Inserts an ELHELYEZES instance to the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="row">insert instance</param>
        public void Insert(BortonEntities entity, ELHELYEZES row)
        {
            entity.ELHELYEZES.Add(row as ELHELYEZES);
            entity.SaveChanges();
        }

        /// <summary>
        /// Returns the instances of ELHELYEZES from the entity model
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <returns>result as IQueryable</returns>
        public IQueryable<ELHELYEZES> Listing(BortonEntities entity)
        {
            return entity.ELHELYEZES;
        }

        /// <summary>
        /// Executes the updating of the entity model on the ELHELYEZES table
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="filteringValue">value, by which we want to filter</param>
        /// <param name="modifiedValue">the new modified value for the propertyNameForModifying property</param>
        /// <param name="propertyNameForFiltering">property, by which we want to filter</param>
        /// <param name="propertyNameForModifying">preoperty, which we want to modify</param>
        public void Update(BortonEntities entity, object filteringValue, object modifiedValue, string propertyNameForFiltering, string propertyNameForModifying)
        {
            foreach (var i in entity.ELHELYEZES)
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