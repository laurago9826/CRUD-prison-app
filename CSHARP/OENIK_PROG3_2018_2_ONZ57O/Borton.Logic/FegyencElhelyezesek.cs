// <copyright file="FegyencElhelyezesek.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Borton.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class is necessary for the return value of a non CRUD method (FegyencElhelyezesek), also to print out the result
    /// </summary>
    public class FegyencElhelyezesek
    {
        /// <summary>
        /// Gets or sets the name of the convict
        /// </summary>
        public string Nev { get; set; }

        /// <summary>
        /// Gets or sets on which floor the convict lives
        /// </summary>
        public int Emelet { get; set; }

        /// <summary>
        /// Gets or sets on which section is the cell
        /// </summary>
        public string Reszleg { get; set; }

        /// <summary>
        /// Gets or sets in which cell the convict lives
        /// </summary>
        public int Cellaszam { get; set; }
    }
}
