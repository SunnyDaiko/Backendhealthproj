using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Models
{
    /// <summary>
    /// This class is a representation of an encounter.
    /// </summary>
    public class Encounter : BaseEntity
    {
        private int EncounterId { get; set; }
        public int PatientId { get; set; }
        public string Notes { get; set; }
        public string VisitCode { get; set; }
        public string Provider { get; set; }
        public string BillingCode { get; set; }
        public string Icd10Code { get; set; }
        public double TotalCost { get; set; }
        public double Copay { get; set; }
        public string ChiefComplaint { get; set; }
        public int Pulse { get; set; }
        public int SystolicPressure { get; set; }
        public int DiastolicPressure { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static IEqualityComparer<Encounter> EncounterDTOComparer { get; } = new EncounterEqualityComparer();

        private sealed class EncounterEqualityComparer : IEqualityComparer<Encounter>
        {
            public bool Equals(Encounter x, Encounter y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;

                return x.EncounterId == y.EncounterId &&
                       x.PatientId == y.PatientId &&
                       x.Notes == y.Notes &&
                       x.VisitCode == y.VisitCode &&
                       x.Provider == y.Provider &&
                       x.BillingCode == y.BillingCode &&
                       x.Icd10Code == y.Icd10Code &&
                       x.TotalCost == y.TotalCost &&
                       x.Copay == y.Copay &&
                       x.ChiefComplaint == y.ChiefComplaint &&
                       x.Pulse == y.Pulse &&
                       x.SystolicPressure == y.SystolicPressure &&
                       x.DiastolicPressure == y.DiastolicPressure &&
                       x.Date == y.Date;
            }

            public int GetHashCode(Encounter obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.EncounterId);
                hashCode.Add(obj.PatientId);
                hashCode.Add(obj.Notes);
                hashCode.Add(obj.VisitCode);
                hashCode.Add(obj.Provider);
                hashCode.Add(obj.BillingCode);
                hashCode.Add(obj.Icd10Code);
                hashCode.Add(obj.TotalCost);
                hashCode.Add(obj.Copay);
                hashCode.Add(obj.ChiefComplaint);
                hashCode.Add(obj.Pulse);
                hashCode.Add(obj.SystolicPressure);
                hashCode.Add(obj.DiastolicPressure);
                hashCode.Add(obj.Date);
                return hashCode.ToHashCode();
            }
        }
    }
}
