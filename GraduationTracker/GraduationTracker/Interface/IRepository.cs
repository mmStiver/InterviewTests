﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GraduationTracker.Interface;
using GraduationTracker.Model;

namespace GraduationTracker.Interface
{
	public interface IRepository<TEntity>
			where TEntity : class
	{
		TEntity Get(int id);
	}
}
