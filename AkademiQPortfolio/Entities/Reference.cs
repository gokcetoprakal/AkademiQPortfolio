using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkademiQPortfolio.Entities
{
    public class Reference
    {
        [Key]
        public int Id { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
