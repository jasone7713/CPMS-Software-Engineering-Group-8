﻿// <auto-generated />
using System;
using CPMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CPMS.Migrations
{
    [DbContext(typeof(CPMSContext))]
    partial class CPMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CPMS.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Affiliation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleInitial")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("CPMS.Models.Defaults", b =>
                {
                    b.Property<int>("DefaultsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DefaultsID"), 1L, 1);

                    b.Property<bool?>("EnabledAuthors")
                        .HasColumnType("bit");

                    b.Property<bool?>("EnabledReviewers")
                        .HasColumnType("bit");

                    b.HasKey("DefaultsID");

                    b.ToTable("Defaults");
                });

            modelBuilder.Entity("CPMS.Models.Paper", b =>
                {
                    b.Property<int>("PaperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaperID"), 1L, 1);

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<bool?>("AnalysisOfAlgorithms")
                        .HasColumnType("bit");

                    b.Property<bool?>("Applications")
                        .HasColumnType("bit");

                    b.Property<bool?>("Architecture")
                        .HasColumnType("bit");

                    b.Property<bool?>("ArtificialIntelligence")
                        .HasColumnType("bit");

                    b.Property<int?>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Certification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Cirriculum")
                        .HasColumnType("bit");

                    b.Property<bool?>("ComputerEngineering")
                        .HasColumnType("bit");

                    b.Property<bool?>("DataStructures")
                        .HasColumnType("bit");

                    b.Property<bool?>("Databases")
                        .HasColumnType("bit");

                    b.Property<bool?>("DistanceLearning")
                        .HasColumnType("bit");

                    b.Property<bool?>("DistributedSystems")
                        .HasColumnType("bit");

                    b.Property<bool?>("EthicalSocietalIssues")
                        .HasColumnType("bit");

                    b.Property<string>("Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilenameOriginal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("FirstYearComputing")
                        .HasColumnType("bit");

                    b.Property<bool?>("GenderIssues")
                        .HasColumnType("bit");

                    b.Property<bool?>("GrantWriting")
                        .HasColumnType("bit");

                    b.Property<bool?>("GraphicsImageProcessing")
                        .HasColumnType("bit");

                    b.Property<bool?>("HumanComputerInteraction")
                        .HasColumnType("bit");

                    b.Property<bool?>("LaboratoryEnvironments")
                        .HasColumnType("bit");

                    b.Property<bool?>("Literacy")
                        .HasColumnType("bit");

                    b.Property<bool?>("MathematicsInComputing")
                        .HasColumnType("bit");

                    b.Property<bool?>("MultiMedia")
                        .HasColumnType("bit");

                    b.Property<bool?>("NetworkingDataCommunications")
                        .HasColumnType("bit");

                    b.Property<bool?>("NonMajorCourses")
                        .HasColumnType("bit");

                    b.Property<string>("NotesToReviewers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ObjectOrientedIssues")
                        .HasColumnType("bit");

                    b.Property<bool?>("OperatingSystems")
                        .HasColumnType("bit");

                    b.Property<bool?>("Other")
                        .HasColumnType("bit");

                    b.Property<string>("OtherDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ParallelProgramming")
                        .HasColumnType("bit");

                    b.Property<bool?>("Research")
                        .HasColumnType("bit");

                    b.Property<bool?>("Security")
                        .HasColumnType("bit");

                    b.Property<bool?>("SoftwareEngineering")
                        .HasColumnType("bit");

                    b.Property<bool?>("SystemEngineering")
                        .HasColumnType("bit");

                    b.Property<bool?>("SystemsAnalysisAndDesign")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("UsingTechnologyInTheClassroom")
                        .HasColumnType("bit");

                    b.Property<bool?>("WebAndInternetProgramming")
                        .HasColumnType("bit");

                    b.HasKey("PaperID");

                    b.ToTable("Paper");
                });

            modelBuilder.Entity("CPMS.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"), 1L, 1);

                    b.Property<short?>("AppropriatenessOfTopic")
                        .HasColumnType("smallint");

                    b.Property<short?>("CitationOfPreviousWork")
                        .HasColumnType("smallint");

                    b.Property<short?>("ClarityOfMainMessage")
                        .HasColumnType("smallint");

                    b.Property<short?>("ComfortLevelAcceptability")
                        .HasColumnType("smallint");

                    b.Property<short?>("ComfortLevelTopic")
                        .HasColumnType("smallint");

                    b.Property<bool?>("Complete")
                        .HasColumnType("bit");

                    b.Property<string>("ContentComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("Mechanics")
                        .HasColumnType("smallint");

                    b.Property<short?>("OrganizationOfPaper")
                        .HasColumnType("smallint");

                    b.Property<short?>("Originality")
                        .HasColumnType("smallint");

                    b.Property<short?>("OverallRating")
                        .HasColumnType("smallint");

                    b.Property<string>("OverallRatingComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaperID")
                        .HasColumnType("int");

                    b.Property<string>("PotentialForOralPresentationComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("PotentialInterestInTopic")
                        .HasColumnType("smallint");

                    b.Property<int?>("ReviewerID")
                        .HasColumnType("int");

                    b.Property<short?>("ScopeOfCoverage")
                        .HasColumnType("smallint");

                    b.Property<short?>("StabilityForPresentation")
                        .HasColumnType("smallint");

                    b.Property<short?>("SupportiveEvidence")
                        .HasColumnType("smallint");

                    b.Property<short?>("TechnicalQuality")
                        .HasColumnType("smallint");

                    b.Property<short?>("TimelinessOfTopic")
                        .HasColumnType("smallint");

                    b.Property<string>("WrittenDocumentComments")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("CPMS.Models.Reviewer", b =>
                {
                    b.Property<int>("ReviewerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewerID"), 1L, 1);

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Affiliation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("AnalysisOfAlgorithms")
                        .HasColumnType("bit");

                    b.Property<bool?>("Applications")
                        .HasColumnType("bit");

                    b.Property<bool?>("Architecture")
                        .HasColumnType("bit");

                    b.Property<bool?>("ArtificialIntelligence")
                        .HasColumnType("bit");

                    b.Property<bool?>("Cirriculum")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ComputerEngineering")
                        .HasColumnType("bit");

                    b.Property<bool?>("DataStructures")
                        .HasColumnType("bit");

                    b.Property<bool?>("Databases")
                        .HasColumnType("bit");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DistanceLearning")
                        .HasColumnType("bit");

                    b.Property<bool?>("DistributedSystems")
                        .HasColumnType("bit");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("EthicalSocietalIssues")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("FirstYearComputing")
                        .HasColumnType("bit");

                    b.Property<bool?>("GenderIssues")
                        .HasColumnType("bit");

                    b.Property<bool?>("GrantWriting")
                        .HasColumnType("bit");

                    b.Property<bool?>("GraphicsImageProcessing")
                        .HasColumnType("bit");

                    b.Property<bool?>("HumanComputerInteraction")
                        .HasColumnType("bit");

                    b.Property<bool?>("LaboratoryEnvironments")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Literacy")
                        .HasColumnType("bit");

                    b.Property<bool?>("MathematicsInComputing")
                        .HasColumnType("bit");

                    b.Property<string>("MiddleInitial")
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool?>("MultiMedia")
                        .HasColumnType("bit");

                    b.Property<bool?>("NetworkingDataCommunications")
                        .HasColumnType("bit");

                    b.Property<bool?>("NonMajorCourses")
                        .HasColumnType("bit");

                    b.Property<bool?>("ObjectOrientedIssues")
                        .HasColumnType("bit");

                    b.Property<bool?>("OperatingSystems")
                        .HasColumnType("bit");

                    b.Property<bool?>("Other")
                        .HasColumnType("bit");

                    b.Property<string>("OtherDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ParallelProgramming")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Research")
                        .HasColumnType("bit");

                    b.Property<bool?>("ReviewsAcknowledged")
                        .HasColumnType("bit");

                    b.Property<bool?>("Security")
                        .HasColumnType("bit");

                    b.Property<bool?>("SoftwareEngineering")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SystemEngineering")
                        .HasColumnType("bit");

                    b.Property<bool?>("SystemsAnalysisAndDesign")
                        .HasColumnType("bit");

                    b.Property<bool?>("UsingTechnologyInTheClassroom")
                        .HasColumnType("bit");

                    b.Property<bool?>("WebAndInternetProgramming")
                        .HasColumnType("bit");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewerID");

                    b.ToTable("Reviewer");
                });
#pragma warning restore 612, 618
        }
    }
}
