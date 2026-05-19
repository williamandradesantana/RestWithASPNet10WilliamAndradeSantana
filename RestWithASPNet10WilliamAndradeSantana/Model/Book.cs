using RestWithASPNet10WilliamAndradeSantana.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNet10WilliamAndradeSantana.Model;

[Table("books")]
public class Book : BaseEntity
{
    [Required]
    [Column("title", TypeName = "varchar(max)")]
    public string Title { get; set; }

    [Required]
    [Column("author", TypeName = "varchar(max)")]
    public string Author { get; set; }

    [Required]
    [Column("price", TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Required]
    [Column("launch_date", TypeName = "datetime2(6)")]
    public DateTime LaunchDate { get; set; }
}