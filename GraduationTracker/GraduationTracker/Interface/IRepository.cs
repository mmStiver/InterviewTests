using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GraduationTracker.Model;

namespace GraduationTracker.Interface
{
    public interface IRepository
    {
        Student GetStudent(int id);

        Diploma GetDiploma(int id);

        Requirement GetRequirement(int id);

	}
}
