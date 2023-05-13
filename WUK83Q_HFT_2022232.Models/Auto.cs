using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WUK83Q_HFT_2022232.Models
{
    public class Auto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }

        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        public int OwnerId { get; set; }
        public virtual OwnerInfos Owner { get; set; }

        public int Vintage { get; set; } //évjárat
        ///
        

        [JsonIgnore]
        public virtual ICollection<AutoProperties> AutoInfos { get; set; }

        public Auto()
        {
            
        }

        public Auto(int autoId, string brand, string type, int ownerId, int vintage, int horsePower, int cylinderVolume)
        {
            AutoId = autoId;
            Brand = brand;
            Type = type;
            OwnerId = ownerId;
            Vintage = vintage;
           
        }

        public Auto(string brand, string type, int ownerId, int vintage)
        {
            Brand = brand;
            Type = type;
            OwnerId = ownerId;
            Vintage = vintage;
        }
    }
}
