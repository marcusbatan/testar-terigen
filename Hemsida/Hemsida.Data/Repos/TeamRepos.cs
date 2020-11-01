using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class TeamRepos
    {
        public Team addTeam(string teamName, byte[] file)
        {
            using (var db = new HemsidaEntities())
            {
                var team = new Team
                {
                    teamId = Guid.NewGuid(),
                    teamName = teamName,
                    teamLogo = file
                };
                db.Team.Add(team);
                db.SaveChanges();
                return team;
            }
        }
    }
}
