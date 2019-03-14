using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GraduationTracker.Data;
using GraduationTracker.Interface;
using GraduationTracker.Model;


namespace GraduationTracker
{
    public class Repository : IRepository
    {
		private DataStore _context;

		public Repository(DataStore dataContext)
		{
			_context = dataContext;
		}

        public Student GetStudent(int id)
        {
            var students = _context.GetStudents();
            Student student = null;

            for (int i = 0; i < students.Length; i++)
            {
                if (id == students[i].Id)
                {
                    student = students[i];
                }
            }
            return student;
        }

        public Diploma GetDiploma(int id)
        {
            var diplomas = _context.GetDiplomas();
            Diploma diploma = null;

            for (int i = 0; i < diplomas.Length; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                }
            }
            return diploma;

        }

        public Requirement GetRequirement(int id)
        {
            var requirements = _context.GetRequirements();
            Requirement requirement = null;

            for (int i = 0; i < requirements.Length; i++)
            {
                if (id == requirements[i].Id)
                {
                    requirement = requirements[i];
                }
            }
            return requirement;
        }

    }
}
