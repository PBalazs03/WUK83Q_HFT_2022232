﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public bool HasFormula1Team { get; set; }
        public int ConcernId { get; set; } //idegen kulcs

        public virtual Concern _Concern { get; set; }

        [JsonIgnore]
        public virtual ICollection<Auto> Autos { get; set; }

        public Brand()
        {
            
        }

        public Brand(int brandId, string brandName, string originOfBrand, int bornOfBrand, bool isProducingFullyElectricCars, bool hasFormula1Team, int concernId)
        {
            BrandId = brandId;
            BrandName = brandName;
            OriginOfBrand = originOfBrand;
            BornOfBrand = bornOfBrand;
            IsProducingFullyElectricCars = isProducingFullyElectricCars;
            HasFormula1Team = hasFormula1Team;
            ConcernId = concernId;
        }

        public override string ToString()
        {
            return $"BrandId: {BrandId}, BrandName: {BrandName}, OriginOfBrand: {OriginOfBrand}, BornOfBrand: {BornOfBrand}, IsProducingFullyElectricCars: {IsProducingFullyElectricCars}, HasFormula1Team: {HasFormula1Team}, ConcernId: {ConcernId}";
        }
    }
}
