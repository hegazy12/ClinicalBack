using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class BaseModule
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set ; }
    public DateTime? UpdatedAt { get; set;}
    public bool IsUpdated { get; set;}
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? DeletedBy { get; set; }
    public bool IsActive { get; set; } // Default to active
   
    public void Create(Guid userId)
    {
        Id= Guid.NewGuid();
        IsUpdated = false;
        IsActive = false;
        IsDeleted = false;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = userId;
    }
   
    public void MarkAsUpdated(Guid userId)
    {
        IsUpdated = true;
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userId;
    }

    
    
    public void MarkAsDeleted(Guid userId){
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = userId;
    }

}
