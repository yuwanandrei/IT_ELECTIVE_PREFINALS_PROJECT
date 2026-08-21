using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LycevmHelpDesk.Models;

[Table("Departments")]
public class Department
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<Team> Teams { get; set; } = new List<Team>();
}

[Table("Employees")]
public class Employee
{
    [Key] public int Id { get; set; }
    public int DepartmentId { get; set; }
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string JobTitle { get; set; } = string.Empty;
    [Required] public string HireDate { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Department Department { get; set; } = null!;
    public ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();
    public ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
    public ICollection<TicketComment> TicketComments { get; set; } = new List<TicketComment>();
    [NotMapped] public string FullName => $"{FirstName} {LastName}";
}

[Table("Teams")]
public class Team
{
    [Key] public int Id { get; set; }
    public int DepartmentId { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Department Department { get; set; } = null!;
    public ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
}

[Table("TeamMembers")]
public class TeamMember
{
    public int TeamId { get; set; }
    public int EmployeeId { get; set; }
    [Required] public string JoinedAt { get; set; } = string.Empty;
    public Team Team { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
}

[Table("Customers")]
public class Customer
{
    [Key] public int Id { get; set; }
    [Required] public string CompanyName { get; set; } = string.Empty;
    [Required] public string ContactName { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    [Required] public string CreatedAt { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

[Table("Tags")]
public class Tag
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
}

[Table("TicketCategories")]
public class TicketCategory
{
    [Key] public int Id { get; set; }
    public int? ParentCategoryId { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TicketCategory? ParentCategory { get; set; }
    public ICollection<TicketCategory> ChildCategories { get; set; } = new List<TicketCategory>();
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

[Table("TicketPriorities")]
public class TicketPriority
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public int ResponseHours { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

[Table("TicketStatuses")]
public class TicketStatus
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    public bool IsClosed { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

[Table("Tickets")]
public class Ticket
{
    [Key] public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CategoryId { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    [Required] public string Subject { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
    [Required] public string CreatedAt { get; set; } = string.Empty;
    [Required] public string UpdatedAt { get; set; } = string.Empty;
    public string? DueAt { get; set; }
    public string? ResolvedAt { get; set; }
    public string? ClosedAt { get; set; }
    public Customer Customer { get; set; } = null!;
    public TicketCategory Category { get; set; } = null!;
    public TicketPriority Priority { get; set; } = null!;
    public TicketStatus Status { get; set; } = null!;
    public ICollection<TicketAssignment> Assignments { get; set; } = new List<TicketAssignment>();
    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
    public ICollection<TicketAttachment> Attachments { get; set; } = new List<TicketAttachment>();
    public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
}

[Table("TicketAssignments")]
public class TicketAssignment
{
    public int TicketId { get; set; }
    public int EmployeeId { get; set; }
    [Required] public string AssignedAt { get; set; } = string.Empty;
    public string? UnassignedAt { get; set; }
    public bool IsPrimary { get; set; }
    public Ticket Ticket { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
}

[Table("TicketComments")]
public class TicketComment
{
    [Key] public int Id { get; set; }
    public int TicketId { get; set; }
    public int? EmployeeId { get; set; }
    [Required] public string Comment { get; set; } = string.Empty;
    [Required] public string CreatedAt { get; set; } = string.Empty;
    public bool IsInternal { get; set; }
    public Ticket Ticket { get; set; } = null!;
    public Employee? Employee { get; set; }
}

[Table("TicketAttachments")]
public class TicketAttachment
{
    [Key] public int Id { get; set; }
    public int TicketId { get; set; }
    [Required] public string FileName { get; set; } = string.Empty;
    [Required] public string ContentType { get; set; } = string.Empty;
    public int FileSize { get; set; }
    [Required] public string UploadedAt { get; set; } = string.Empty;
    public Ticket Ticket { get; set; } = null!;
}

[Table("TicketTags")]
public class TicketTag
{
    public int TicketId { get; set; }
    public int TagId { get; set; }
    public Ticket Ticket { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
