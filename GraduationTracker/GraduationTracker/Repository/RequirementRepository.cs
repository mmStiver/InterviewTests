using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GraduationTracker.Data;
using GraduationTracker.Interface;
using GraduationTracker.Model;


namespace GraduationTracker.Repository
{
    public class RequirementRepository : IRequirementRepository
	{
		private DataStore _context;

		public RequirementRepository(DataStore dataContext)
		{
			_context = dataContext;
		}

        public Requirement Get(int id)
        {
            var requirements = _context.GetRequirements();
            return requirements.FirstOrDefault( r => r.Id == id);
        }
		
		/// <summary>
		/// Search for Requirements by diploma
		/// </summary>
		public IEnumerable<Requirement> GetRequirementByDiploma(Diploma diploma)
		{
			return _context.GetRequirements().Where(r => diploma.Requirements.Contains(r.Id));
		}
	}
}
