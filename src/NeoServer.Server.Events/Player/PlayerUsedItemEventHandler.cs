﻿using NeoServer.Enums.Creatures.Enums;
using NeoServer.Game.Contracts.Creatures;
using NeoServer.Game.Contracts.Spells;
using NeoServer.Game.Common;
using NeoServer.Networking.Packets.Outgoing;
using NeoServer.Server.Contracts.Network;
using NeoServer.Server.Model.Players.Contracts;
using NeoServer.Game.Contracts.Items.Types;
using NeoServer.Game.Contracts.Items;
using NeoServer.Game.Contracts.Items.Types.Useables;

namespace NeoServer.Server.Events
{
    public class PlayerUsedItemEventHandler
    {
        private readonly Game game;

        public PlayerUsedItemEventHandler(Game game)
        {
            this.game = game;
        }
        public void Execute(IPlayer player, IThing onThing, IUseableOn2 item)
        {
            foreach (var spectator in game.Map.GetPlayersAtPositionZone(onThing.Location))
            {
                if (!game.CreatureManager.GetPlayerConnection(spectator.CreatureId, out IConnection connection))
                {
                    continue;
                }

                if (item.EffecT != EffectT.None)
                {
                    connection.OutgoingPackets.Enqueue(new MagicEffectPacket(onThing.Location, item.EffecT));
                }

                connection.Send();
            }

        }
    }
}
