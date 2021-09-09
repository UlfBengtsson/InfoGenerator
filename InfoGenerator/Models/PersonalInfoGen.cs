using InfoGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoGenerator.Models
{
    public class PersonalInfoGen : IPersonalInfoGen
    {
        string[] fNames;
        string[] mNames;
        string[] lNames;

        public Gender RandomGender()
        {
            throw new NotImplementedException();
        }

        public string[] FemaleFirstNames()
        {
            throw new NotImplementedException();
        }

        public string[] MaleFirstNames()
        {
            throw new NotImplementedException();
        }

        public string[] LastNames()
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }

        public List<string> LastNames(int amount)
        {
            throw new NotImplementedException();
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public string FirstName(Gender gender)
        {
            throw new NotImplementedException();
        }

        public List<string> FirstNames(int amount)
        {
            throw new NotImplementedException();
        }

        public List<string> FirstNames(int amount, Gender gender)
        {
            throw new NotImplementedException();
        }

        public string FullName()
        {
            throw new NotImplementedException();
        }

        public string FullName(Gender gender)
        {
            throw new NotImplementedException();
        }

        public List<string> FullNames(int amount)
        {
            throw new NotImplementedException();
        }

        public List<string> FullNames(int amount, Gender gender)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Gender, List<string>> GenderSplitedFullNames(int amountOfNames, bool perGender)
        {
            throw new NotImplementedException();
        }

    }
}
