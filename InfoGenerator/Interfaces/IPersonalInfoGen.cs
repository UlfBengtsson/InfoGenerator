using InfoGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoGenerator.Interfaces
{
    //Personal Information Generation
    public interface IPersonalInfoGen
    {
        static readonly Random randomNumberGen = new Random();

        /// <summary>
        /// Returns a random enum gender.
        /// </summary>
        /// <returns>Random enum Gender</returns>
        Gender RandomGender();

        /// <summary>
        /// Returns the array of all male first names.<br/>
        /// <list type="bullet">
        /// <item>
        /// <term>Array requirement</term>
        /// May not be null or contain null.
        /// </item>
        /// <item>
        /// <term>Array requirement</term>
        /// Minimum of 5 names.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Only unique names / No duplicate names.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Minimum lenght is 2 and maximum is 12.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Only allowed to contain Letters and one Dash (-) between double names.
        /// </item>
        /// </list>
        /// </summary>
        /// <returns>string array of all male first names</returns>
        string[] MaleFirstNames();

        /// <summary>
        /// Returns the array of all female first names.<br/>
        /// <list type="bullet">
        /// <item>
        /// <term>Array requirement</term>
        /// May not be null or contain null.
        /// </item>
        /// <item>
        /// <term>Array requirement</term>
        /// Minimum of 5 names.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Only unique names / No duplicate names.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Minimum lenght is 2 and maximum is 12.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Only allowed to contain Letters and one Dash (-) between double names.
        /// </item>
        /// </list>
        /// </summary>
        /// <returns>string array of all female first names</returns>
        string[] FemaleFirstNames();

        /// <summary>
        /// Returns the array of all last names.<br/>
        /// <list type="bullet">
        /// <item>
        /// <term>Array requirement</term>
        /// May not be null or contain null.
        /// </item>
        /// <item>
        /// <term>Array requirement</term>
        /// Minimum of 5 names.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Only unique names / No duplicate names.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Minimum lenght is 2 and maximum is 12.
        /// </item>
        /// <item>
        /// <term>Names restrictions</term>
        /// Only allowed to contain Letters.
        /// </item>
        /// </list>
        /// </summary>
        /// <returns>string array of all last names</returns>
        string[] LastNames();


        /// <summary>
        /// Random generates a first name of any gender.
        /// </summary>
        /// <returns>string with a first name of any gender</returns>
        string FirstName();

        /// <summary>
        /// Random generates a <paramref name="gender"/> specific first name.
        /// </summary>
        /// <returns>string with a <paramref name="gender"/> specific first name</returns>
        string FirstName(Gender gender);

        /// <summary>
        /// Returns a random list of first names.<br/>
        /// amount of names are specified by <paramref name="amount"/>
        /// </summary>
        /// <returns>string list of random first names</returns>
        /// <param name="amount">Amount of names desired</param>
        /// <exception cref="ArgumentException"> if <paramref name="amount"/> is zero or negative.</exception>
        List<string> FirstNames(int amount);

        /// <summary>
        /// Returns a random list of <paramref name="gender"/> specific first names.<br/>
        /// amount of names are specified by <paramref name="amount"/>
        /// </summary>
        /// <returns>string list of random <paramref name="gender"/> specific first names</returns>
        /// <param name="amount">Amount of names desired</param>
        /// <param name="gender">desired gender</param>
        /// <exception cref="ArgumentException">if <paramref name="amount"/> is zero or negative.</exception>
        List<string> FirstNames(int amount, Gender gender);


        /// <summary>
        /// Random generates a last name.
        /// </summary>
        /// <returns>string with last name</returns>
        string LastName();

        /// <summary>
        /// Returns a random list of last names.<br/>
        /// amount of names are specified by <paramref name="amount"/>
        /// </summary>
        /// <returns>string list of random last names</returns>
        /// <param name="amount">Amount of names desired</param>
        /// <exception cref="ArgumentException">if <paramref name="amount"/> is zero or negative.</exception>
        List<string> LastNames(int amount);


        /// <summary>
        /// Random generates a full name (First name(any gender) space then Last name.)
        /// </summary>
        /// <returns>string with full name</returns>
        string FullName();

        /// <summary>
        /// Random generates a <paramref name="gender"/> specific full name (First name(<paramref name="gender"/> specific) space then Last name.)
        /// </summary>
        /// <returns>string with <paramref name="gender"/> specific full name</returns>
        string FullName(Gender gender);

        /// <summary>
        /// Returns a random list of full names.<br/>
        /// amount of full names are specified by <paramref name="amount"/>
        /// </summary>
        /// <returns>string list of random full names</returns>
        /// <param name="amount">Amount of full names desired</param>
        /// <exception cref="ArgumentException">if <paramref name="amount"/> is zero or negative.</exception>
        List<string> FullNames(int amount);

        /// <summary>
        /// Returns a random list of <paramref name="gender"/> specific full names.<br/>
        /// amount of <paramref name="gender"/> specific full names are specified by <paramref name="amount"/>
        /// </summary>
        /// <returns>string list of random <paramref name="gender"/> specific full names</returns>
        /// <param name="amount">Amount of <paramref name="gender"/> specific full names desired</param>
        /// <exception cref="ArgumentException">if <paramref name="amount"/> is zero or negative.</exception>
        List<string> FullNames(int amount, Gender gender);

     

        /// <summary>
        /// Makes a dictionary were lists of random full names are grouped by gender.<br/>
        /// <paramref name="amountOfNames"/> defines the amount of names to be generated.<br/>
        /// if <paramref name="perGender"/> is True = <paramref name="amountOfNames"/> is per gender | False = <paramref name="amountOfNames"/> is total for the dictionary
        /// </summary>
        /// <param name="amountOfNames">defines the amount of names to be generated</param>
        /// <param name="perGender"> True = <paramref name="amountOfNames"/> is per gender | False = <paramref name="amountOfNames"/> is total for the dictionary</param>
        /// <returns>Dictionary were lists of random full names are grouped by gender</returns>
        Dictionary<Gender, List<string>> GenderSplitedFullNames(int amountOfNames, bool perGender);

    }
}
