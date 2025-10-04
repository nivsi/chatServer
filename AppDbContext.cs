using Microsoft.EntityFrameworkCore;
using chatServer.UsersManager;
namespace chatServer;
using chatServer.MessagesManager;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var dbPath = Path.GetFullPath("identifier.sqlite");
        Console.WriteLine($"[DB] Using SQLite at: {dbPath}");

        options.UseSqlite($"Data Source={dbPath}");
    }
   
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    
}