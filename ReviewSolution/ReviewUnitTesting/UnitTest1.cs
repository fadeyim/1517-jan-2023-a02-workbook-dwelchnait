using OOPsReview; //is a namespace
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

        [TestMethod]
        [DataRow("Unit Test Designer",SupervisoryLevel.TeamLeader,5.5)]
        public void Employment_CreateGoodGreedyConstructor(string title, SupervisoryLevel level, double years)
        {
            //Arrange
            string expectedTitle = "Unit Test Designer";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamLeader;
            double expectedYears = 5.5;

            //Act
            Employment employment = new Employment(title, level, years);

            //Assess
            Assert.AreEqual(expectedTitle, employment.Title, "Default employment title values not as expected: "
                + $"{expectedTitle} vs {employment.Title}");
            Assert.AreEqual(expectedLevel, employment.Level, "Default emoployment level values not as expected: "
                 + $"{expectedLevel} vs {employment.Level}");

            Assert.AreEqual(expectedYears, employment.Years, "Default emoployment years values not as expected: "
                 + $"{expectedYears} vs {employment.Years}");
        }

        [TestMethod]
        [DataRow(" ", SupervisoryLevel.TeamLeader, 5.5)]
        [DataRow(null, SupervisoryLevel.TeamLeader, 5.5)]
        [DataRow("Negative Year ", SupervisoryLevel.TeamLeader, -5.5)]
        public void Employment_GreedyConstructor_BadData_NotMade(string title, SupervisoryLevel level, double years)
        {
            try
            {
                //Arrange
               
                //the instance should not exist, thus no values for comparison

                //Act
                Employment employment = new Employment(title, level, years);

                //Assess
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch(ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("required"));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("0.0 or greater"));
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contains no message.");
            }
        }

        [TestMethod]
        [DataRow(SupervisoryLevel.Entry)]
        public void Employee_SetSupervisoryLevel_Good(SupervisoryLevel level)
        {
            //Arrange
            Employment employment = new Employment("Boss", SupervisoryLevel.DepartmentHead, 3.5);

            //Act
            employment.SetEmploymentResponsibilityLevel(SupervisoryLevel.Entry);

            //Assess
            Assert.IsTrue(SupervisoryLevel.Entry == employment.Level,
                        $"Employment level of {employment.Level} is incorrect. Should be {level}");
        }
    }
}