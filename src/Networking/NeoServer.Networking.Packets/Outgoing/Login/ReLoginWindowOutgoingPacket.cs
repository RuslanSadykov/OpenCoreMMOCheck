﻿using NeoServer.Server.Contracts.Network;

namespace NeoServer.Networking.Packets.Outgoing
{
    public class ReLoginWindowOutgoingPacket : OutgoingPacket
    {
        public override void WriteToMessage(INetworkMessage message)
        {
            message.AddByte((byte) GameOutgoingPacketType.ReLoginWindow);
        }
    }
}