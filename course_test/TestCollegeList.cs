using Xunit;
using course.Models;
using course.Controllers;
using System.Linq;

namespace course_test
{
    public class TestCollegeList
    {
        [Fact]
        public void CountColleges()
        {
            // Arrange
            var repo = new TestCollegeRepo();

            // Act

            // Assert
            Assert.Equal(3, repo.Colleges.ToList().Count);
        }

        [Fact]
        public void CountCoursesPerCollege()
        {
            // Arrange
            var colleges = new TestCollegeRepo();
            var courses = new TestCourseRepo();
            var controller = new CourseController(courses);

            // Act
            int collegeCount = colleges.Colleges.Count();
            string college0 = colleges.Colleges.First().Name;
            string college2 = colleges.Colleges.Last().Name;

            int courseCount0 = (courses.Courses.Count(x=>x.College == college0));
            int courseCount2 = (courses.Courses.Count(x=>x.College == college2));

            // Assert
            Assert.Equal(1, courseCount0);
            Assert.Equal(2, courseCount2);
        }
    }
}
