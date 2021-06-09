﻿using System.Linq;
using System.Text;
using NeoServer.Game.Common.Creatures;
using NeoServer.Game.Common.Creatures.Structs;
using NeoServer.Game.Contracts.Creatures;

namespace NeoServer.Game.Contracts.Items.Types.Runes
{
    public interface IRune : IItemRequirement, IPickupable, IFormula
    {
        public CooldownTime Cooldown { get; }

        public new string ValidationError
        {
            get
            {
                var text = new StringBuilder();
                text.Append("Only ");
                //todo
                //for (int i = 0; i < Vocations.Length; i++)
                //{
                //    text.Append($"{VocationTypeParser.Parse(Vocations[i]).ToLower()}s");
                //    if (i + 1 < Vocations.Length)
                //    {
                //        text.Append(", ");
                //    }
                //}
                text.Append($" of magic level {MinLevel} or above may use or consume this item");
                return text.ToString();
            }
        }

        public new bool CanBeUsed(IPlayer player)
        {
            var vocations = Vocations;
            if (vocations?.Length > 0)
                if (!vocations.Contains(player.VocationType))
                    return false;
            if (MinLevel > 0)
                if ((player.Skills[SkillType.Magic]?.Level ?? 0) < MinLevel)
                    return false;
            return true;
        }
    }
}