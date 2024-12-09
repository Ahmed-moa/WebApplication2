using WebApplication2.BL.Interface;
using WebApplication2.DAL.Database;
using WebApplication2.DAL.Entities;
using WebApplication2.Models;

namespace WebApplication2.BL.Repository
{
    public class ProductRep : IProductRep
    {
        private readonly Dbcontainer _db;

        public ProductRep(Dbcontainer db)
        {
            _db = db;
        }

      

        public IQueryable<ProductVM> Get()
        {
            var data = _db.Products.Select(p => new ProductVM
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductCode = p.ProductCode,
                Price = p.Price
            });

            return data;
        }

        public void Add(ProductVM Pdt)
        {

            //mapping
            Products P = new Products();
            P.ProductName = Pdt.ProductName;
            P.ProductCode = Pdt.ProductCode;
            P.Price = Pdt.Price;


            _db.Products.Add(P);
            _db.SaveChanges();
        }

        public ProductVM GetById(int id)
        {
            var data = _db.Products.Where(p => p.Id == id)
        .Select(p => new ProductVM { Id = p.Id, ProductName = p.ProductName, ProductCode = p.ProductCode, Price = p.Price }).FirstOrDefault();

            return data;
        }

        public void Edit(ProductVM Pdt)
        {
            var OldData = _db.Products.Find(Pdt.Id);

            OldData.ProductName = Pdt.ProductName;
            OldData.ProductCode = Pdt.ProductCode;
            OldData.Price = Pdt.Price;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var DeletedObject = _db.Products.Find(id);
            _db.Products.Remove(DeletedObject);
            _db.SaveChanges();
        }
    }
}
