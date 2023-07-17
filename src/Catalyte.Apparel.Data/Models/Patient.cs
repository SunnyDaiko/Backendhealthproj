﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Models
{
    /// <summary>
    /// This class is a representation of a patient.
    /// </summary>
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Insurance { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static IEqualityComparer<Patient> PatientDTOComparer { get; } = new PatientEqualityComparer();

        private sealed class PatientEqualityComparer : IEqualityComparer<Patient>
        {
            public bool Equals(Patient x, Patient y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;

                return x.FirstName == y.FirstName &&
                       x.LastName == y.LastName &&
                       x.SSN == y.SSN &&
                       x.Email == y.Email &&
                       x.Age == y.Age &&
                       x.Height == y.Height &&
                       x.Weight == y.Weight &&
                       x.Insurance == y.Insurance &&
                       x.Gender == y.Gender &&
                        x.Street == y.Street &&
                       x.City == y.City &&
                       x.State == y.State &&
                       x.ZipCode == y.ZipCode;
            }

            public int GetHashCode(Patient obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.FirstName);
                hashCode.Add(obj.LastName);
                hashCode.Add(obj.SSN);
                hashCode.Add(obj.Email);
                hashCode.Add(obj.Age);
                hashCode.Add(obj.Height);
                hashCode.Add(obj.Weight);
                hashCode.Add(obj.Insurance);
                hashCode.Add(obj.Gender);
                hashCode.Add(obj.Street);
                hashCode.Add(obj.City);
                hashCode.Add(obj.State);
                hashCode.Add(obj.ZipCode);
                return hashCode.ToHashCode();
            }
        }
    }

}
