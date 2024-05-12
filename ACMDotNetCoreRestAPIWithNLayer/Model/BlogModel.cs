
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACMDotNetCore.RestAPIWithNLayer.Model;

[Table("Tbl_Blog")]  // mapping table 
public class BlogModel
{
    [Key] // define pk 
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }

}
