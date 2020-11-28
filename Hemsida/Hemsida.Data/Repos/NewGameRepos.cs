using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class NewGameRepos
    {
        public Games AddGames(Games games)
        {
            using (var db = new HemsidaEntities())
            {
                var addGame = new Games
                {
                    HomeScore = games.HomeScore,
                    AwayScore = games.AwayScore,
                    GameId = Guid.NewGuid(),
                    AwayTeam = games.HomeTeam,
                    HomeTeam = games.AwayTeam
                };
                db.Games.Add(addGame);
                db.SaveChanges();
                return addGame;
            }
        }
}
}
