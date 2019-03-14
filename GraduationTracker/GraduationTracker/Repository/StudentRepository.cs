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
    public class StudentRepository : IStudentRepository
    {
		private DataStore _context;

		public StudentRepository(DataStore dataContext)
		{
			_context = dataContext;
		}

        public Student Get(int id)
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
	}
}
