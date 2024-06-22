using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ACMDotNetCore.MVCApps.Models;

[Table("Tbl_Blog")]  // mapping table 
public class BlogModel
{
    [Key] // define pk 
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }

}
