using Assets.Source.Utilities;

namespace Assets.Source.Managers
{
    public class GameCoordinator : MonoBehaviourSingleton<GameCoordinator>
    {
        #region Private Fields

        private ControlMapManager controlMapManager;

        #endregion Private Fields

        #region Public Properties

        public ControlMapManager ControlMapManager { get => controlMapManager; private set => controlMapManager = value; }

        #endregion Public Properties

        #region Public Methods

        public void Awake()
        {
           // ControlMapManager = FindObjectOfType<ControlMapManager>();
           // ControlMapManager.LoadDefault();
        }

        #endregion Public Methods
    }
}