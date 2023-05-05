﻿using Services.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class StringExtension
    {
        public static String Traducir(this string palabra)
        {
            return IdiomaBll.Current.Traducir(palabra);
        }

        public static void HandleException(this Exception ex)
        {
            Console.WriteLine("Aplicando política de exception...." + ex.Message);
        }
    }
}
