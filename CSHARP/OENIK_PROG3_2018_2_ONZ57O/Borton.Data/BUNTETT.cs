//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Borton.Data
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// auto-generated
    /// </summary>
    public partial class BUNTETT
    {
        /// <summary>
        /// auto-generated
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BUNTETT()
        {
            this.ITELET = new HashSet<ITELET>();
        }

        /// <summary>
        /// auto-generated
        /// </summary>
        public decimal buntett_ID { get; set; }

        /// <summary>
        /// auto-generated
        /// </summary>
        public string letartoztato_szemely { get; set; }

        /// <summary>
        /// auto-generated
        /// </summary>
        public string buntett_leiras { get; set; }

        /// <summary>
        /// auto-generated
        /// </summary>
        public string aldozat { get; set; }

        /// <summary>
        /// auto-generated
        /// </summary>
        public string elkovetes_helye { get; set; }

        /// <summary>
        /// auto-generated
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITELET> ITELET { get; set; }
    }
}
