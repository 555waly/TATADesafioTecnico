using System.ComponentModel.DataAnnotations;

namespace TATADesafioTecnico.DataModel
{
    public class TipoCambioDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Moneda { get; set; }
        public double TipoCambio { get; set; }
    }
}
