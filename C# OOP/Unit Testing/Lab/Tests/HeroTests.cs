using Moq;
using NUnit.Framework;
using Skeleton;
using Tests.Fakes;

namespace Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroShouldGainExperienceIfTargetDies()
        {
            const int experience = 100;

            // Arrange
            var fakeWeapon = Mock.Of<IWeapon>(); // Директно създава мокнат обект, на който всичките му поведения са празни. 
                                                  // Използваме го, когато създаваме празен обект, не ни е нужно да имплементираме някакво поведение
            
            Mock<ITarget> fakeTarget = new Mock<ITarget>(); // Използваме го за създаване фейк обект, на който трябва да подменяме/да сетнем някакво конкретно поведение
                                                            // Методите (който подменяме и новия, с който подменяме) трябва да са с еднаква сигнатура

            fakeTarget                              // Callback се извиква при Void, иначе - Returns
                .Setup(t => t.IsDead())
                .Returns(true);

            fakeTarget
                .Setup(t => t.Health)
                .Returns(0);

            fakeTarget
                .Setup(t => t.GiveExperience())
                .Returns(experience);
            
            Hero hero = new Hero("TestHero", fakeWeapon);

            // Act
            hero.Attack(fakeTarget.Object);

            // Assert
            Assert.That(hero.Experience, Is.EqualTo(experience));
        }
    }
}
