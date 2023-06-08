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
        public int Vintage { get; set; } 
        
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; } 

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; } 
        
        public virtual Owner _Owner { get; set; }
        public virtual Brand _Brand { get; set; }
     
        
        public Auto()
        {
            
        }

        public Auto(string brand, string type, int vintage, int ownerId, int autoId, int brandId)
        {
            AutoId = autoId;
            Brand = brand;
            Type = type;
            OwnerId = ownerId;
            Vintage = vintage;
            BrandId = brandId;
           
        }

        public Auto(string brand, string type, int ownerId, int vintage)
        {
            
            Type = type;
            OwnerId = ownerId;
            Vintage = vintage;
        }
        public override string ToString()
        {
            return $"AutoId: {AutoId}, Brand: {Brand}, Type: {Type}, Vintage: {Vintage}, OwnerId: {OwnerId}, BrandId: {BrandId}";
        }

    }
}
