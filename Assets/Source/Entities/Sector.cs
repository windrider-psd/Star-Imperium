using Assets.Source.Entities.Data;
using UnityEngine;

namespace Assets.Source.Entities
{
    public class Sector : MonoBehaviour
    {
        public SectorHashGrid hashgrid = new(10);
        public void DrawGrid()
        {
        }

        public void Update()
        {
            //Debug.Log(hashgrid.cellSet.Count);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            foreach (var item in hashgrid.CellSet)
            {
                Gizmos.DrawWireCube(item.position, item.size);
            }
        }
    }
}