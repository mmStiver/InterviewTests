using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GraduationTracker;
using GraduationTracker.Interface;
using GraduationTracker.Model;
using GraduationTracker.Repository;

namespace GraduationTracker
{
    public partial class GraduationTracker
	{   
		IRequirementRepository requirementRepository;

		public GraduationTracker()
		{
			var datacontext = new Data.DataStore();
			this.requirementRepository = new RequirementRepository(datacontext);
		}

        public AcademicOutcome HasGraduated(Diploma diploma, Student student)
        {
            var earnedCredits = 0;
            var average = 0;
        
			var requirements = requirementRepository.GetRequirementByDiploma(diploma);

			earnedCredits = student.Courses
				.Join(requirements, 
					course => course.Id, 
					req => req.Courses.First(), 
					(course, req) => new { Passed = course.Mark >= req.MinimumMark, Credits = req.Credits } )
				.Where(course => course.Passed)
				.Select(course => course.Credits)
				.Sum();

			average = student.Courses.Select(c => c.Mark).Sum() / student.Courses.Length;

			return new AcademicOutcome(average, (diploma.Credits <= earnedCredits) );
        }
    }
}
