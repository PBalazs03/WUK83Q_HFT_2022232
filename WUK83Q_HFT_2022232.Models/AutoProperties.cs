using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUK83Q_HFT_2022232.Models
{
    public class AutoProperties
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }


        public int HorsePower { get; set; }
        public int CylinderVolume { get; set; }
        public int RunnedKm { get; set; }
        //public string Condition { get; set; }
        public string TechnicalValidity { get; set; }
        public int InsurranceAmountPerHalfYear { get; set; }

        public virtual Auto Auto { get; set; }

        [ForeignKey(nameof(Auto))]
        public int AutoId { get; set; } // Foreign Key

        

        public AutoProperties()
        {
            
        }

        public AutoProperties(int propertyId, int horsePower, int cylinderVolume, int runnedKm, string technicalValidity, int insurranceAmountPerHalfYear, int autoId)
        {
            PropertyId = propertyId;
            HorsePower = horsePower;
            CylinderVolume = cylinderVolume;
            RunnedKm = runnedKm;
            TechnicalValidity = technicalValidity;
            InsurranceAmountPerHalfYear = insurranceAmountPerHalfYear;
            AutoId = autoId;
        }

    }
}
