using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GraduationTracker;
using GraduationTracker.Model;

namespace GraduationTracker
{
	/// <summary>
	/// Class to encapsulate the academic result. Used in place of a Tuple, which is clunky in C# (before C#7)
	/// Named properties are preferred to 'item1' and 'item2' of the Tuple, which lacks immediate context for what they mean.
	/// </summary>
	public class AcademicOutcome
	{
		public STANDING Standing { get; private set; }
		public bool Graduated    {  get; private set; }
		
		public AcademicOutcome (int average, bool hasRequiredCredits)
		{
			Standing = STANDING.None;
			Graduated = hasRequiredCredits;

				if (average < 50)
					Standing = STANDING.Remedial;
				else if (average < 80)
					Standing = STANDING.Average;
				else if (average < 95)
					Standing = STANDING.SumaCumLaude;
				else
					Standing = STANDING.MagnaCumLaude;

		}
	}
}
