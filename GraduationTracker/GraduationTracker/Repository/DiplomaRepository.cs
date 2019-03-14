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
    public class DiplomaRepository : IDiplomaRepository
	{
		private DataStore _context;

		public DiplomaRepository(DataStore dataContext)
		{
			_context = dataContext;
		}
        
		public Diploma Get(int id)
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
	
	}
}
