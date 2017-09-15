using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Infrastructure.Data.Providers;
using TournamentBuilder.Domain.Core;
using System.Threading;

namespace DataBaseSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            //var teamPr = new TeamProvider();
            //var playerPr = new PlayerProvider();

            //var random = new Random();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    Console.WriteLine($"Вставка {i} по счету комманды");
            //    var t = teamPr.Set(new Team
            //    {
            //        Name = $"Team{i}",
            //        Description = $"Description Team{i}"
            //    });
            //    teamPr.Save();
            //    var next = random.Next(0, 20);
            //    for (int j = 0; j < next; j++)
            //    {
            //        Console.WriteLine($"Вставка игрока {j} в комманду {i}");
            //        playerPr.Set(new Player
            //        {

            //            Email = $"player{i}@{j}.{t.Name}.ru",
            //            NickName = $"player{j} - {t.Name}",
            //            TeamId = t.Id
            //        });
            //        playerPr.Save();
            //    }
            //    Console.WriteLine($"Вставка завершена  {i} по счету комманды");

            //    Thread.Sleep(100);
            //}


        }
    }
}
