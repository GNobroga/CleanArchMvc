using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchMvc.Application.DTOs;

public record CategoryDTO(
    int Id,
    [Required()]
    [MinLength(3)]
    [MaxLength(100)]
    string Name 
);