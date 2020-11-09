using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class GameRepos
    {
        public Games AddGames(int? homeScore, int? awayScore, Guid awayTeam, Guid homeTeam)
        {
            using (var db = new HemsidaEntities())
            {
                var addGame = new Games
                {
                    HomeScore = homeScore,
                    AwayScore = awayScore,
                    GameId = Guid.NewGuid(),
                    AwayTeam = homeTeam,
                    HomeTeam = awayTeam
                };
                db.Games.Add(addGame);
                db.SaveChanges();
                return addGame;
            }
        }
    }
}
