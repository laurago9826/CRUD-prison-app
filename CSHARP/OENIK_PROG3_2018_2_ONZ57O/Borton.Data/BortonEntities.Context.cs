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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    /// <summary>
    /// 
    /// </summary>
    public partial class BortonEntities : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public BortonEntities()
            : base("name=BortonEntities")
        {
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<BORTONOR> BORTONOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<BUNTETT> BUNTETT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<ELHELYEZES> ELHELYEZES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<FEGYENC> FEGYENC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<ITELET> ITELET { get; set; }
    }
}
