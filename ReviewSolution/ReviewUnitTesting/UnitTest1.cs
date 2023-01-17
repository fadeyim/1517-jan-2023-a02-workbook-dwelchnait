using OOPsReview;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReviewUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Employment_CreateGoodDefaultConstructor()
        {
            //Arrange
            //this is where one would setup any required data need for the testing
            string expectedTitle = "Unknown";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamMember;
            double expectedYears = 0.0;

            //Act
            //this is the execution of the item being tested
            Employment employment = new Employment();   

            //Assess
            //this area is where you check the results of your Act
            Assert.AreEqual(expectedTitle, employment.Title,"Default employment title values not as expected: "
                + $"{expectedTitle} vs {employment.Title}");
            Assert.AreEqual(expectedLevel, employment.Level, "Default emoployment level values not as expected: "
                 + $"{expectedLevel} vs {employment.Level}");

            Assert.AreEqual(expectedYears, employment.Years, "Default emoployment years values not as expected: "
                 + $"{expectedYears} vs {employment.Years}");

        }
    }
}