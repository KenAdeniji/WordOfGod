/*
 csc CacheProduct.cs /reference:"D:\Program Files\Microsoft Enterprise Library January 2006\bin\Microsoft.Practices.EnterpriseLibrary.Common.dll" /reference:"D:\Program Files\Microsoft Enterprise Library January 2006\bin\Microsoft.Practices.EnterpriseLibrary.Caching.dll"
*/

using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common;

public class Product
{
 string id;
 string name;
 int price;
 public Product(string id, string name, int price)
 {
  this.id = id;
  this.name = name;
  this.price = price;
 }

 public string ProductID
 {
  get
  {
   return (id);
  }
 }

 public static void Main(string[] argv)
 {
  CacheManager productsCache = CacheFactory.GetCacheManager();

  string id = "ProductOneId";
  string name = "ProductXYName";
  int price = 50;

  Product product = new Product(id, name, price);

  productsCache.Add(product.ProductID, product, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromMinutes(5)));

  // Retrieve the item
  product = (Product) productsCache.GetData(id);

  
 }
}