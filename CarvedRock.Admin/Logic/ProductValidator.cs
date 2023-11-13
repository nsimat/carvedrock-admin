using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarvedRock.Admin.Models;
using CarvedRock.Admin.Repository;
using FluentValidation;

namespace CarvedRock.Admin.Logic
{
    public class ProductValidator: AbstractValidator<ProductModel>
    {
        public ProductValidator(ICarvedRockRepository repository)
        {
            RuleFor(p => p).MustAsync(async (productModel, cancellation) => 
            {
                if(productModel.CategoryId == 0) return true;
                var category = await repository.GetCategoryByIdAsync(productModel.CategoryId);
                if(category?.Name != "Footwear") return true;

                return productModel.Price <= 200.00M;// A price greater than 200.00M is a problem.
            }).WithMessage("Price cannot be more than 200.00 for footwear category.");
        }
    }
}