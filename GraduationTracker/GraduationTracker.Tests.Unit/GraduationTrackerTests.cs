using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using GraduationTracker.Model;

namespace GraduationTracker.Tests.Unit
{
	[TestClass]
	public class GraduationTrackerTests
	{
		protected Diploma diploma;
		protected Student[] students;

		[TestMethod]
		public void HasGraduated_StudentWith40Average_RemedialResultTest()
		{
			var diploma = CreateDiploma();
			var student = CreateStudents().Where( s => s.Id == 4).FirstOrDefault();

			var tracker = CreateGraduationTracker();

			// assert false when a student has failed?
			Assert.IsFalse(tracker.HasGraduated(diploma, student).Item1);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Item2 == STANDING.Remedial);

		}

		[TestMethod]
		public void HasGraduated_StudentWith50Average_AverageStudentTest()
		{
			var diploma = CreateDiploma();
			var student = CreateStudents().Where(s => s.Id == 3).FirstOrDefault();

			var tracker = CreateGraduationTracker();

			// assert false when a student has failed?
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Item1);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Item2 == STANDING.Average);

		}

		[TestMethod]
		public void HasGraduated_StudentWith80Average_SumaCumLaudeTest()
		{
			var diploma = CreateDiploma();
			var student = CreateStudents().Where(s => s.Id == 2).FirstOrDefault();

			var tracker = CreateGraduationTracker();
			// assert false when a student has failed?
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Item1);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Item2 == STANDING.SumaCumLaude);

		}

		[TestMethod]
		public void HasGraduated_StudentWith95Average_MagnaCumLaudeTest()
		{
			var diploma = CreateDiploma();
			var student = CreateStudents().Where(s => s.Id == 1).FirstOrDefault();

			var tracker = CreateGraduationTracker();

			// assert false when a student has failed?
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Item1);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Item2 == STANDING.MagnaCumLaude);

		}

		[TestMethod]
		public void HasGraduated_PAssingStudentsProcessed_AllStudentsReturnedTest()
		{
			var diploma = CreateDiploma();
			var students = CreateStudents().Where(s => s.Id != 4);
			var tracker = CreateGraduationTracker();
			var graduated = new List<Tuple<bool, STANDING>>();

			foreach (var student in students)
			{
				graduated.Add(tracker.HasGraduated(diploma, student));
			}

			// assert false when if student has failed?
			Assert.IsTrue(graduated.All(g => g.Item1));
		}

		[TestMethod]
		public void HasGraduated_AllStudentsProcessed_AllStudentsReturnedTest()
		{
			var diploma = CreateDiploma();
			var students = CreateStudents();

			var tracker = CreateGraduationTracker();

			
			var graduated = new List<Tuple<bool, STANDING>>();

			foreach (var student in students)
			{
				graduated.Add(tracker.HasGraduated(diploma, student));
			}

			// assert false when a student has failed?
			Assert.IsFalse(graduated.All( g => g.Item1));
		}

		#region Setup
		private GraduationTracker CreateGraduationTracker()
		{
			return new GraduationTracker();
		}
		private Diploma CreateDiploma()
		{
			return new Diploma
			{
				Id = 1,
				Credits = 4,
				Requirements = new int[] { 100, 102, 103, 104 }
			};
		}
		private Student[] CreateStudents()
		{
			return new[]
			{
			   new Student
			   {
				   Id = 1,
				   Courses = new Course[]
				   {
						new Course{Id = 1, Name = "Math", Mark=95 },
						new Course{Id = 2, Name = "Science", Mark=95 },
						new Course{Id = 3, Name = "Literature", Mark=95 },
						new Course{Id = 4, Name = "Physichal Education", Mark=95 }
				   }
			   },
			   new Student
			   {
				   Id = 2,
				   Courses = new Course[]
				   {
						new Course{Id = 1, Name = "Math", Mark=80 },
						new Course{Id = 2, Name = "Science", Mark=80 },
						new Course{Id = 3, Name = "Literature", Mark=80 },
						new Course{Id = 4, Name = "Physichal Education", Mark=80 }
				   }
			   },
			   new Student
			{
				Id = 3,
				Courses = new Course[]
				{
					new Course{Id = 1, Name = "Math", Mark=50 },
					new Course{Id = 2, Name = "Science", Mark=50 },
					new Course{Id = 3, Name = "Literature", Mark=50 },
					new Course{Id = 4, Name = "Physichal Education", Mark=50 }
				}
			},
			   new Student
			{
				Id = 4,
				Courses = new Course[]
				{
					new Course{Id = 1, Name = "Math", Mark=40 },
					new Course{Id = 2, Name = "Science", Mark=40 },
					new Course{Id = 3, Name = "Literature", Mark=40 },
					new Course{Id = 4, Name = "Physichal Education", Mark=40 }
				}
			}
			};
		}
		#endregion
	}
}
