﻿namespace NeoServer.Game.Common.Creatures.Players
{
    public enum PlayerFlag : ulong
    {
        CannotUseCombat = 1 << 0,
        CannotAttackPlayer = 1 << 1,
        CannotAttackMonster = 1 << 2,
        CannotBeAttacked = 1 << 3,
        CanConvinceAll = 1 << 4,
        CanSummonAll = 1 << 5,
        CanIllusionAll = 1 << 6,
        CanSeeInvisibility = 1 << 7,
        IgnoredByMonsters = 1 << 8,
        NotGainInFight = 1 << 9,
        HasInfiniteMana = 1 << 10,
        HasInfiniteSoul = 1 << 11,
        HasNoExhaustion = 1 << 12,
        CannotUseSpells = 1 << 13,
        CannotPickupItem = 1 << 14,
        CanAlwaysLogin = 1 << 15,
        CanBroadcast = 1 << 16,
        CanEditHouses = 1 << 17,
        CannotBeBanned = 1 << 18,
        CannotBePushed = 1 << 19,
        HasInfiniteCapacity = 1 << 20,
        CanPushAllCreatures = 1 << 21,
        CanTalkRedPrivate = 1 << 22,
        CanTalkRedChannel = 1 << 23,
        TalkOrangeHelpChannel = 1 << 24,
        NotGainExperience = 1 << 25,
        NotGainMana = 1 << 26,
        NotGainHealth = 1 << 27,
        NotGainSkill = 1 << 28,
        SetMaxSpeed = 1 << 29,
        SpecialVIP = 1 << 30,
        NotGenerateLoot = (ulong) 1 << 31,
        CanTalkRedChannelAnonymous = 1 << 32,
        IgnoreProtectionZone = 1 << 33,
        IgnoreSpellCheck = 1 << 34,
        IgnoreWeaponCheck = 1 << 35,
        CannotBeMuted = 1 << 36,
        IsAlwaysPremium = 1 << 37,
        CanBeSeen = 1 << 38
    }
}