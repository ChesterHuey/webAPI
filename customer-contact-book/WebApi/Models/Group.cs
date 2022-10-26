using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

/// <summary>
/// Group Model.
/// </summary>
public class Group
{
    [Key]
    public long Id { get; set; }

  
    public string Name { get; set; }

   
}
