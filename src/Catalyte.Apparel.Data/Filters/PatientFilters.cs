using Catalyte.Apparel.Data.Models;
using System.Linq;

namespace Catalyte.Apparel.Data.Filters
{
    /// <summary>
    /// Filter collection for product context queries.
    /// </summary>
    public static class PatientFilters
    {
        public static IQueryable<Patient> WherePatientIdEquals(this IQueryable<Patient> patients, int patientId)
        {
            return patients.Where(p => p.Id == patientId).AsQueryable();
        }
        public static IQueryable<Encounter> WhereEncounterIdEquals(this IQueryable<Encounter> encounters, int encounterId)
        {
            return encounters.Where(p => p.Id == encounterId).AsQueryable();
        }
    }
}
