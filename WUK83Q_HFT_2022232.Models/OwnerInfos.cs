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
    public class OwnerInfos
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }

        [Required]
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public virtual ICollection<Auto> Autos { get; set; }

        public OwnerInfos(int ownerId, string name, string birthDate, string birthPlace, string address)
        {
            OwnerId = ownerId;
            Name = name;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            Address = address;
        }
        public OwnerInfos()
        {
            
        }
    }
}
