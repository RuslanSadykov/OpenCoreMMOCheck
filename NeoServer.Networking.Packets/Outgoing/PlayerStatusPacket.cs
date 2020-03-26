﻿using NeoServer.Game.Creatures.Enums;
using NeoServer.Networking.Packets.Messages;
using NeoServer.Server.Model.Players;
using NeoServer.Server.Model.Players.Contracts;
using System;

namespace NeoServer.Networking.Packets.Outgoing
{
    public class PlayerStatusPacket : OutgoingPacket
    {
        private readonly IPlayer player;
        public PlayerStatusPacket(IPlayer player)
        {
            this.player = player;
        }

        public override void WriteToMessage(INetworkMessage message)
        {
            message.AddByte((byte)GameOutgoingPacketType.PlayerStatus);
            message.AddUInt16((ushort)Math.Min(ushort.MaxValue, player.Hitpoints));
            message.AddUInt16((ushort)Math.Min(ushort.MaxValue, player.MaxHitpoints));
            message.AddUInt32(Convert.ToUInt32(player.CarryStrength));

            message.AddUInt32(Math.Min(0x7FFFFFFF, player.Experience)); // Experience: Client debugs after 2,147,483,647 exp

            message.AddUInt16(player.Level);
            message.AddByte(player.LevelPercent);
            message.AddUInt16((ushort)Math.Min(ushort.MaxValue, player.Manapoints));
            message.AddUInt16((ushort)Math.Min(ushort.MaxValue, player.MaxManapoints));
            message.AddByte(player.GetSkillInfo(SkillType.Magic));
            message.AddByte(player.GetSkillPercent(SkillType.Magic));

            message.AddByte(player.SoulPoints);
            message.AddUInt16(player.StaminaMinutes);
        }
    }
}