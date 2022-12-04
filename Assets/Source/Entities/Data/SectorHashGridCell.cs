using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Entities.Data
{
    /// <summary>
    /// A cell for a SectorHashGrid
    /// </summary>
    public class SectorHashGridCell
    {
        /// <summary>
        /// A set of all the clients inside the cell
        /// </summary>
        public HashSet<SectorHashGridClient> clients = new();

        /// <summary>
        /// A Vector2 representation of the cell position in its respective map;
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Cell size represented by a Vector2. Values most be bigger than 0
        /// </summary>
        public Vector2 size;

        /// <summary>
        /// Unique key representation of this cell in its map
        /// </summary>
        public string Key
        {
            get
            {
                return SectorHashGrid.GetCellKey(position);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is SectorHashGridCell cell && Key == cell.Key;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key);
        }
    }
}