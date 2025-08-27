using System;
using Core.Entities;

namespace Entities.DTOs;

public class CustomerDetailDto : IDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
}
