using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
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

        public override bool Equals(object obj)
        {
            Auto b = obj as Auto;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.AutoId == b.AutoId && this.Brand == b.Brand && this.Type == b.Type;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AutoId, this.Brand, this.Type);
        }

        public class AutoInfo
        {
            public int AutoId { get; set; }
            public double? AverageVintage { get; set; } 
            
            public string CarOwnedByOwner { get; set; }

            public string YoungestOrOldestCar { get; set; }

            public override bool Equals(object obj)
            {
                AutoInfo b = obj as AutoInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.AutoId == b.AutoId;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.AverageVintage, this.CarOwnedByOwner, this.YoungestOrOldestCar);
            }

        }
    }
}
