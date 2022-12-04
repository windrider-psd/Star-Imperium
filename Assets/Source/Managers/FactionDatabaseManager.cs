using Assets.Source.Entities;
using Assets.Source.Factions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Managers
{
    public enum DefaultFaction
    {
        UnitedRepublic, HumamEmpire
    }

    public static class DefaultFactionReolver
    {
        public static Faction Resolve(DefaultFaction defaultFaction)
        {
            return defaultFaction switch
            {
                DefaultFaction.UnitedRepublic => new()
                {
                    Behaviour = FactionBehaviour.Default,
                    Name = "United Republic",
                    Description = "Wah",
                    Formalized = true,
                },
                DefaultFaction.HumamEmpire => new()
                {
                    Behaviour = FactionBehaviour.Default,
                    Name = "Human Empire",
                    Description = "Wah",
                    Formalized = true,
                },
                _ => null,
            };
        }
    }

    public class FactionDatabaseManager : MonoBehaviour
    {
        private SpawnManager spawnManager;

        public delegate void OnEntitySwitchedFactionEventHandler(Faction faction);

        public delegate void OnFactionCreatedEventHandler(Faction faction);

        public delegate void OnFactionRemovedEventHandler(Faction faction);

        public event OnEntitySwitchedFactionEventHandler OnEntitySwitchedFaction;

        public event OnFactionCreatedEventHandler OnFactionCreated;

        public event OnFactionRemovedEventHandler OnFactionRemoved;

        public Faction PlayerFaction { get; set; }
        public HashSet<Faction> Factions { get; set; } = new();

        public Dictionary<DefaultFaction, string> defaultFactionIds = new();

        public void AddFaction(Faction faction)
        {
            Factions.Add(faction);

            foreach (var f in Factions)
            {
                if (Faction.IsFactionChildOFaction(faction, f))
                {
                    f.Relations.Add(faction, 100);
                }
                else
                {
                    f.Relations.Add(faction, 0);
                }
            }

            OnFactionCreated?.Invoke(faction);
        }

        public void Awake()
        {
            spawnManager = FindObjectOfType<SpawnManager>();
            spawnManager.OnEntityCreated += OnEntityCreated;
        }

        public void LoadDefaultFactions()
        {
            foreach (DefaultFaction df in Enum.GetValues(typeof(DefaultFaction)))
            {
                var f = DefaultFactionReolver.Resolve(df);
                AddFaction(f);
                defaultFactionIds[df] = f.Id;
            }
        }

        public void RemoveFaction(Faction faction)
        {
            Factions.Remove(faction);

            foreach (var f in Factions)
            {
                f.Relations.Remove(f);
            }

            OnFactionRemoved?.Invoke(faction);
        }

        public void SwitchFaction(Entity entity, Faction newFaction)
        {
            Faction old = entity.faction;

            if (Factions.TryGetValue(entity.faction, out var oldge))
            {
                oldge.RemoveEntity(entity);
            }

            entity.faction = newFaction;

            if (Factions.TryGetValue(entity.faction, out var faction))
            {
                faction.AddEntity(entity);
            }
            else
            {
                if (faction != null)
                {
                    AddFaction(faction);
                }
            }
        }

        public void UpdateRelation(Faction f1, Faction f2, int value)
        {
            f1.Relations[f2] = Math.Clamp(value, -100, 100);
            f2.Relations[f1] = Math.Clamp(value, -100, 100);
        }

        private void OnEntityCreated(Entity entity)
        {
            if (Factions.TryGetValue(entity.faction, out var faction))
            {
                faction.AddEntity(entity);
            }
            else
            {
                if (faction != null)
                {
                    AddFaction(faction);
                }
            }

            entity.OnDestroyed += OnEntityDestroyed;
        }

        private void OnEntityDestroyed(Entity entity)
        {
            if (Factions.TryGetValue(entity.faction, out var faction))
            {
                faction.RemoveEntity(entity);
            }

            entity.OnDestroyed -= OnEntityDestroyed;
        }
    }
}