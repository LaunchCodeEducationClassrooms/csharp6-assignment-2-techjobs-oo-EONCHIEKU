using System.Data;
using System.Xml.Linq;
using TechJobsOOAutoGraded6;

namespace TechJobs.Tests
{
	[TestClass]
	public class JobTests
	{
        //Testing Objects
        //initalize your testing objects here
        Job job1 = new Job();

        Job job2 = new Job();

        Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        Job job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreNotEqual(job1.Id, job2.Id);
            Assert.IsTrue(job2.Id - job1.Id == 1);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {

            Assert.IsTrue("Product tester" == job3.Name );
            Assert.IsTrue("ACME" == job3.EmployerName.Value);
            Assert.IsTrue("Desert" == job3.EmployerLocation.Value);
            Assert.IsTrue("Quality control" == job3.JobType.Value);
            Assert.IsTrue("Persistence" == job3.JobCoreCompetency.Value);

        }
        [TestMethod]
        public void TestJobsForEquality()
        {
           Assert.IsFalse(job3.Equals(job4));        
        }
        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {

            Assert.IsTrue(job3.ToString().StartsWith(Environment.NewLine)); 
            Assert.IsTrue(job3.ToString().EndsWith(Environment.NewLine));
        }
        //TODO: Task 4: remove this method before you create your first test method
        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            
            string correctLabels = $"{Environment.NewLine}" +
                $"ID: {job3.Id}{Environment.NewLine}" +
                $"Name: {job3.Name}{Environment.NewLine}" +
                $"Employer: {job3.EmployerName.Value}{Environment.NewLine}" +
                $"Location: {job3.EmployerLocation.Value}{Environment.NewLine}" +
                $"Position Type: {job3.JobType.Value}{Environment.NewLine}" +
                $"Core Competency: {job3.JobCoreCompetency.Value}{Environment.NewLine}";
            Assert.IsTrue(job3.ToString().Equals(correctLabels));

            //... more job objects to follow

        }
        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            string testingEmptyField = $"{Environment.NewLine}" +
                $"ID: {job3.Id}{Environment.NewLine}" +
                $"Name: Data not available{Environment.NewLine}" +
                $"Employer: Data not available{Environment.NewLine}" +
                $"Location: Data not available{Environment.NewLine}" +
                $"Position Type: {job3.JobType.Value}{Environment.NewLine}" +
                $"Core Competency: {job3.JobCoreCompetency.Value}{Environment.NewLine}";


             job3.Name = "";
            job3.EmployerName.Value = "";
            job3.EmployerLocation.Value = "";
            Assert.IsTrue(job3.ToString().Equals(testingEmptyField));


        }
    }
}

