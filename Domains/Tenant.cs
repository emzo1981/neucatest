namespace ClassLibrary1;

public class Tenant
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public TenantGroupEnum TenantGroup { get; set; }
    public bool IsActive { get; set; }

}