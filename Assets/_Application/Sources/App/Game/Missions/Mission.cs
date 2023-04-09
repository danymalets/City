using System;
using UnityEngine;

namespace Sources.App.Game.Missions
{
    public class Mission
    {
        private readonly string _title;
        private readonly SubMissionBase[] _subMissions;
        
        public Mission(string title, SubMissionBase[] subMissions)
        {
            _title = title;
            _subMissions = subMissions;
        }
    }
}