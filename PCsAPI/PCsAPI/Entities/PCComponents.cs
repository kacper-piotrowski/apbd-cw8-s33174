using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

 
namespace PCsAPI.Entities;

[PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponents
{
    public int PCId {get; set;}
    
    [Column(TypeName = "char(10)")]
    [MaxLength(10)]
    public string ComponentCode {get; set;}
    
    public int Amount {get; set;}

    public PCs Pc { get; set; } = null;
    public Components Component { get; set; } = null;
}