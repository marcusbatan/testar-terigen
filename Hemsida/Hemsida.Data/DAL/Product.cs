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
    using Hemsida.Data.Repos;
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {

        }
        public Product(Guid id)
        {
            var repos = new ProductRepos();
            var theProduct = repos.getProduct(id);
            Name = theProduct.Name;
            ShortDescription = theProduct.ShortDescription;
            LongDescription = theProduct.LongDescription;
            Price = theProduct.Price;
            ProductId = theProduct.ProductId;
            Img = theProduct.Img;
            DateTime = theProduct.DateTime;
            CategoryId = theProduct.CategoryId;
        }
        public System.Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public Nullable<bool> IsPreferredDrink { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
        public byte[] Img { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public List<Category> CategoriesCollection { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product1 { get; set; }
        public virtual Product Product2 { get; set; }
    }
}
