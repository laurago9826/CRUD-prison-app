// <copyright file="Buntettek.cs" company="PlaceholderCompany">
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
    /// The class is necessary for the return value of a non CRUD method (HanyfeleBuntettListazas), also to print out the result
    /// </summary>
    public class Buntettek
    {
        /// <summary>
        /// Gets or sets the category of the crime
        /// </summary>
        public string BuntettLeiras { get; set; }

        /// <summary>
        /// Gets or sets the average jail time
        /// </summary>
        public double AtlagosLetoltendoIdo { get; set; }

        /// <summary>
        /// Gets or sets how many convicts sit in jail for the comitted crime
        /// </summary>
        public int FegyencekSzama { get; set; }
    }
}
