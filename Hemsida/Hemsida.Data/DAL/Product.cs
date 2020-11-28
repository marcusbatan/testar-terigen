//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hemsida.Data.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public System.Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnail { get; set; }
        public Nullable<bool> IsPreferredDrink { get; set; }
        public int InStock { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Product Product1 { get; set; }
        public virtual Product Product2 { get; set; }
    }
}