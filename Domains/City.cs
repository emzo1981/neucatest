using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1;

public class City
{
    public int Id { get; set; }
    [StringLength(256)]
    public string Name { get; set; }
}