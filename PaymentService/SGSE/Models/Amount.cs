﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGSE.Models
{
    public class Amount
    {
        public string CurrencyCode { get; set; }
        public float Value { get; set; }
    }
}
