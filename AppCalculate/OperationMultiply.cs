﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalculate
{
    public class OperationMultiply : Operation
    {
        public override int Priority { get { return 4; } }

        public override string OperatorsCode { get { return "*"; } }

        public override double GetResult(double operand1, double operand2)
        {
            return operand1 * operand2;
        }
    }
}
