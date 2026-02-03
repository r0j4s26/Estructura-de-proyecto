using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage = "La placa es obligatoria")]
        [RegularExpression(@"^[A-Z0-9-]{6,10}$", ErrorMessage = "Formato de placa inválido (solo letras, números y guiones)")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El color es obligatorio")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "El año debe ser un formato válido (ej: 2024)")]
        public string Anio { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El correo del propietario es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public string CorreoPropietario { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[2468]\d{7}$", ErrorMessage = "El teléfono debe tener 8 dígitos y empezar con un número válido en CR")]
        public string TelefonoPropietario { get; set; }
    }

    public class VehiculoRequest : VehiculoBase
    {
        [Required(ErrorMessage = "El modelo es obligatorio")]
        public Guid IdModelo { get; set; }
    }

    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}