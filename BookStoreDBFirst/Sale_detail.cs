//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStoreDBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale_detail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> Book_id { get; set; }
        public decimal Total_price { get; set; }
        public Nullable<int> Sale_id { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
