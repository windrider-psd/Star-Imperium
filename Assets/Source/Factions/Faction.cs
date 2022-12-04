using Assets.Source.Entities;
using System;
using System.Collections.Generic;

namespace Assets.Source.Factions
{
    public class Faction
    {
        public FactionBehaviour Behaviour { get; set; }
        public HashSet<Faction> Children { get; set; } = new();
        public string Description { get; set; }
        public HashSet<Entity> Entities { get; set; } = new();
        public bool Formalized { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public Faction Parent { get; set; }
        public Dictionary<Faction, int> Relations { get; set; } = new();

        /// <summary>
        /// Checks whether a given faction <paramref name="faction"/> is a child faction of <paramref name="target"/>.
        /// </summary>
        /// <param name="faction"></param>
        /// <param name="target"></param>
        /// <returns>Returns whether <see cref="Children"/> constains <paramref name="faction"/>. If not, does a deep search </returns>
        public static bool IsFactionChildOFaction(Faction faction, Faction target)
        {
            if (target.Children.Contains(faction))
            {
                return true;
            }
            else
            {
                foreach (var c in faction.Children)
                {
                    return IsFactionChildOFaction(faction, c);
                }
            }
            return false;
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
            entity.faction = this;
            entity.OnDestroyed += RemoveEntity;
        }

        public bool IsEntityPartOfFaction(Entity entity, bool doDeepSearch = false)
        {
            if (entity.faction.Equals(this))
            {
                return true;
            }
            else if (doDeepSearch)
            {
                foreach (var faction in Children)
                {
                    return faction.IsEntityPartOfFaction(entity, doDeepSearch);
                }
            }
            return false;
        }

        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
            entity.faction = null;
            entity.OnDestroyed -= RemoveEntity;
        }
    }
}