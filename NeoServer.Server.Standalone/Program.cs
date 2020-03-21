﻿using Autofac;
using NeoServer.Data.RavenDB;
using NeoServer.Networking.Listeners;
using NeoServer.Server.Contracts.Repositories;
using NeoServer.Server.Loaders;
using NeoServer.Server.Model;
using NeoServer.Server.Model.Creatures;
using NeoServer.Server.Model.Creatures.Contracts;

using NeoServer.Server.Model.Players;
using NeoServer.Server.Security;
using NeoServer.Server.Standalone.IoC;
using NeoServer.Server.World;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeoServer.Server.Standalone
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = Container.CompositionRoot();
            container.Resolve<Database>().Connect();


            RSA.LoadPem();

            ItemLoader.Load();

            container.Resolve<IWorldLoader>().Load();

            container.Resolve<World.Map.Map>();

            Task.Run(() => container.Resolve<LoginListener>().BeginListening());
            Task.Run(() => container.Resolve<GameListener>().BeginListening());

            Console.WriteLine("NeoServer is up!");

            container.Resolve<ServerState>().OpenServer();

       //     CreateChar();

            Console.Read();
        }

        public static void CreateChar()
        {
            var a = new AccountModel
            {
                AccountName = "1",
                Password = "1"
            };

            var factory = Container.CompositionRoot().Resolve<Func<ushort, Model.Items.Item>>();

            a.Players = new List<PlayerModel>(){
                     new PlayerModel(){
                        CharacterName = "Caio",
                        Capacity = 100,
                        HealthPoints = 100,
                        Mana = 100,
                        MaxHealthPoints = 100,
                        MaxMana = 100,
                        StaminaMinutes = 2520,
                        ChaseMode = ChaseMode.Follow,
                        Gender = Gender.Male,
                        MaxSoulPoints = 100,
                        Online = false,
                        SoulPoints = 100,
                        Vocation = VocationType.Knight,
                        Outfit = new Outfit
                        {
                            Id = 75,
                            Head = 0,
                            Body = 0,
                            Legs = 0,
                            Feet = 0
                        },
                        Skills = new Dictionary<SkillType, ISkill>
                        {
                            { SkillType.Level, new Skill(SkillType.Level,10, 1.0, 10, 10, 150) },
                            { SkillType.Magic , new Skill(SkillType.Magic, 1, 1.0, 10, 1, 150)},
                            { SkillType.Fist, new Skill(SkillType.Fist, 10, 1.0, 10, 10, 150)},
                            { SkillType.Axe, new Skill(SkillType.Axe, 10, 1.0, 10, 10, 150)},
                            { SkillType.Club, new Skill(SkillType.Club, 10, 1.0, 10, 10, 150)},
                            { SkillType.Sword, new Skill(SkillType.Sword, 10, 1.0, 10, 10, 150)},
                            { SkillType.Shield, new Skill(SkillType.Shield, 10, 1.0, 10, 10, 150)},
                            { SkillType.Distance, new Skill(SkillType.Distance, 10, 1.0, 10, 10, 150)},
                            { SkillType.Fishing, new Skill(SkillType.Fishing, 10, 1.0, 10, 10, 150)}
                        },
                        Inventory = new Dictionary<Slot, ushort>
                        {
                            { Slot.Backpack, 2854 }
                        }

                     }
                  };

            Container.CompositionRoot().Resolve<IAccountRepository>().Create(a);
        }
    }
}
