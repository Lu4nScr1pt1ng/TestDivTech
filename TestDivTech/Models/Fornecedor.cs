using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TestDivTech.Models
{
    public class Fornecedor
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string? nome { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "Um CNPJ contém 14 caracteres")]
        [MinLength(14, ErrorMessage = "Um CNPJ contém 14 caracteres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CNPJ Precisa ser numerico")]
        public string? cnpj { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Especialidade só poder conter no maximo 30 caracteres")]
        public string? especialidade { get; set; }

    }
}
