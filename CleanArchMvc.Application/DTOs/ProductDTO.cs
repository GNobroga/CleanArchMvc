using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs;

public record ProductDTO(
    int Id,
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    string Name,
    [Required]
    string Description,
    [Required]
    decimal Price,
    [Required]
    [Range(1, 9999)]
    int Stock,
    string Image
);