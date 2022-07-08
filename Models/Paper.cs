using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.Models
{
    public class Paper
    {
        public int PaperID { get; set; }
        [ForeignKey("Author")]
        public int? AuthorID { get; set; }
        public bool? Active { get; set; }
        public string? FilenameOriginal { get; set; }
        public string? Filename { get; set; }
        public string? Title { get; set; }
        public string? Certification { get; set; }
        public string? NotesToReviewers { get; set; }
        public bool? AnalysisOfAlgorithms { get; set; }
        public bool? Applications { get; set; }
        public bool? Architecture { get; set; }
        public bool? ArtificialIntelligence { get; set; }
        public bool? ComputerEngineering { get; set; }
        public bool? Cirriculum { get; set; }
        public bool? DataStructures { get; set; }
        public bool? Databases { get; set; }
        public bool? DistanceLearning { get; set; }
        public bool? DistributedSystems { get; set; }
        public bool? EthicalSocietalIssues { get; set; }
        public bool? FirstYearComputing { get; set; }
        public bool? GenderIssues { get; set; }
        public bool? GrantWriting { get; set; }
        public bool? GraphicsImageProcessing { get; set; }
        public bool? HumanComputerInteraction { get; set; }
        public bool? LaboratoryEnvironments { get; set; }
        public bool? Literacy { get; set; }
        public bool? MathematicsInComputing { get; set; }
        public bool? MultiMedia { get; set; }
        public bool? NetworkingDataCommunications { get; set; }
        public bool? NonMajorCourses { get; set; }
        public bool? ObjectOrientedIssues { get; set; }
        public bool? OperatingSystems { get; set; }
        public bool? ParallelProgramming { get; set; }
        public bool? Research { get; set; }
        public bool? Security { get; set; }
        public bool? SoftwareEngineering { get; set; }
        public bool? SystemEngineering { get; set; }
        public bool? SystemsAnalysisAndDesign { get; set; }
        public bool? UsingTechnologyInTheClassroom { get; set; }
        public bool? WebAndInternetProgramming { get; set; }
        public bool? Other { get; set; }
        public string? OtherDescription { get; set; }

        [NotMapped]
        public IFormFile? formFile { get; set; }
        public Paper()
        {

        }
    }
}
