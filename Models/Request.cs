using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Request:RequesEditModel
{
    public Guid Id{get;set;}

}