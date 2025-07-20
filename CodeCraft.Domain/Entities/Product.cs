using CodeCraft.Domain.Primitives;
using FluentResults;

namespace CodeCraft.Domain.Entities;

public sealed class Product : Entity
{
    private Product(
        string name,
        string description)
    {
        Name = name;
        Description = description;
    }

    #region Properties

    public string Name { get; private set; } 
    public string Description { get; private set; }    

    #endregion

    #region Behaviors
    
    public static Result<Product> Create(
        string name,
        string description,
        Guid userId)
    {
        var validationResult = Validate(name, description);
        if (validationResult.IsFailed) return Result.Fail(validationResult.Errors);
        
        var product = new Product(
            name,
            description);
        
        product.MarkAsCreated(userId);
        return product;
    }
    
    public Result Update(
        string name,
        string description,
        Guid userId)
    {
        var validationResult = Validate(name, description);
        if (validationResult.IsFailed) return Result.Fail(validationResult.Errors);

        Name = name;
        Description = description;
        
        MarkAsModified(userId);
        return Result.Ok();
    }
    
    public Result Delete(
        Guid userId)
    {
        // Validate for deletion
        
        MarkAsDeleted(userId);
        return Result.Ok();
    }

    private static Result Validate(
        string name,
        string description)
    {
        // Validations for name and description if failed returns error
        
        return Result.Ok();
    }
    
    #endregion
    
}