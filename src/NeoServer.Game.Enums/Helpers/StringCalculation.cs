﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeoServer.Game.Common.Helpers
{
    public class StringCalculation
    {
        private static DataTable dataTable = new DataTable();
        public static double Calculate(string formula, params (string, double)[] arguments)
        {
            foreach (var arg in arguments)
            {
                formula = formula.Replace(arg.Item1, arg.Item2.ToString(CultureInfo.InvariantCulture));
            }
            double result = Convert.ToDouble(dataTable.Compute(formula, null));
            return result;
        }
    }
}
