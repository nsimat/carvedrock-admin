using CarvedRock.Admin.Logic;
using CarvedRock.Admin.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Admin.Controllers;

[Authorize]
public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductLogic _logic;

    public ProductsController(IProductLogic logic, ILogger<ProductsController> logger)
    {
        _logic = logic;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _logic.GetAllProducts();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _logic.GetProductById(id);
        if (product == null)
        {
            _logger.LogInformation("Details not found for id {id}", id);
            return View("NotFound");
        }
        return View(product);
    }

    public async Task<IActionResult> Create()
    {
        var model = await _logic.InitializeProductModel();
        return View(model);
    }

    // POST: ProductsData/Create
    // For protecting from overposting attacks, enabling the specific properties you want to bind to.
    // More details on https://go.microsoft.com/fwlink/?LinkId=317598
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductModel product)
    {
        if (!ModelState.IsValid)
        {
            await _logic.GetAvailableCategories(product);
            return View(product);
        }
        try
        {
            await _logic.AddNewProduct(product);
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException valExec)
        {
            var results = new ValidationResult(valExec.Errors);
            results.AddToModelState(ModelState, null);
            await _logic.GetAvailableCategories(product);
            return View(product);
        }


    }

    // GET: ProductsData/Edit/3
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            _logger.LogInformation("No id passed for Edit");
            return View("NotFound");
        }

        var productModel = await _logic.GetProductById(id.Value);
        if (productModel == null)
        {
            _logger.LogInformation("Edit Details not found for id {id}", id);
            return View("NotFound");
        }

        await _logic.GetAvailableCategories(productModel);
        return View(productModel);
    }

    // POST: ProductsData/Edit/3
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductModel product)
    {
        if (id != product.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _logic.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        await _logic.GetAvailableCategories(product);
        return View(product);
    }

    // GET: ProductsData/Delete/3
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) NotFound();

        var productModel = await _logic.GetProductById(id.Value);
        if (productModel == null) return NotFound();

        return View(productModel);
    }

    // POST: ProductsData/Delete/3
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _logic.RemoveProduct(id);
        return RedirectToAction(nameof(Index));
    }

}