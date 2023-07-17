using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.SeedData;

namespace Catalyte.Apparel.Test.Integration.Utilities
{
    public static class DatabaseSetupExtensions
    {
        public static void InitializeDatabaseForTests(this ApparelCtx context)
        {
            var patientFactory = new PatientFactory();
            var patients = patientFactory.GenerateRandomPatients(100);

            context.Patients.AddRange(patients);
            context.SaveChanges();
        }

        public static void ReinitializeDatabaseForTests(this ApparelCtx context)
        {
            context.Patients.RemoveRange(context.Patients);
            context.InitializeDatabaseForTests();
        }
    }
}
