using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        [ForeignKey("Paper")]
        public int? PaperID { get; set; }
        [ForeignKey("Reviewer")]
        public int? ReviewerID { get; set; }
        public short? AppropriatenessOfTopic { get; set; }
        public short? TimelinessOfTopic { get; set; }
        public short? SupportiveEvidence { get; set; }
        public short? TechnicalQuality { get; set; }
        public short? ScopeOfCoverage { get; set; }
        public short? CitationOfPreviousWork { get; set; }
        public short? Originality { get; set; }
        public string? ContentComments { get; set; }
        public short? OrganizationOfPaper { get; set; }
        public short? ClarityOfMainMessage { get; set; }
        public short? Mechanics { get; set; }
        public string? WrittenDocumentComments { get; set; }
        public short? StabilityForPresentation { get; set; }
        public short? PotentialInterestInTopic { get; set; }
        public string? PotentialForOralPresentationComments { get; set; }
        public short? OverallRating { get; set; }
        public string? OverallRatingComments { get; set; }
        public short? ComfortLevelTopic { get; set; }
        public short? ComfortLevelAcceptability { get; set; }
        public bool? Complete { get; set; }

        public Review()
        {

        }
    }
}
