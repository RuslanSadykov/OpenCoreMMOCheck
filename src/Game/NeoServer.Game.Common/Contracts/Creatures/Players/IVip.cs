﻿using System.Collections.Generic;

namespace NeoServer.Game.Common.Contracts.Creatures.Players
{
    public interface IVip
    {
        void LoadVipList(IEnumerable<(uint, string)> vips);
        bool AddToVip(IPlayer player);
        void RemoveFromVip(uint playerId);
        bool HasInVipList(uint playerId);
        event AddToVipList OnAddedToVipList;
        event PlayerLoadVipList OnLoadedVipList;
        HashSet<uint> VipList { get; set; }
    }
}