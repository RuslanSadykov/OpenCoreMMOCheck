﻿using NeoServer.Game.Contracts.Creatures;
using NeoServer.Networking.Packets.Incoming;
using NeoServer.Server.Commands.Player;
using NeoServer.Server.Contracts.Network;
using NeoServer.Server.Tasks;

namespace NeoServer.Server.Handlers.Player
{
    public class PlayerCloseNpcChannelHandler : PacketHandler
    {
        private readonly Game game;
        public PlayerCloseNpcChannelHandler(Game game)
        {
            this.game = game;
        }
        public override void HandlerMessage(IReadOnlyNetworkMessage message, IConnection connection)
        {
            var playerSay = new PlayerSayPacket(message);
            if (!game.CreatureManager.TryGetPlayer(connection.CreatureId, out var player)) return;

            foreach (var creature in game.Map.GetCreaturesAtPositionZone(player.Location))
            {
                if (creature is INpc npc) game.Dispatcher.AddEvent(new Event(() => npc.StopTalkingToPlayer(player)));
            }
        }
    }
}
