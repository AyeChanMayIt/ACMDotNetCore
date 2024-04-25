using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACMDotNetCore.ConsoleApp.Dtos;

[Table("Tbl_Blog")]  // mapping table 
public class BlogDto
{
    [Key] // define pk 
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }

}
