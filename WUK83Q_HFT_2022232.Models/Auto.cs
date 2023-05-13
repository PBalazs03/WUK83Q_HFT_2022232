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
        public string Type { get; set; }
        public int Vintage { get; set; } //évjárat
        public int HorsePower { get; set; }
        public int CylinderVolume { get; set; }
        public string Fuel { get; set; }
        public string TechnicalValidity { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        
        public virtual Owner Owner { get; set; }
        public virtual Brand Brand { get; set; }
     
        
        public Auto()
        {
            
        }

        public Auto(string brand, string type, int vintage, int ownerId, int autoId)
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
