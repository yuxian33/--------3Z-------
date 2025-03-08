using Library;
using Library.SystemModels;
using System.Collections.Generic;

namespace Server.Models
{
    public sealed class FubenMap
    {
        public List<PlayerObject> GroupMembers;

        public PlayerObject CurrentPlayer { get; }

        public MapType mapType { get; }

        public FubenMap(MapInfo info)
          : base()
        {
        }
    }
}