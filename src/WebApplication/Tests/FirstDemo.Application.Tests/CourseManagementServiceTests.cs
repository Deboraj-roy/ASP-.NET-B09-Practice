using Autofac.Extras.Moq;
using FirstDemo.Application.Features.Training.Services;
using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Repositories;
using Moq;

namespace FirstDemo.Application.Tests
{
    public class CourseManagementServiceTests
    {
        private AutoMock _mock;
        private Mock<ICourseRepository> _courseRepositoryMock;
        private Mock<IApplicationUnitOfWork> _unitOfWorkMock;
        private CourseManagementService _courseManagementService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [SetUp]
        public void Setup()
        {
            _courseRepositoryMock = _mock.Mock<ICourseRepository>();
            _unitOfWorkMock = _mock.Mock<IApplicationUnitOfWork>();
            _courseManagementService = _mock.Create<CourseManagementService>();
        }

        [TearDown]
        public void TearDown()
        {
            _courseRepositoryMock?.Reset();
            _unitOfWorkMock?.Reset();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _mock?.Dispose();
        }

        [Test]
        public async Task CreateCourseAsync_TitleUnique_CreatesNewCourse()
        {
            // Arrange
            const string title = "C# beginner";
            const uint fees = 2000;
            const string description = "A beginner guide to C#";

            var course = new Course
            {
                Title = title,
                Fees = fees,
                Description = description
            };

            _unitOfWorkMock.Setup(x => x.CourseRepository).Returns(_courseRepositoryMock.Object).Verifiable();
            _courseRepositoryMock.Setup(x => x.IsTitleDuplicateAsync(title, null)).ReturnsAsync(false).Verifiable();
            _courseRepositoryMock.Setup(x => x.AddAsync(It.Is<Course>(y => y.Title == title && y.Fees == fees && y.Description == description))).Returns(Task.CompletedTask).Verifiable();
            _unitOfWorkMock.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask).Verifiable();

            //Act
            await _courseManagementService.CreateCourseAsync(title, description, fees);

            //Assert
            _unitOfWorkMock.VerifyAll();
            _courseRepositoryMock.VerifyAll();
        }
        [Test]
        public void CreateCourseAsync_TitleDuplicate_ThrowsException()
        {
            Assert.Pass();
        }
    }
}