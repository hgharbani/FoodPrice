//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurplasCosts
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string SurplasCostTitle { get; set; }
        public long unitPrice { get; set; }
    
        public virtual Food Food { get; set; }
    }
}
