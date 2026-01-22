using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ConsoleApp
{
    class ConsoleApp
    {
     
   
        static async Task Main(string[] args)
        {
            FootballLeageDBContext _context = new FootballLeageDBContext();




           async void OrderByMethod()
            {

                var OrderdTeam = await _context.Teams

                .OrderBy(q => q.Name)
                .ToListAsync();

                var OrderdTeamDesc = await _context.Teams

                   .OrderByDescending(q => q.Name)
                   .ToListAsync();

                var maxby = _context.Teams
                 .MaxBy(q => q.TeamId);

            }

            void GroupByMethod()
            {

                //Grouping & Aggregrating
                var GroupedTeams = _context.Teams
                    //.Where(q=>q.Name == "")
                    .GroupBy(t => new { t.CraetedDate.Date, t.Name });
                //.Where(t.)  tranlsate to Having



            }

            async void AggregateMethod()
            {
                //Aggregate Method

                int numberOfTeams = await _context.Teams.CountAsync();
                int numberOfTeamsWithSpecificId = await _context.Teams.CountAsync(t => t.TeamId == 1);


                //Min
                var minTeam = await _context.Teams.MinAsync(t => t.TeamId);

                //Max
                var maxTeam = await _context.Teams.MaxAsync(t => t.TeamId);


                // Average
                var AverageTeam = await _context.Teams.AverageAsync(t => t.TeamId);

                //Sum
                var SumTeam = await _context.Teams.SumAsync(t => t.TeamId);

            }


            //Get Single Record
            var GetFirstTeam = _context.Coaches.FirstAsync();
            var GetFirstTeam2 = _context.Coaches.FirstAsync(t=>t.Id==1);

      

            ////Get All Teams
            var team = _context.Teams.ToList();
            ////Get All Teams async
            //team = await _context.Teams.ToListAsync();

            //foreach (var member in team)
            //{
            //    Console.WriteLine($"Name: {member.Name}, Id: {member.TeamId}");
            //}
        }
    }
}