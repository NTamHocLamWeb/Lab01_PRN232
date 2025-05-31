using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
	public class ProductDAO
	{
		public static List<Product> GetProducts()
		{
			var listProducts = new List<Product>();
			try
			{
				using var db = new MyStoreContext();
				listProducts = db.Products.Include(f => f.Category).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return listProducts;
		} 

		public static void SaveProduct(Product product)
		{
			try
			{
				using var db = new MyStoreContext();
				db.Products.Add(product);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static void DeleteProduct(Product product)
		{
			try
			{
				using var db = new MyStoreContext();
				var p1 = db.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
				db.Products.Remove(p1);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static void UpdateProduct(Product product)
		{
			try
			{
				using var db = new MyStoreContext();
				db.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static Product GetProductById(int id) 
		{
			using var db = new MyStoreContext();
			return db.Products.Include(p => p.Category).FirstOrDefault(c => c.ProductId.Equals(id));
		}
	}
}
