using OOPsReview; //is a namespace
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReviewUnitTesting
{
    [TestClass]
    public class EmploymentTests
    {
        [TestMethod]
        public void Employment_CreateGoodDefaultConstructor()
        {
            //Arrange
            //this is where one would setup any required data need for the testing
            string expectedTitle = "Unknown";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamMember;
            double expectedYears = 0.0;
            DateTime expectedStartDate = DateTime.Parse("2023,01,23");

            //Act
            //this is the execution of the item being tested
            Employment employment = new Employment();   

            //Assess
            //this area is where you check the results of your Act
            Assert.AreEqual(expectedTitle, employment.Title,"Default employment title values not as expected: "
                + $"{expectedTitle} vs {employment.Title}");
            Assert.AreEqual(expectedLevel, employment.Level, "Default employment level values not as expected: "
                 + $"{expectedLevel} vs {employment.Level}");

            Assert.AreEqual(expectedYears, employment.Years, "Default employment years values not as expected: "
                 + $"{expectedYears} vs {employment.Years}");
            Assert.AreEqual(expectedStartDate, employment.StartDate, "Default employment years values not as expected: "
                 + $"{expectedStartDate} vs {employment.StartDate}");

        }

        [TestMethod]
        [DataRow("Unit Test Designer",SupervisoryLevel.TeamLeader,"2017-08-23",5.5)]
        public void Employment_CreateGoodGreedyConstructor(string title, SupervisoryLevel level, 
            string startdate, double years)
        {
            //Arrange
            string expectedTitle = "Unit Test Designer";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamLeader;
            double expectedYears = 5.5;
            DateTime expectedStartDate = DateTime.Parse(startdate);

            //Act
            Employment employment = new Employment(title, level, DateTime.Parse(startdate), years);

            //Assess
            Assert.AreEqual(expectedTitle, employment.Title, "Employment title values not as expected: "
                + $"{expectedTitle} vs {employment.Title}");
            Assert.AreEqual(expectedLevel, employment.Level, "Employment level values not as expected: "
                 + $"{expectedLevel} vs {employment.Level}");

            Assert.AreEqual(expectedYears, employment.Years, "Employment years values not as expected: "
                 + $"{expectedYears} vs {employment.Years}");
            Assert.AreEqual(expectedStartDate, employment.StartDate, "Employment years values not as expected: "
                + $"{expectedStartDate} vs {employment.StartDate}");
        }

        [TestMethod]
        [DataRow(" ", SupervisoryLevel.TeamLeader, "2017-08-23", 5.5)] //blank in title
        [DataRow(null, SupervisoryLevel.TeamLeader, "2017-08-23", 5.5)] // null title
        [DataRow("Bad Level value", (SupervisoryLevel)111, "2017-08-23", 5.5)] //bad enum value
        [DataRow("Future Date", SupervisoryLevel.TeamLeader, "2027-08-23", 5.5)] //bad year
        [DataRow("Negative Year ", SupervisoryLevel.TeamLeader, "2017-08-23", -5.5)] //bad year
        public void Employment_GreedyConstructor_BadData_NotMade(string title, 
            SupervisoryLevel level, string startdate, double years)
        {
            try
            {
                //Arrange
                DateTime StartDate = DateTime.Parse(startdate);

                //the instance should not exist, thus no values for comparison

                //Act
                Employment employment = new Employment(title, level, StartDate, years);

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
            catch (ArgumentException ex)
            {
                //depending on how the key word exists in your message, the test may or may not
                //  be correct simply because of mix case letters
                //A technique to avoid this is to make the entire message either all upper case
                //  or lower case and the matching string pattern the same case
                Assert.IsTrue(ex.Message.ToUpper().Contains("INVALID"));
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contains no message.");
            }
        }

        [TestMethod]
        [DataRow(SupervisoryLevel.Entry)]
        public void Employment_SetSupervisoryLevel_Good(SupervisoryLevel level)
        {
            //Arrange
            Employment employment = new Employment("Boss", SupervisoryLevel.DepartmentHead,
                DateTime.Parse("2019-08-23"),3.5);

            //Act
            employment.SetEmploymentResponsibilityLevel(SupervisoryLevel.Entry);

            //Assess
            Assert.IsTrue(SupervisoryLevel.Entry == employment.Level,
                        $"Employment level of {employment.Level} is incorrect. Should be {level}");
        }

        [TestMethod]
        [DataRow((SupervisoryLevel)111)]
        public void Employment_SetSupervisoryLevel_Bad(SupervisoryLevel level)
        {
            try
            {
                //Arrange
                Employment employment = new Employment("Boss", SupervisoryLevel.DepartmentHead,
                    DateTime.Parse("2019-08-23"), 3.5);

                //Act
                employment.SetEmploymentResponsibilityLevel(level);

                //Assess
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentException ex)
            {
                //depending on how the key word exists in your message, the test may or may not
                //  be correct simply because of mix case letters
                //A technique to avoid this is to make the entire message either all upper case
                //  or lower case and the matching string pattern the same case
                Assert.IsTrue(ex.Message.ToUpper().Contains("INVALID"));
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contains no message.");
            }
        }

        [TestMethod]
        public void Employment_GoodToString()
        {
            //arrange
            Employment employmentToString = new Employment("Boss", SupervisoryLevel.DepartmentHead,
                DateTime.Parse("2019-08-23"), 3.5);
            string expectedToString = "Boss,DepartmentHead,Aug 23 2019,3.5";

            //act
            string actToString = employmentToString.ToString();

            //assess
            Assert.AreEqual(expectedToString, actToString, "Employment ToString values are not as expected:" +
                $"{expectedToString} vs {actToString}");
        }
    }
}