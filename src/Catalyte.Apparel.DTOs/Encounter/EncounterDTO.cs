using System;

namespace Catalyte.Apparel.DTOs.Encounter
{
    /// <summary>
    /// Describes a data transfer object for a encounter.
    /// </summary>
    public class EncounterDTO
    {
        private static int encounterIdCounter = 0;

        public int EncounterId { get; set; }
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
        public DateTime DateCreated { get; set; }

        public EncounterDTO()
        {
            EncounterId = ++encounterIdCounter;
        }
    }
}
