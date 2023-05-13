using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUK83Q_HFT_2022232.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string OriginOfBrand { get; set; }
        public int BornOfBrand { get; set; }
        public bool IsProducingFullyElectricCars { get; set; }
        public virtual ICollection<Auto> Autos { get; set; }

        public Brand()
        {
            
        }

       

    }
}
