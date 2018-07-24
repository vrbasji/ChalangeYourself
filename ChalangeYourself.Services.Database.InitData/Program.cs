using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalangeYourself.Services.Database.InitData
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var db = new ChalangeDbContext())
                {
                    //var sponsors = db.Sponsors.ToArray();
                    //db.Sponsors.Add(new Data.Model.Sponsor()
                    //{
                    //    Contact = "info@alza.cz",
                    //    Name = "Alza"
                    //});
                    //db.SaveChanges();
                    db.Chalanges.Add(new Data.Model.Chalange()
                    {
                        Active = true,
                        Description = "First test chalange",
                        Difficulty = Data.Model.Enums.Difficulty.Easy,
                        EndDate = DateTime.Now.AddDays(8),
                        Interests = db.Interests.ToList(),
                        MaxAge = 45,
                        MinAge = 10,
                        Name = "First chalange",
                        PublishDate = DateTime.Now,
                        SponsorInfo = db.Sponsors.FirstOrDefault(),
                        StartDate = DateTime.Now.AddHours(5),
                        ThumbnailUrl = "Content/Photos/Chalanges/first.jpg"
                    });
                    db.Chalanges.Add(new Data.Model.Chalange()
                    {
                        Active = true,
                        Description = "Second test chalange",
                        Difficulty = Data.Model.Enums.Difficulty.Medium,
                        EndDate = DateTime.Now.AddDays(25),
                        Interests = db.Interests.ToList().Take(4).ToList(),
                        MaxAge = 35,
                        MinAge = 15,
                        Name = "Second chalange",
                        PublishDate = DateTime.Now,
                        SponsorInfo = db.Sponsors.FirstOrDefault(),
                        StartDate = DateTime.Now.AddHours(12),
                        ThumbnailUrl = "Content/Photos/Chalanges/first.jpg"
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                
            }
        }
    }
}
