namespace LearningSystem.Test.Services
{
    using FluentAssertions;
    using Xunit;

    class CourseServiceTest 
    {
        [Fact]
        public void SomeTest()
        {
            //ot FluentAssertions, moga kaja: .Should ..
            var a = 1;
            a.Should().BeGreaterOrEqualTo(2); //fail-va s nqkakva greshka
        }

    }
}
