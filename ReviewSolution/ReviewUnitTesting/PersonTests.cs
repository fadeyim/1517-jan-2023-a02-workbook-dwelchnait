using OOPsReview; //is a namespace

namespace ReviewUnitTesting
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_GreedyConstructor_CreateGoodInstance_WithEmployment()
        {
            //arrange
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";

            ResidentAddress address = new ResidentAddress(11,"Bradley St.","","","Edmonton","AB");
            string expectedAddress = address.ToString();

            List<Employment> employments = new List<Employment>();
            employments.Add(new Employment("Programmer", SupervisoryLevel.TeamMember, new DateTime(2014, 08, 24), 5.5));
            employments.Add(new Employment("Programmer", SupervisoryLevel.TeamLeader, new DateTime(2020, 08, 24), 2.5));
            employments.Add(new Employment("Programmer", SupervisoryLevel.Supervisor, new DateTime(2022, 08, 24), 0.5));
            
            List<string> expectedEmployments = new List<string>();
            foreach (var item in employments)
            {
                expectedEmployments.Add(item.ToString());
            }


            //act
            Person thePerson = new Person("Don","Welch",address,employments);

            //assess
            Assert.AreEqual(expectedFirstName, thePerson.FirstName, "Person first name values not as expected: "
               + $"{expectedFirstName} vs {thePerson.FirstName}");
            Assert.AreEqual(expectedLastName, thePerson.LastName, "Person last name values not as expected: "
               + $"{expectedLastName} vs {thePerson.LastName}");
            Assert.AreEqual(expectedAddress, thePerson.Address.ToString(), "Person address values not as expected: "
              + $"{expectedAddress} vs {thePerson.Address.ToString()}");
            
            //Checking Collections
            //if you check the AreEqual assert the documentation indicates that one can compare an object to an object
            //one would think that you could compare one List<T> object vs a second List<T> object
            //HOWEVER the test is against the reference of the object NOT the contents!!!!!
            //SO what needs to be done is to compare contents
            
            //first check is the number of items in the List<T>
            Assert.AreEqual(expectedEmployments.Count,thePerson.EmploymentPositions.Count, "Person Employment position count not as expected: "
               + $"{expectedEmployments.Count} vs {thePerson.EmploymentPositions.Count}");

            for(int i= 0; i < expectedEmployments.Count; i++)
            {
                Assert.AreEqual(expectedEmployments[i], thePerson.EmploymentPositions[i].ToString(), "Person Employment position values not as expected: "
               + $"{expectedEmployments[i]} vs {thePerson.EmploymentPositions[i].ToString()}");
            }

        }
    }
}
