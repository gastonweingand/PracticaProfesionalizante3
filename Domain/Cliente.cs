﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Cliente
    {
        public Guid Id { get; set; }

        public String Nombre { get; set; }

        public String CUIT { get; set; }
    }
}
