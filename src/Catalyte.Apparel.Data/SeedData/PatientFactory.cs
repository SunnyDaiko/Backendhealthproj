using Catalyte.Apparel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalyte.Apparel.Data.SeedData
{
    public class PatientFactory
    {
        private Random _rand = new Random();

        private List<string> _genders = new List<string> { "Male", "Female", "Other" };
        private List<string> _states = new List<string> {  "AL", "AK", "AZ", "AR", "CA",
        "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN",
        "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI",
        "MN", "MS", "MO", "MT", "NE", "NV", "NH",
        "NJ", "NM", "NY", "NC", "ND", "OH", "OK",
        "OR", "PA", "RI", "SC", "SD", "TN", "TX",
        "UT", "VT", "VA", "WA", "WV", "WI", "WY"  };

        private List<string> _insurances = new List<string> { "United Health", "Kaiser Foudation", "Anthem Inc.", "Centene Corporation", "Humana",
            "CVS Health", "Health Care Service Corporation (HCSC)", "CIGNA", "Molina Healthcare",
            "Independence Health Group", "Blue Cross Blue Shield", "Carefirst Inc." };

        private List<string> _firstName = new List<string>  {"John","Emma","Michael","Olivia","William","Ava","James","Sophia",
        "Alejandro","Isabella","Mateo","Camila","Sebastian","Luna","Diego","Valentina","Kwame","Aisha","Jabari","Zahara","Ade",
        "Ayana","Obi","Nia","Hiroshi","Yumi","Ji-hoon","Soo-Min","Ravi","Mei","Raj","Asha","Ahmed","Layla","Omar","Zara","Ali",
        "Leila","Amir","Fatima" };
        private List<string> _lastName = new List<string> { "Smith","Johnson","Williams","Brown","Jones","Miller","Davis","Taylor","Clark",
        "Abimbola","Okafor","Sowande","Diop","Keita","Nkrumah","Mandela","Nkosi","Nyong'o","Azikiwe","Li","Wang","Chen","Zhang","Hall",
        "Liu","Huang","Kim","Park","Lee","Nguyen","Abdullah","Ahmed","Hassan","Khan","Ali","Mohammed","Rahman","Said","Hussein","Omar" };


        public List<Patient> GenerateRandomPatients(int numberOfPatients)
        {
            var patientList = new List<Patient>();

            for (int i = 0; i < numberOfPatients; i++)
            {
                patientList.Add(CreateRandomPatient(i + 1));
            }

            return patientList;
        }

        private Patient CreateRandomPatient(int id)
        {
            string firstName = GetRandomFirstName();
            string lastName = GetRandomLastName();

            return new Patient
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                SSN = GenerateRandomSSN(),
                Email = GenerateRandomEmail(firstName, lastName),
                Street = GenerateRandomString(10),
                City = GenerateRandomString(8),
                State = GetRandomState(),
                ZipCode = GenerateRandomZipCode(),
                Age = GenerateRandomAge(),
                Height = GenerateRandomHeight(),
                Weight = GenerateRandomWeight(),
                Insurance = GetRandomInsurance(),
                Gender = GetRandomGender(),
            };
        }


        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_rand.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomSSN()
        {
            var ssnBuilder = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                ssnBuilder.Append(_rand.Next(0, 10));
                if (i == 2 || i == 4)
                {
                    ssnBuilder.Append("-");
                }
            }
            return ssnBuilder.ToString();
        }

        private string GenerateRandomEmail(string firstName, string lastName)
        {
            var emailBuilder = new StringBuilder();
            emailBuilder.Append(firstName.ToLower());
            emailBuilder.Append(".");
            emailBuilder.Append(lastName.ToLower());
            emailBuilder.Append("@example.com");
            return emailBuilder.ToString();
        }


        private string GenerateRandomZipCode()
        {
            return _rand.Next(10000, 100000).ToString();
        }

        private int GenerateRandomAge()
        {
            return _rand.Next(1, 100);
        }

        private double GenerateRandomHeight()
        {
            return _rand.Next(150, 200) + _rand.NextDouble();
        }

        private double GenerateRandomWeight()
        {
            return _rand.Next(50, 150) + _rand.NextDouble();
        }

        private string GetRandomGender()
        {
            return _genders[_rand.Next(_genders.Count)];
        }

        private string GetRandomState()
        {
            return _states[_rand.Next(_states.Count)];
        }

        private string GetRandomInsurance()
        {
            return _insurances[_rand.Next(_insurances.Count)];
        }

        private string GetRandomFirstName()
        {
            return _firstName[_rand.Next(_firstName.Count)];
        }

        private string GetRandomLastName()
        {
            return _lastName[_rand.Next(_lastName.Count)];
        }
    }
}