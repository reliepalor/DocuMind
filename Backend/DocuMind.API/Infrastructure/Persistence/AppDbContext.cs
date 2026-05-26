using Microsoft.EntityFrameworkCore;
using DocuMind.Domain.Entities;

namespace DocuMind.Infrastructure.Persistence;

public class AppDbContext : DbContext
{ 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } 
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Workspace>()
            .HasOne(w => w.Owner)
            .WithMany()
            .HasForeignKey(w => w.OwnerId);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.Workspace)
            .WithMany()
            .HasForeignKey(d => d.WorkspaceId);

        modelBuilder.Entity<DocumentChunk>()
            .HasOne(dc => dc.Document)
            .WithMany()
            .HasForeignKey(dc => dc.DocumentId);

        modelBuilder.Entity<Chat>()
            .HasOne(c => c.Workspace)
            .WithMany()
            .HasForeignKey(c => c.WorkspaceId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany()
            .HasForeignKey(m => m.ChatId);
    }

}