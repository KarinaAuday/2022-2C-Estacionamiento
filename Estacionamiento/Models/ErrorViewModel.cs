using System;

namespace Estacionamiento.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public const string Requerido = "El Campo es requerido";
        public const string MinMaxString = "El campo {0} debe estar en el rango correcto";
    }
}
