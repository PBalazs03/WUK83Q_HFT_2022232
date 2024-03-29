﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WUK83Q_HFT_2022232.Models
{
    public class Concern
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConcernId { get; set; }
        public string ConcernName { get; set; }
        public int BornOfConcern { get; set; }
        public string CountryOfConcern { get; set; }
        public int PositionInRanking { get; set; }

        [JsonIgnore]
        public virtual ICollection<Brand> Brands { get; set; }

        public Concern(int concernId, string concernName, int bornOfConcern, string countryOfTheConcern, int positionInRanking)
        {
            ConcernId = concernId;
            ConcernName = concernName;
            BornOfConcern = bornOfConcern;
            CountryOfConcern = countryOfTheConcern;
            PositionInRanking = positionInRanking;
        }

        public Concern()
        {
            
        }
        public override string ToString()
        {
            return $"ConcernId: {ConcernId}, ConcernName: {ConcernName}, BornOfConcern: {BornOfConcern}, CountryOfConcern: {CountryOfConcern}, PositionInRanking: {PositionInRanking}";
        }
    }
}
