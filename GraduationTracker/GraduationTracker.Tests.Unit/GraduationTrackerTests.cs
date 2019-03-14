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
		protected GraduationTracker tracker;
		protected Diploma diploma;
		protected Student[] students;

		[TestMethod]
		public void HasGraduated_StudentWith40Average_RemedialResultTest()
		{
			var diploma = CreateDiploma();
			var student = CreateStudents().Where( s => s.Id == 4).FirstOrDefault();

			tracker = CreateGraduationTracker();
			
			Assert.IsFalse(tracker.HasGraduated(diploma, student).Graduated);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Standing == STANDING.Remedial);

		}

		[TestMethod]
		public void HasGraduated_StudentWith50Average_AverageStudentTest()
		{
			var diploma = CreateDiploma();
			var student = CreateStudents().Where(s => s.Id == 3).FirstOrDefault();

			tracker = CreateGraduationTracker();
			
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Graduated);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Standing == STANDING.Average);

		}

		[TestMethod]
		public void HasGraduated_StudentWith80Average_SumaCumLaudeTest()
		{
			var diploma = CreateDiploma();
			var student = CreateStudents().Where(s => s.Id == 2).FirstOrDefault();

			tracker = CreateGraduationTracker();

			Assert.IsTrue(tracker.HasGraduated(diploma, student).Graduated);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Standing == STANDING.SumaCumLaude);

		}

		[TestMethod]
		public void HasGraduated_StudentWith95Average_MagnaCumLaudeTest()
		{
			diploma = CreateDiploma();
			var student = CreateStudents().Where(s => s.Id == 1).FirstOrDefault();
			tracker = CreateGraduationTracker();

			Assert.IsTrue(tracker.HasGraduated(diploma, student).Graduated);
			Assert.IsTrue(tracker.HasGraduated(diploma, student).Standing == STANDING.MagnaCumLaude);

		}

		[TestMethod]
		public void HasGraduated_PassingStudentsProcessed_AllStudentsReturnedTest()
		{
			diploma = CreateDiploma();
			var student = CreateStudents().Where(s => s.Id != 4);
			tracker = CreateGraduationTracker();
			var graduated = new List<AcademicOutcome>();

			foreach (var s in student)
			{
				graduated.Add(tracker.HasGraduated(diploma, s));
			}
			
			Assert.IsTrue(graduated.All(g => g.Graduated));
		}

		[TestMethod]
		public void HasGraduated_AllStudentsProcessed_AllStudentsReturnedTest()
		{
			diploma = CreateDiploma();
			students = CreateStudents();

			tracker = CreateGraduationTracker();

			
			var graduated = new List<AcademicOutcome>();

			foreach (var student in students)
			{
				graduated.Add(tracker.HasGraduated(diploma, student));
			}

			Assert.IsFalse(graduated.All( g => g.Graduated));
		}

		#region Setup
		// Creation methods in place of SetUp/ Tear Down
		// Microsoft's own advice: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
		//
		//Less confusion when reading the tests since all of the code is visible from within each test.
		//Less chance of setting up too much or too little for the given test.
		//Less chance of sharing state between tests which creates unwanted dependencies between them.

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
