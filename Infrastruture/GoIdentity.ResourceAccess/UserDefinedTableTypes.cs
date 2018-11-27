using System.Data;

namespace GoIdentity.ResourceAccess
{
    public static class UserDefinedTableTypes
    {
        public static DataTable EngineResponseType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                .AddColumn("UserId", DbColumnType.Int)
                .AddColumn("InfluencerId", DbColumnType.Short)

                .AddColumn("PullStatus", DbColumnType.String)
                .AddColumn("Response", DbColumnType.String)
                .AddColumn("Remarks", DbColumnType.String)
                .AddColumn("TransactionDate", DbColumnType.DateTime);

                foreach (var item in columnCollection)
                    result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable UserType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                .AddColumn("UserId", DbColumnType.Int)
                .AddColumn("UserName", DbColumnType.String)                

                .AddColumn("FirstName", DbColumnType.String)
                .AddColumn("LastName", DbColumnType.String)
                .AddColumn("Email", DbColumnType.String)
                .AddColumn("MobileNumber", DbColumnType.String)

                .AddColumn("UniqueId", DbColumnType.UniqueIdentifier)
                .AddColumn("JsonFeed", DbColumnType.String)
                ;

                foreach (var item in columnCollection)
                    result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable UserPersonnelInfoType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                .AddColumn("UserPersonnelInfoId", DbColumnType.Int)
                .AddColumn("UserId", DbColumnType.Int)
                .AddColumn("DoB", DbColumnType.DateTime)

                .AddColumn("Gender", DbColumnType.String)
                .AddColumn("PlaceOfBirth", DbColumnType.String)
                .AddColumn("CityOfLiving", DbColumnType.String)                

                .AddColumn("CityOfWork", DbColumnType.String)
                .AddColumn("MaritalStatus", DbColumnType.String)
                .AddColumn("BirthOfOrigin", DbColumnType.String)
                .AddColumn("Nationality", DbColumnType.String)
                .AddColumn("Citizenship", DbColumnType.String)
                .AddColumn("PRStatus", DbColumnType.String)

                .AddColumn("PrimaryIndustryOfWork", DbColumnType.String)
                .AddColumn("SecondaryIndustryOfWork", DbColumnType.String)

                .AddColumn("PrimaryIndustryOfBusiness", DbColumnType.String)
                .AddColumn("SecondaryIndustryOfBusiness", DbColumnType.String)

                .AddColumn("FutureRole", DbColumnType.String)
                .AddColumn("FutureIndustryOfWork", DbColumnType.String)
                .AddColumn("FutureIndustryOfBusiness", DbColumnType.String)

                ;

                foreach (var item in columnCollection)
                    result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable UserEducationType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                .AddColumn("UserEducationId", DbColumnType.Int)
                .AddColumn("UserId", DbColumnType.Int)

                .AddColumn("DegreeType", DbColumnType.String)
                .AddColumn("Title", DbColumnType.String)
                .AddColumn("UniversityOrBoard", DbColumnType.String)

                .AddColumn("InstitutionOrBoard", DbColumnType.String)
                .AddColumn("YearOfPass", DbColumnType.String)
                .AddColumn("Specialization", DbColumnType.String)
                ;

                foreach (var item in columnCollection)
                    result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable UserExperienceType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                .AddColumn("UserExperienceId", DbColumnType.Int)
                .AddColumn("UserId", DbColumnType.Int)

                .AddColumn("OrganizationName", DbColumnType.String)
                .AddColumn("Designation", DbColumnType.String)
                .AddColumn("Roles", DbColumnType.String)

                .AddColumn("StartDate", DbColumnType.DateTime)
                .AddColumn("EndDate", DbColumnType.DateTime)
                .AddColumn("IsCurrent", DbColumnType.Bool)
                .AddColumn("ReasonForChange", DbColumnType.String)
                ;

                foreach (var item in columnCollection)
                    result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable BusinessProfileType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                .AddColumn("BusinessProfileId", DbColumnType.Int)
                .AddColumn("UserId", DbColumnType.Int)

                .AddColumn("YearOfEstablishment", DbColumnType.Short)
                .AddColumn("ComponySize", DbColumnType.Int)
                .AddColumn("Role", DbColumnType.String)
                ;

                foreach (var item in columnCollection)
                    result.Columns.Add(item);

                return result;
            }
        }
    }
}