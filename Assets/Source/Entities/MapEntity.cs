using Assets.Source.CustomAttributes;
using Assets.Source.Entities.Data;
using UnityEngine;

namespace Assets.Source.Entities
{
    public class MapEntity : Entity
    {
        public SectorHashGridClient sectorHashGridClient;

        [SerializeField]
        private int baseWeight;

        [SerializeField]
        private bool dockable;

        public int BaseWeight { get => baseWeight; set => baseWeight = value; }

        public bool Dockable { get => dockable; set => dockable = value; }

        public Sector Sector { get; set; }

        public Vector3 SectorLocalPosition
        {
            get
            {
                if (Sector != null)
                    return transform.position - Sector.transform.position;
                else
                    return transform.position;
            }
            set
            {
                if (Sector != null)
                    transform.position = Sector.transform.position + value;
                else
                    transform.position = value;
            }
        }

        public void Start()
        {
            if (Sector == null)
            {
                Sector = FindObjectOfType<Sector>();
                UpdateHashGridClientSetup();

                this.OnDestroyed += (e) =>
                {
                    RemoveHashgridClient();
                };
            }
        }

        public void UpdateHashGridClientSetup()
        {
            if (sectorHashGridClient != null && !Sector.Equals(sectorHashGridClient.grid.Sector))
            {
                sectorHashGridClient.Remove();
                sectorHashGridClient = Sector.hashgrid.CreateClient(this);
            }

            if (sectorHashGridClient == null && Sector != null)
            {
                sectorHashGridClient = Sector.hashgrid.CreateClient(this);
            }
        }

        public void RemoveHashgridClient()
        {
            
            if(sectorHashGridClient != null)
            {
                sectorHashGridClient.Remove();
            }
        }
    }
}