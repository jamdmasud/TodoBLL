using System;  
using System.Linq;  
using System.Security.Principal;  
using System.Threading;  
using System.Threading.Tasks;  
using Microsoft.EntityFrameworkCore;
using UnitOfWorkRepository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {        
    }
    protected override void OnModelCreating(ModelBuilder builder)  
    {         
      base.OnModelCreating(builder);  
    }  
  
    public virtual void Save()  
    {  
      base.SaveChanges();  
    }  
    public Guid UserProvider  
    {  
      get  
      {          
        return Guid.NewGuid();  
      }  
    }  
  
    public Func<DateTime> TimestampProvider { get; set; } = ()  
        => DateTime.UtcNow;  
    public override int SaveChanges()  
    {  
      TrackChanges();  
      return base.SaveChanges();  
    }  
      
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())  
    {  
      TrackChanges();  
      return await base.SaveChangesAsync(cancellationToken);  
    }  
  
    private void TrackChanges()  
    {  
      foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))  
      {  
        if (entry.Entity is IAuditable)  
        {  
          var auditable = entry.Entity as IAuditable;  
          if (entry.State == EntityState.Added)  
          {  
            auditable.CreatedBy = UserProvider;//  
            auditable.CreatedDate = TimestampProvider();   
          }  
          else  
          {  
            auditable.UpdatedBy = UserProvider;  
            auditable.UpdatedDate = TimestampProvider();  
          }  
        }  
      }  
    }  
   
}