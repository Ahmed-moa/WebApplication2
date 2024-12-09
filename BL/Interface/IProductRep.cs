using WebApplication2.Models;

namespace WebApplication2.BL.Interface
{
    public interface IProductRep
    {
        IQueryable<ProductVM> Get();
        ProductVM GetById(int id);
        void Add(ProductVM Pdt);
        void Edit(ProductVM Pdt);
        void Delete(int id);
    }
}
