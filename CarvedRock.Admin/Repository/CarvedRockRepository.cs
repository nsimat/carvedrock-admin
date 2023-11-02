using CarvedRock.Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Admin.Repository;

public class CarvedRockRepository : ICarvedRockRepository
{
    private readonly ProductDbContext _productDbContext;
    public CarvedRockRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }
    public async Task<Product> AddProductAsync(Product product)
    {
        _productDbContext.Products.Add(product);
        await _productDbContext.SaveChangesAsync();
        return product; // will have an updated ID value?
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productDbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _productDbContext.Products.FirstOrDefaultAsync( p => p.Id == productId);
    }

    public async Task RemoveProductAsync(int productIdToRemove)
    {
        if(productIdToRemove == 3)
        {
            throw new Exception("Simulated exception trying to remove product!");
        }

        var product = await _productDbContext.Products.FirstOrDefaultAsync(p => p.Id == productIdToRemove);
        if(product != null)
        {
            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateProductAsync(Product product)
    {
        try
        {
            _productDbContext.Update(product);
            await _productDbContext.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException e)
        {
            if(_productDbContext.Products.Any(p => p.Id == product.Id))
            {
                // product exists and update exception is real
                throw;
            }
            // caught and swallowed exception can occur if 
            // the other update was a delete operation
        }
    }
}