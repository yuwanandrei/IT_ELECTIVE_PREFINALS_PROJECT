using LycevmHelpDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace LycevmHelpDesk.Data;

public class HelpDeskContext : DbContext
{
    public HelpDeskContext(DbContextOptions<HelpDeskContext> options) : base(options) { }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<TicketCategory> TicketCategories => Set<TicketCategory>();
    public DbSet<TicketPriority> TicketPriorities => Set<TicketPriority>();
    public DbSet<TicketStatus> TicketStatuses => Set<TicketStatus>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<TicketAssignment> TicketAssignments => Set<TicketAssignment>();
    public DbSet<TicketComment> TicketComments => Set<TicketComment>();
    public DbSet<TicketAttachment> TicketAttachments => Set<TicketAttachment>();
    public DbSet<TicketTag> TicketTags => Set<TicketTag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Employee>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Team>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Customer>().Property(x => x.IsActive).HasConversion<int>();
        modelBuilder.Entity<Employee>().Property(x => x.IsActive).HasConversion<int>();
        modelBuilder.Entity<Department>().Property(x => x.IsActive).HasConversion<int>();
        modelBuilder.Entity<TicketStatus>().Property(x => x.IsClosed).HasConversion<int>();
        modelBuilder.Entity<TicketAssignment>().Property(x => x.IsPrimary).HasConversion<int>();
        modelBuilder.Entity<TicketComment>().Property(x => x.IsInternal).HasConversion<int>();

        modelBuilder.Entity<TeamMember>().HasKey(x => new { x.TeamId, x.EmployeeId });
        modelBuilder.Entity<TicketAssignment>().HasKey(x => new { x.TicketId, x.EmployeeId });
        modelBuilder.Entity<TicketTag>().HasKey(x => new { x.TicketId, x.TagId });

        modelBuilder.Entity<Employee>()
            .HasOne(x => x.Department).WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>()
            .HasOne(x => x.Department).WithMany(x => x.Teams)
            .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TeamMember>()
            .HasOne(x => x.Team).WithMany(x => x.Members)
            .HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<TeamMember>()
            .HasOne(x => x.Employee).WithMany(x => x.TeamMemberships)
            .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketCategory>()
            .HasOne(x => x.ParentCategory).WithMany(x => x.ChildCategories)
            .HasForeignKey(x => x.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(x => x.Customer).WithMany(x => x.Tickets)
            .HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Ticket>()
            .HasOne(x => x.Category).WithMany(x => x.Tickets)
            .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Ticket>()
            .HasOne(x => x.Priority).WithMany(x => x.Tickets)
            .HasForeignKey(x => x.PriorityId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Ticket>()
            .HasOne(x => x.Status).WithMany(x => x.Tickets)
            .HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketAssignment>()
            .HasOne(x => x.Ticket).WithMany(x => x.Assignments)
            .HasForeignKey(x => x.TicketId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<TicketAssignment>()
            .HasOne(x => x.Employee).WithMany(x => x.TicketAssignments)
            .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketComment>()
            .HasOne(x => x.Ticket).WithMany(x => x.Comments)
            .HasForeignKey(x => x.TicketId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<TicketComment>()
            .HasOne(x => x.Employee).WithMany(x => x.TicketComments)
            .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketAttachment>()
            .HasOne(x => x.Ticket).WithMany(x => x.Attachments)
            .HasForeignKey(x => x.TicketId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketTag>()
            .HasOne(x => x.Ticket).WithMany(x => x.TicketTags)
            .HasForeignKey(x => x.TicketId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<TicketTag>()
            .HasOne(x => x.Tag).WithMany(x => x.TicketTags)
            .HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Restrict);
    }
}
