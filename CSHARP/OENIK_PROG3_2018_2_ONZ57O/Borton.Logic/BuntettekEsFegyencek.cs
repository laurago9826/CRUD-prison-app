// <copyright file="BuntettekEsFegyencek.cs" company="PlaceholderCompany">
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
    /// The class is necessary for the return value of a non CRUD method (BuntettekEsFegyencekListazas), also to print out the result
    /// </summary>
    public class BuntettekEsFegyencek
    {
        /// <summary>
        /// Gets or sets the name of the convict
        /// </summary>
        public string Nev { get; set; }

        /// <summary>
        /// Gets or sets how many years of jail time has the convict
        /// </summary>
        public int LetoltendoIdo { get; set; }

        /// <summary>
        /// Gets or sets the crime of the convict
        /// </summary>
        public string BuntettLeiras { get; set; }
    }
}
