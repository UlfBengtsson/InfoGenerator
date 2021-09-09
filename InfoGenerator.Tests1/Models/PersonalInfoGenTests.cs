using Xunit;
using System.Linq;
using InfoGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using InfoGenerator.Interfaces;

namespace InfoGenerator.Models.Tests
{
    public class PersonalInfoGenTests
    {
        private const string FIRSTNAMEREGEX = @"^[a-zA-Z|å|Å|ä|Ä|ö|Ö]+((\-)[a-zA-Z|å|Å|ä|Ä|ö|Ö]+)?$";//Only letters and only one dash if its a double name.
        private const string LASTNAMEREGEX = @"^[a-zA-Z|å|Å|ä|Ä|ö|Ö]+?$";//Only letters.

        private readonly IPersonalInfoGen personalInfoGen;

        public PersonalInfoGenTests()
        {
            personalInfoGen = new PersonalInfoGen();
        }

        //--------------------- Gen Gender -------------------------------------------------------------

        [Fact()]
        public void RandomGenderTest()
        {
            //Arrange
            int sampelSize = 100;
            int maleCount = 0;
            int femaleCount = 0;

            //Act
            for (int i = 0; i < sampelSize; i++)
            {
                Gender gender = personalInfoGen.RandomGender();
                if (gender == Gender.Female)
                {
                    femaleCount++;
                }
                else
                {
                    maleCount++;
                }
            }

            //Assert
            Assert.NotEqual(0, femaleCount);// can it random a Female?
            Assert.NotEqual(0, maleCount);  // can it random a Male?
            Assert.InRange(femaleCount, (sampelSize * 0.4), (sampelSize * 0.6));// 10% offset from clean 50/50 split
            Assert.InRange(maleCount, (sampelSize * 0.4), (sampelSize * 0.6));  // 10% offset from clean 50/50 split
        }

        //--------------------- Array´s ----------------------------------------------------------------

        [Fact()]
        public void ArrayRequiermentsFemaleFirstNamesTest()
        {
            //Arrange
            int arrayMinLength = 5;

            //Act
            string[] result = personalInfoGen.FemaleFirstNames();

            //Assert
            Assert.NotEmpty(result);
            Assert.DoesNotContain(null, result);
            Assert.True(arrayMinLength <= result.Length);
        }

        [Fact()]
        public void ArrayRequiermentsMaleFirstNamesTest()
        {
            //Arrange
            int arrayMinLength = 5;

            //Act
            string[] result = personalInfoGen.MaleFirstNames();

            //Assert
            Assert.NotEmpty(result);
            Assert.DoesNotContain(null, result);
            Assert.True(arrayMinLength <= result.Length);
        }

        [Fact()]
        public void ArrayRequiermentsLastNamesTest()
        {
            //Arrange
            int arrayMinLength = 5;

            //Act
            string[] result = personalInfoGen.LastNames();

            //Assert
            Assert.NotEmpty(result);
            Assert.DoesNotContain(null, result);
            Assert.True(arrayMinLength <= result.Length);
        }

        [Fact()]
        public void ArrayMaleFirstNamesRestrictionsTest()
        {
            //Arrange
            int minNameLength = 2;
            int maxNameLength = 12;
            int distinctListCount = 0;

            //Act
            string[] result = personalInfoGen.MaleFirstNames();
            List<string> distinctList = new List<string>(result);
            distinctListCount = distinctList.Distinct().Count();

            //Assert
            Assert.Equal(result.Length, distinctListCount);
            Assert.All(result, element =>
            {
                Assert.True(element.Length >= minNameLength && element.Length <= maxNameLength);
                Assert.Matches(FIRSTNAMEREGEX, element);
            }
            );
        }

        [Fact()]
        public void ArrayFemaleFirstNamesRestrictionsTest()
        {
            //Arrange
            int minNameLength = 2;
            int maxNameLength = 12;
            int distinctListCount = 0;

            //Act
            string[] result = personalInfoGen.FemaleFirstNames();
            List<string> distinctList = new List<string>(result);
            distinctListCount = distinctList.Distinct().Count();

            //Assert
            Assert.Equal(result.Length, distinctListCount);
            Assert.All(result, element =>
            {
                Assert.True(element.Length >= minNameLength && element.Length <= maxNameLength);
                Assert.Matches(FIRSTNAMEREGEX, element);
            }
            );
        }

        [Fact()]
        public void ArrayLastNamesRestrictionsTest()
        {
            //Arrange
            int minNameLength = 2;
            int maxNameLength = 12;
            int distinctListCount = 0;

            //Act
            string[] result = personalInfoGen.LastNames();
            List<string> distinctList = new List<string>(result);
            distinctListCount = distinctList.Distinct().Count();

            //Assert
            Assert.Equal(result.Length, distinctListCount);
            Assert.All(result, element =>
            {
                Assert.True(element.Length >= minNameLength && element.Length <= maxNameLength);
                Assert.Matches(LASTNAMEREGEX, element);
            }
            );
        }

        //--------------------- Gen a Name -------------------------------------------------------------

        [Fact()]
        public void FirstNameTest()
        {
            //Arrange
            string[] allMaleNames = personalInfoGen.MaleFirstNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();
            List<string> allFirstNames = new List<string>(allFemaleNames);
            allFirstNames.AddRange(allMaleNames);

            //Act
            string result1 = personalInfoGen.FirstName();
            string result2 = personalInfoGen.FirstName();
            string result3 = personalInfoGen.FirstName();

            //Assert
            Assert.NotEmpty(result1);
            Assert.NotEmpty(result2);
            Assert.NotEmpty(result3);
            Assert.Contains(result1, allFirstNames);
            Assert.Contains(result2, allFirstNames);
            Assert.Contains(result3, allFirstNames);
        }

        [Fact()]
        public void FemaleFirstNameTest()
        {
            //Arrange
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();

            //Act
            string result1 = personalInfoGen.FirstName(Gender.Female);
            string result2 = personalInfoGen.FirstName(Gender.Female);
            string result3 = personalInfoGen.FirstName(Gender.Female);

            //Assert
            Assert.NotEmpty(result1);
            Assert.NotEmpty(result2);
            Assert.NotEmpty(result3);
            Assert.Contains(result1, allFemaleNames);
            Assert.Contains(result2, allFemaleNames);
            Assert.Contains(result3, allFemaleNames);
        }

        [Fact()]
        public void MaleFirstNameTest()
        {
            //Arrange
            string[] allMaleNames = personalInfoGen.MaleFirstNames();

            //Act
            string result1 = personalInfoGen.FirstName(Gender.Male);
            string result2 = personalInfoGen.FirstName(Gender.Male);
            string result3 = personalInfoGen.FirstName(Gender.Male);

            //Assert
            Assert.NotEmpty(result1);
            Assert.NotEmpty(result2);
            Assert.NotEmpty(result3);
            Assert.Contains(result1, allMaleNames);
            Assert.Contains(result2, allMaleNames);
            Assert.Contains(result3, allMaleNames);
        }

        [Fact()]
        public void LastNameTest()
        {
            //Arrange
            string[] allLastNames = personalInfoGen.LastNames();

            //Act
            string result1 = personalInfoGen.LastName();
            string result2 = personalInfoGen.LastName();
            string result3 = personalInfoGen.LastName();

            //Assert
            Assert.NotEmpty(result1);
            Assert.NotEmpty(result2);
            Assert.NotEmpty(result3);
            Assert.Contains(result1, allLastNames);
            Assert.Contains(result2, allLastNames);
            Assert.Contains(result3, allLastNames);
        }

        //--------------------- Gen List of Names -------------------------------------------------------

        [Fact()]
        public void FirstNamesListTest()
        {
            //Arrange
            string[] allMaleNames = personalInfoGen.MaleFirstNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();
            List<string> allFirstNames = new List<string>(allFemaleNames);
            allFirstNames.AddRange(allMaleNames);

            //Act
            List<string> result = personalInfoGen.FirstNames(3);

            //Assert
            Assert.NotEmpty(result);
            Assert.All(result, element =>
            {
                Assert.Contains(element, allFirstNames);
            }
            );

        }

        [Fact()]
        public void FirstNamesListGenderFemaleTest()
        {
            //Arrange
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();

            //Act
            List<string> result = personalInfoGen.FirstNames(3, Gender.Female);

            //Assert
            Assert.NotEmpty(result);
            Assert.All(result, element =>
            {
                Assert.Contains(element, allFemaleNames);
            });
        }

        [Fact()]
        public void FirstNamesListGenderMaleTest()
        {
            //Arrange
            string[] allMaleNames = personalInfoGen.MaleFirstNames();

            //Act
            List<string> result = personalInfoGen.FirstNames(3, Gender.Male);

            //Assert
            Assert.NotEmpty(result);
            Assert.All(result, element =>
            {
                Assert.Contains(element, allMaleNames);
            });
        }

        [Fact()]
        public void LastNamesListTest()
        {
            //Arrange
            string[] allLastNames = personalInfoGen.LastNames();

            //Act
            List<string> result = personalInfoGen.LastNames(3);

            //Assert
            Assert.NotEmpty(result);
            Assert.All(result, element =>
            {
                Assert.Contains(element, allLastNames);
            });
        }

        //--------------------- Gen Full Name(s) -------------------------------------------------------

        [Fact()]
        public void FullNameTest()
        {
            //Arrange
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allMaleNames = personalInfoGen.MaleFirstNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();
            List<string> allFirstNames = new List<string>(allFemaleNames);
            allFirstNames.AddRange(allMaleNames);

            //Act
            string[] name1Split = personalInfoGen.FullName().Split(' ');
            string[] name2Split = personalInfoGen.FullName().Split(' ');
            string[] name3Split = personalInfoGen.FullName().Split(' ');

            //Assert
            Assert.Contains(name1Split[0], allFirstNames);
            Assert.Contains(name2Split[0], allFirstNames);
            Assert.Contains(name3Split[0], allFirstNames);

            Assert.Contains(name1Split[1], allLastNames);
            Assert.Contains(name2Split[1], allLastNames);
            Assert.Contains(name3Split[1], allLastNames);
        }

        [Fact()]
        public void FullNameGenderFemaleTest()
        {
            //Arrange
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();

            //Act
            string[] name1Split = personalInfoGen.FullName(Gender.Female).Split(' ');
            string[] name2Split = personalInfoGen.FullName(Gender.Female).Split(' ');
            string[] name3Split = personalInfoGen.FullName(Gender.Female).Split(' ');

            //Assert
            Assert.Contains(name1Split[0], allFemaleNames);
            Assert.Contains(name2Split[0], allFemaleNames);
            Assert.Contains(name3Split[0], allFemaleNames);

            Assert.Contains(name1Split[1], allLastNames);
            Assert.Contains(name2Split[1], allLastNames);
            Assert.Contains(name3Split[1], allLastNames);
        }

        [Fact()]
        public void FullNameGenderMaleTest()
        {
            //Arrange
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allMaleNames = personalInfoGen.MaleFirstNames();

            //Act
            string[] name1Split = personalInfoGen.FullName(Gender.Male).Split(' ');
            string[] name2Split = personalInfoGen.FullName(Gender.Male).Split(' ');
            string[] name3Split = personalInfoGen.FullName(Gender.Male).Split(' ');

            //Assert
            Assert.Contains(name1Split[0], allMaleNames);
            Assert.Contains(name2Split[0], allMaleNames);
            Assert.Contains(name3Split[0], allMaleNames);

            Assert.Contains(name1Split[1], allLastNames);
            Assert.Contains(name2Split[1], allLastNames);
            Assert.Contains(name3Split[1], allLastNames);
        }

        [Fact()]
        public void FullNamesListTest()
        {
            //Arrange
            int amount = 3;
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allMaleNames = personalInfoGen.MaleFirstNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();
            List<string> allFirstNames = new List<string>(allFemaleNames);
            allFirstNames.AddRange(allMaleNames);

            //Act
            List<string> result = personalInfoGen.FullNames(amount);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(amount, result.Count);
            Assert.All(result, element =>
            {
                string[] nameSplit = element.Split(' ');
                Assert.Contains(nameSplit[0], allFirstNames);
                Assert.Contains(nameSplit[1], allLastNames);
            });
        }

        [Fact()]
        public void FullNamesListGenderMaleTest()
        {
            //Arrange
            int amount = 3;
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allMaleNames = personalInfoGen.MaleFirstNames();

            //Act
            List<string> result = personalInfoGen.FullNames(amount, Gender.Male);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(amount, result.Count);
            Assert.All(result, element =>
            {
                string[] nameSplit = element.Split(' ');
                Assert.Contains(nameSplit[0], allMaleNames);
                Assert.Contains(nameSplit[1], allLastNames);
            });
        }

        [Fact()]
        public void FullNamesGenderFemaleTest()
        {
            //Arrange
            int amount = 3;
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();

            //Act
            List<string> result = personalInfoGen.FullNames(amount, Gender.Female);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(amount, result.Count);
            Assert.All(result, element =>
            {
                string[] nameSplit = element.Split(' ');
                Assert.Contains(nameSplit[0], allFemaleNames);
                Assert.Contains(nameSplit[1], allLastNames);
            });
        }

        //--------------------- Gen Gender Dictionary Full Name(s) -------------------------------------

        [Fact()]
        public void GenderSplitedFullNamesTotalAmountTest()
        {
            //Arrange
            int amount = 10;
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allMaleNames = personalInfoGen.MaleFirstNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();
            List<string> femaleList = null;
            List<string> maleList = null;

            //Act
            Dictionary<Gender, List<string>> result = personalInfoGen.GenderSplitedFullNames(amount, false);
            result.TryGetValue(Gender.Female, out femaleList);
            result.TryGetValue(Gender.Male, out maleList);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(amount, (femaleList.Count + maleList.Count));
            Assert.All(femaleList, element =>
            {
                string[] nameSplit = element.Split(' ');
                Assert.Contains(nameSplit[0], allFemaleNames);
                Assert.Contains(nameSplit[1], allLastNames);
            });
            Assert.All(maleList, element =>
            {
                string[] nameSplit = element.Split(' ');
                Assert.Contains(nameSplit[0], allMaleNames);
                Assert.Contains(nameSplit[1], allLastNames);
            });
        }

        [Fact()]
        public void GenderSplitedFullNamesAmountPerGenderTest()
        {
            //Arrange
            int amount = 10;
            string[] allLastNames = personalInfoGen.LastNames();
            string[] allMaleNames = personalInfoGen.MaleFirstNames();
            string[] allFemaleNames = personalInfoGen.FemaleFirstNames();
            List<string> femaleList = null;
            List<string> maleList = null;

            //Act
            Dictionary<Gender, List<string>> result = personalInfoGen.GenderSplitedFullNames(amount, true);
            result.TryGetValue(Gender.Female, out femaleList);
            result.TryGetValue(Gender.Male, out maleList);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(amount, femaleList.Count);
            Assert.Equal(amount, maleList.Count);
            Assert.All(femaleList, element =>
            {
                string[] nameSplit = element.Split(' ');
                Assert.Contains(nameSplit[0], allFemaleNames);
                Assert.Contains(nameSplit[1], allLastNames);
            });
            Assert.All(maleList, element =>
            {
                string[] nameSplit = element.Split(' ');
                Assert.Contains(nameSplit[0], allMaleNames);
                Assert.Contains(nameSplit[1], allLastNames);
            });
        }
    }
}