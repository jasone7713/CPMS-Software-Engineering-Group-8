using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPMS.Migrations
{
    public partial class initialize_db_erickson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleInitial = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Affiliation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Defaults",
                columns: table => new
                {
                    DefaultsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnabledReviewers = table.Column<bool>(type: "bit", nullable: true),
                    EnabledAuthors = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defaults", x => x.DefaultsID);
                });

            migrationBuilder.CreateTable(
                name: "Paper",
                columns: table => new
                {
                    PaperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    FilenameOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesToReviewers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalysisOfAlgorithms = table.Column<bool>(type: "bit", nullable: true),
                    Applications = table.Column<bool>(type: "bit", nullable: true),
                    Architecture = table.Column<bool>(type: "bit", nullable: true),
                    ArtificialIntelligence = table.Column<bool>(type: "bit", nullable: true),
                    ComputerEngineering = table.Column<bool>(type: "bit", nullable: true),
                    Cirriculum = table.Column<bool>(type: "bit", nullable: true),
                    DataStructures = table.Column<bool>(type: "bit", nullable: true),
                    Databases = table.Column<bool>(type: "bit", nullable: true),
                    DistanceLearning = table.Column<bool>(type: "bit", nullable: true),
                    DistributedSystems = table.Column<bool>(type: "bit", nullable: true),
                    EthicalSocietalIssues = table.Column<bool>(type: "bit", nullable: true),
                    FirstYearComputing = table.Column<bool>(type: "bit", nullable: true),
                    GenderIssues = table.Column<bool>(type: "bit", nullable: true),
                    GrantWriting = table.Column<bool>(type: "bit", nullable: true),
                    GraphicsImageProcessing = table.Column<bool>(type: "bit", nullable: true),
                    HumanComputerInteraction = table.Column<bool>(type: "bit", nullable: true),
                    LaboratoryEnvironments = table.Column<bool>(type: "bit", nullable: true),
                    Literacy = table.Column<bool>(type: "bit", nullable: true),
                    MathematicsInComputing = table.Column<bool>(type: "bit", nullable: true),
                    MultiMedia = table.Column<bool>(type: "bit", nullable: true),
                    NetworkingDataCommunications = table.Column<bool>(type: "bit", nullable: true),
                    NonMajorCourses = table.Column<bool>(type: "bit", nullable: true),
                    ObjectOrientedIssues = table.Column<bool>(type: "bit", nullable: true),
                    OperatingSystems = table.Column<bool>(type: "bit", nullable: true),
                    ParallelProgramming = table.Column<bool>(type: "bit", nullable: true),
                    Research = table.Column<bool>(type: "bit", nullable: true),
                    Security = table.Column<bool>(type: "bit", nullable: true),
                    SoftwareEngineering = table.Column<bool>(type: "bit", nullable: true),
                    SystemEngineering = table.Column<bool>(type: "bit", nullable: true),
                    SystemsAnalysisAndDesign = table.Column<bool>(type: "bit", nullable: true),
                    UsingTechnologyInTheClassroom = table.Column<bool>(type: "bit", nullable: true),
                    WebAndInternetProgramming = table.Column<bool>(type: "bit", nullable: true),
                    Other = table.Column<bool>(type: "bit", nullable: true),
                    OtherDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paper", x => x.PaperID);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaperID = table.Column<int>(type: "int", nullable: true),
                    ReviewerID = table.Column<int>(type: "int", nullable: true),
                    AppropriatenessOfTopic = table.Column<short>(type: "smallint", nullable: true),
                    TimelinessOfTopic = table.Column<short>(type: "smallint", nullable: true),
                    SupportiveEvidence = table.Column<short>(type: "smallint", nullable: true),
                    TechnicalQuality = table.Column<short>(type: "smallint", nullable: true),
                    ScopeOfCoverage = table.Column<short>(type: "smallint", nullable: true),
                    CitationOfPreviousWork = table.Column<short>(type: "smallint", nullable: true),
                    Originality = table.Column<short>(type: "smallint", nullable: true),
                    ContentComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationOfPaper = table.Column<short>(type: "smallint", nullable: true),
                    ClarityOfMainMessage = table.Column<short>(type: "smallint", nullable: true),
                    Mechanics = table.Column<short>(type: "smallint", nullable: true),
                    WrittenDocumentComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StabilityForPresentation = table.Column<short>(type: "smallint", nullable: true),
                    PotentialInterestInTopic = table.Column<short>(type: "smallint", nullable: true),
                    PotentialForOralPresentationComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallRating = table.Column<short>(type: "smallint", nullable: true),
                    OverallRatingComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComfortLevelTopic = table.Column<short>(type: "smallint", nullable: true),
                    ComfortLevelAcceptability = table.Column<short>(type: "smallint", nullable: true),
                    Complete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                });

            migrationBuilder.CreateTable(
                name: "Reviewer",
                columns: table => new
                {
                    ReviewerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleInitial = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Affiliation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalysisOfAlgorithms = table.Column<bool>(type: "bit", nullable: true),
                    Applications = table.Column<bool>(type: "bit", nullable: true),
                    Architecture = table.Column<bool>(type: "bit", nullable: true),
                    ArtificialIntelligence = table.Column<bool>(type: "bit", nullable: true),
                    ComputerEngineering = table.Column<bool>(type: "bit", nullable: true),
                    Cirriculum = table.Column<bool>(type: "bit", nullable: true),
                    DataStructures = table.Column<bool>(type: "bit", nullable: true),
                    Databases = table.Column<bool>(type: "bit", nullable: true),
                    DistanceLearning = table.Column<bool>(type: "bit", nullable: true),
                    DistributedSystems = table.Column<bool>(type: "bit", nullable: true),
                    EthicalSocietalIssues = table.Column<bool>(type: "bit", nullable: true),
                    FirstYearComputing = table.Column<bool>(type: "bit", nullable: true),
                    GenderIssues = table.Column<bool>(type: "bit", nullable: true),
                    GrantWriting = table.Column<bool>(type: "bit", nullable: true),
                    GraphicsImageProcessing = table.Column<bool>(type: "bit", nullable: true),
                    HumanComputerInteraction = table.Column<bool>(type: "bit", nullable: true),
                    LaboratoryEnvironments = table.Column<bool>(type: "bit", nullable: true),
                    Literacy = table.Column<bool>(type: "bit", nullable: true),
                    MathematicsInComputing = table.Column<bool>(type: "bit", nullable: true),
                    MultiMedia = table.Column<bool>(type: "bit", nullable: true),
                    NetworkingDataCommunications = table.Column<bool>(type: "bit", nullable: true),
                    NonMajorCourses = table.Column<bool>(type: "bit", nullable: true),
                    ObjectOrientedIssues = table.Column<bool>(type: "bit", nullable: true),
                    OperatingSystems = table.Column<bool>(type: "bit", nullable: true),
                    ParallelProgramming = table.Column<bool>(type: "bit", nullable: true),
                    Research = table.Column<bool>(type: "bit", nullable: true),
                    Security = table.Column<bool>(type: "bit", nullable: true),
                    SoftwareEngineering = table.Column<bool>(type: "bit", nullable: true),
                    SystemEngineering = table.Column<bool>(type: "bit", nullable: true),
                    SystemsAnalysisAndDesign = table.Column<bool>(type: "bit", nullable: true),
                    UsingTechnologyInTheClassroom = table.Column<bool>(type: "bit", nullable: true),
                    WebAndInternetProgramming = table.Column<bool>(type: "bit", nullable: true),
                    Other = table.Column<bool>(type: "bit", nullable: true),
                    OtherDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewsAcknowledged = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewer", x => x.ReviewerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Defaults");

            migrationBuilder.DropTable(
                name: "Paper");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Reviewer");
        }
    }
}
