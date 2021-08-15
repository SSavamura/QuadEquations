using System;
using System.Collections.Generic;
using System.Linq;

namespace QuadEquations
{
    public class QuadEquations
	{
		double A { get; }
		double B { get; }
		double C { get; }

		double discriminant
		{
			get
			{
				return FindDiscrim();
			}
		}

		public double X1 
		{
			get
            {
				return FindRoot(true);
			}	
		}

		public double X2 
		{
			get
            {
				if (discriminant > 0)
                {
					return FindRoot(false);
				}

				return double.NaN;
			}	
		}

		public int RootCount
		{
			get
            {
				return new List<double>(2) { X1, X2 }
				.Where(x => !double.IsNaN(x))
				.ToArray()
				.Count();
			}
		}

		public QuadEquations(double a, double b, double c)
		{
			if (a > 0 & !double.IsNaN(a))
			{
				this.A = a;
			}
			else
			{
				throw new CoefficientAtFirstTermOfEquatiosIsZeroOrNaN();
			}

			this.B = b;
			this.C = c;
		}

		public QuadEquations(double[] terms)
		{
            if (terms.Length == 3)
            {
				if (terms[0] > 0 & !double.IsNaN(terms[0]))
				{
					this.A = terms[0];
				}
				else
				{
					throw new CoefficientAtFirstTermOfEquatiosIsZeroOrNaN();
				}

				this.B = terms[1];
				this.C = terms[2];
			}
			else
            {
				throw new WrongNumberOfTerm();
			}
		}

		double FindDiscrim()
        {
			return Math.Pow(this.B, 2) - 4 * this.A * this.C;
		}

		double FindRoot(bool pos)
        {
			if (discriminant < 0)
			{
				return double.NaN;
			}
			else
			{
				var sgn = pos ? 1.0 : -1.0;
				return (sgn * Math.Sqrt(discriminant) - B) / (2.0 * A);
			}
		}
    }

	public class CoefficientAtFirstTermOfEquatiosIsZeroOrNaN : ApplicationException 
	{
	}

	public class WrongNumberOfTerm  : ApplicationException
	{
	}
}
