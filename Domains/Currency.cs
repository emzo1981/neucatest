using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1;

public class Currency
{
    public int Id { get; set; }
    [StringLength(20)]
    public int Name { get; set; }
    public bool IsActive { get; set; }

}