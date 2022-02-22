using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class RequesCreateModel
{
 

    [Required,MaxLength(100)]
    public string? Title{get;set;}

    public string? Description{get;set;}


}