﻿using NeoServer.Game.Contracts.Chats;
using NeoServer.Game.Contracts.Creatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeoServer.Game.DataStore
{
    public class NpcStore: DataStore<string, INpcType>
    {
    }
}