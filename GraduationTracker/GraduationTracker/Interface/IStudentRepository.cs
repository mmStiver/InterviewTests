using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GraduationTracker.Interface;
using GraduationTracker.Model;

namespace GraduationTracker.Interface
{
	public interface IStudentRepository : IRepository<Student>
	{
	}
}
