﻿using NeoServer.Game.Contracts.Chats;
using NeoServer.Server.Contracts.Network;

namespace NeoServer.Networking.Packets.Outgoing
{
    public class PlayerAddVipPacket : OutgoingPacket
    {
        private readonly uint playerId;
        private readonly string playerName;
        private readonly bool status;

        public PlayerAddVipPacket(uint playerId, string playerName, bool status)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.status = status;
        }

        public override void WriteToMessage(INetworkMessage message)
        {
            message.AddByte((byte)GameOutgoingPacketType.AddVip);

            message.AddUInt32(playerId);
            message.AddString(playerName);
            message.AddByte(status ? 1 : 0);
        }
    }
}