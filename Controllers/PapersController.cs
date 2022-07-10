using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPMS.Data;
using CPMS.Models;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace CPMS.Controllers
{
    public class PapersController : Controller
    {
        private readonly CPMSContext _context;

        public PapersController(CPMSContext context)
        {
            _context = context;
        }

        // GET: Papers
        public async Task<IActionResult> Index()
        {
              return _context.Paper != null ? 
                          View(await _context.Paper.ToListAsync()) :
                          Problem("Entity set 'CPMSContext.Paper'  is null.");
        }

        // GET: Papers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paper == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper
                .FirstOrDefaultAsync(m => m.PaperID == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // GET: Papers/Create
        public IActionResult Create()
        {
            //logic to make sure paper submissions are allowed

            //generate SQL connection
            using(SqlConnection conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=CPMS.Data;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                //generate query
                SqlCommand command = new SqlCommand($"SELECT EnabledAuthors FROM Defaults;", conn);

                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    try
                    {
                        //if we are not accepting papers redirect the user
                        if((bool)reader[0] != true)
                        {
                            ViewBag.PaperErrors = "Error: we are not currently accepting paper submissions";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    catch { }
                }
            }

            return View();
        }

        public async Task<IActionResult> WeightedAverage()
        {

            return _context.Paper != null ?
                          View(await _context.Paper.ToListAsync()) :
                          Problem("Entity set 'CPMSContext.Paper'  is null.");
        }

        // POST: Papers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaperID,AuthorID,Active,FilenameOriginal,Filename,Title,Certification,NotesToReviewers,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Cirriculum,DataStructures,Databases,DistanceLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,MultiMedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelProgramming,Research,Security,SoftwareEngineering,SystemEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription,formFile")] Paper paper, Paper p)
        {

            if (ModelState.IsValid)
            {
                if (p.formFile != null)
                {
                    //get date time as a string with no special characters
                    string Date = Regex.Replace(DateTime.Now.ToString(), "[^a-zA-Z0-9._]", string.Empty);

                    //create a unique filename based off current datetime and original name
                    string UniqueName = Date + p.formFile.FileName;

                    //grab current directory and add the proper filepath to server files
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", @"pub\files", UniqueName);

                    //save original filename into paper
                    paper.FilenameOriginal = p.formFile.FileName;

                    //save unique filename into paper
                    paper.Filename = UniqueName;

                    //copy file from upload into files folder
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await p.formFile.CopyToAsync(stream);
                    }
                }

                _context.Add(paper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paper);
        }

        // GET: Papers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paper == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper.FindAsync(id);
            if (paper == null)
            {
                return NotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaperID,AuthorID,Active,FilenameOriginal,Filename,Title,Certification,NotesToReviewers,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Cirriculum,DataStructures,Databases,DistanceLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,MultiMedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelProgramming,Research,Security,SoftwareEngineering,SystemEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription")] Paper paper)
        { 
            //bind the ID of the paper we wish to edit
            paper.PaperID = id;

            if (id != paper.PaperID)
            {
                return NotFound($"Paper did not match a valid ID {id} != {paper.PaperID}");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperExists(paper.PaperID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paper);
        }

        // GET: Papers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paper == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper
                .FirstOrDefaultAsync(m => m.PaperID == id);

            //if (paper == null)
            //{
            //    return NotFound();
            //}

            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paper == null)
            {
                return Problem("Entity set 'CPMSContext.Paper'  is null.");
            }
            var paper = await _context.Paper.FindAsync(id);
            if (paper != null)
            {
                _context.Paper.Remove(paper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return RedirectToAction();
        }

        public async Task<IActionResult> Download(string filename)
        {
            //the following code for downlaoding a file was inspired by this article https://www.techieclues.com/articles/how-to-upload-and-download-files-in-asp-net-core

            try
            {
                //grab filename and add path of current directory + path of files folder
                var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pub/files/", filename);

                var MemStream = new MemoryStream();

                using (var stream = new FileStream(FilePath, FileMode.Open))
                {
                    await stream.CopyToAsync(MemStream);
                }

                MemStream.Position = 0;
                return File(MemStream, GetContentType(FilePath), Path.GetFileName(FilePath));
            }
            catch (Exception ex)
            {
                //return an error page if contant cannot be downloaded
                return Content("Error downloading file");
            }
        }

        // Get content type
        private string GetContentType(string path)
        {
            //types of extensions allowed
            var types = GetExts();

            //get extension and return
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        // Get accepted file extensions
        private Dictionary<string, string> GetExts()
        {
            //accepted formats
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
            };
        }

        private bool PaperExists(int id)
        {
          return (_context.Paper?.Any(e => e.PaperID == id)).GetValueOrDefault();
        }
    }
}
