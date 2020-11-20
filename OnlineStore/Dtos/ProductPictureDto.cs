﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Dtos
{
    public class ProductPictureDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Guid ProductId { get; set; }
    }
}
