
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;


namespace Task.Tests
{
	public class DatabaseTesting
	{
#nullable disable
        //Testing Databases using InMemory testing.


        //Testing Jobs Table ---------
        [Fact]
        public void Job_Add_Without_Relation()
        {
            //----- Arrange -----
            var factory = new ConnectionFactory();

            //get instance of JobDbContext
            var context = factory.CreateContextForInMemory();

            //create new job instance
            var testJob = new Job() { Name = "Test Job 1", EmployerId = 1 };

            //----- Act -----
            var data = context.Jobs.Add(testJob);
            context.SaveChanges();

            //----- Assert -----
            //Get the job count
            var jobCount = context.Jobs.Count();
            if (jobCount != 0)
            {
                Assert.Equal(1, jobCount);
            }

            //Get single job detail
            var singleJob = context.Jobs.FirstOrDefault();
            if (singleJob != null)
            {
                Assert.Equal("Test Job 1", singleJob.Name);
                Assert.Equal(1, singleJob.EmployerId);
            }
        }

        [Fact]
        public void Job_Add_With_Employer_Relation()
        {
            //----- Arrange -----
            var factory = new ConnectionFactory();

            //get instance of JobBdContext
            var context = factory.CreateContextForInMemory();

            var testJob = new Job() { Name = "Test Job 2", EmployerId = 2 };

            //----- Act -----
            var data = context.Jobs.Add(testJob);
            context.SaveChanges();

            //----- Assert -----

            //Get job count
            var jobCount = context.Jobs.Count();
            if (jobCount != 0)
            {
                Assert.Equal(1, jobCount);
            }

            //get single job detail
            var singleJob = context.Jobs.FirstOrDefault();
            if (singleJob != null)
            {
                Assert.Equal("Test Job 2", singleJob.Name);
                Assert.Equal(2, singleJob.EmployerId);
            }

        }

        [Fact]
        public void Job_Add_Multiples_Jobs_With_Multiple_Employers_Test()
        {
            //----- Arrange -----
            var factory = new ConnectionFactory();

            //get instance of JobDbContext
            var context = factory.CreateContextForInMemory();

            //----- Act -----
            for (int i = 1; i <= 100; i++)
            {
                var testJob = new Job() { Name = "Test Job " + i, EmployerId = 1 + i };
                context.Jobs.Add(testJob);
            }
            context.SaveChanges();

            //----- Assert -----
            //Get job count

            var jobCount = context.Jobs.Count();
            if (jobCount != 0)
            {
                Assert.Equal(100, jobCount);
            }

            //Get single job deatil
            var singleJob = context.Jobs.Where(x => x.Id == 1).FirstOrDefault();
            if (singleJob != null)
            {
                Assert.Equal("Test Job 1", singleJob.Name);
            }

            var singleJob10 = context.Jobs.Where(x => x.Id == 10).FirstOrDefault();
            if (singleJob10 != null)
            {
                Assert.Equal("Test Job 10", singleJob10.Name);
            }
        }

        [Fact]
        public void Job_Add_Multiples_Jobs_With_Same_Employers_Test()
        {
            //----- Arrange -----
            var factory = new ConnectionFactory();

            //get instance of JobDbContext
            var context = factory.CreateContextForInMemory();

            //----- Act -----
            for (int i = 1; i <= 100; i++)
            {
                var testJob = new Job() { Name = "Test Job " + i, EmployerId = 2 };
                context.Jobs.Add(testJob);
            }
            context.SaveChanges();

            //----- Assert -----
            //Get job count

            var jobCount = context.Jobs.Count();
            if (jobCount != 0)
            {
                Assert.Equal(100, jobCount);
            }

            //Get single job deatil - checking multiple jobs, looking for same employer
            var singleJob = context.Jobs.Where(x => x.Id == 1).FirstOrDefault();
            if (singleJob != null)
            {
                Assert.Equal("Test Job 1", singleJob.Name);
                Assert.Equal(2, singleJob.EmployerId);
            }

            var singleJob20 = context.Jobs.Where(x => x.Id == 20).FirstOrDefault();
            if (singleJob20 != null)
            {
                Assert.Equal("Test Job 20", singleJob20.Name);
                Assert.Equal(2, singleJob20.EmployerId);
            }
        }

        //testing Employer table
        [Fact]
        public void Employer_Add_Without_Relation()
        {
            //----- Arrange -----
            var factory = new ConnectionFactory();

            //get instance of JobDbContext
            var context = factory.CreateContextForInMemory();

            var testEmployer = new Employer { Name = "Test Employer 1", Location = "Test Location 1" };

            //----- Act -----
            var data = context.Employers.Add(testEmployer);
            context.SaveChanges();

            //----- Assert -----
            //Get the job count
            var employerCount = context.Employers.Count();
            if (employerCount != 0)
            {
                Assert.Equal(1, employerCount);
            }

            //Get single job detail
            var singleEmployer = context.Employers.FirstOrDefault();
            if (singleEmployer != null)
            {
                Assert.Equal("Test Employer 1", singleEmployer.Name);
                Assert.Equal("Test Location 1", singleEmployer.Location);
            }

        }


        //Testing Skills Table ---------
        [Fact]
        public void Skill_Add_Without_Relation()
        {
            //----- Arrange -----
            var factory = new ConnectionFactory();

            //get instance of JobDbContext
            var context = factory.CreateContextForInMemory();

            var testSkill = new Skill() { SkillName = "Test Skill" };

            //----- Act -----
            var data = context.Skills.Add(testSkill);
            context.SaveChanges();

            //----- Assert -----
            //Get the skill count
            var skillCount = context.Skills.Count();
            if (skillCount != 0)
            {
                Assert.Equal(1, skillCount);
            }

            //Get single skill detail
            var singleSkill = context.Skills.FirstOrDefault();
            if (singleSkill != null)
            {
                Assert.Equal("Test Skill", singleSkill.SkillName);
                Assert.Equal(1, singleSkill.Id);
            }

        }

        [Fact]
        public void Job_Add_With_Skill_Relation()
        {
            //----- Arrange -----
            var factory = new ConnectionFactory();

            //get instance of JobBdContext
            var context = factory.CreateContextForInMemory();


            var testSkill1 = new Skill() { SkillName = "Test Skill 1" };
            var testSkill2 = new Skill() { SkillName = "Test Skill 2" };
            ICollection<Skill> testSkills = new List<Skill>();
                testSkills.Add(testSkill1);
                testSkills.Add(testSkill2);


            var testJob1 = new Job() { Name = "Test Job 1", Skills = testSkills };

            //----- Act -----

            var data = context.Jobs.Add(testJob1);
            context.SaveChanges();

            //add second skill to testjob2
            
            var testJob2 = new Job() { Name = "Test Job 2", Skills = testSkills };

            // adding second job to Jobs
            context.Jobs.Add(testJob2);
            context.SaveChanges();


            //----- Assert -----

            //Get job count - verify if created
            var jobCount = context.Jobs.Count();
            if (jobCount != 0)
            {
                Assert.Equal(2, jobCount);
            }

            //get single job detail
            var singleJob = context.Jobs.FirstOrDefault();
            if (singleJob != null)
            {
                Assert.Equal("Test Job 1", singleJob.Name);
                Assert.Equal(2, singleJob.Skills.Count);
            }



            //Get job count
            var newJobCount = context.Jobs.Count();
            if (newJobCount != 0)
            {
                Assert.Equal(2, newJobCount);
            }

        }

        public DatabaseTesting()
		{
		}
	}
}

