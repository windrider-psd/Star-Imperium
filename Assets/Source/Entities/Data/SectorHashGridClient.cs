using System.Collections.Generic;

namespace Assets.Source.Entities.Data
{
    public class SectorHashGridClient
    {
        public SectorHashGridCell cell;
        public SectorHashGrid grid;
        public Sector sector;
        public MapEntity source;

        public HashSet<SectorHashGridClient> FindNearby(double radius)
        {
            var result = grid.FindClientsInRadius(source.transform.position, radius);
            result.Remove(this);
            return result;
        }

        public void Remove()
        {
            grid.RemoveClient(this);
        }

        public void Update()
        {
            grid.UpdateClient(this);
        }
    }
}