using UnityEngine;

namespace Assets.Source.Test
{
    public class TimescaleTest : MonoBehaviour
    {
        private float fixedDeltaTime;

        private void Awake()
        {
            // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
            this.fixedDeltaTime = Time.fixedDeltaTime;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.timeScale == 1.0f)
                    Time.timeScale = 0.7f;
                else
                    Time.timeScale = 1.0f;
                // Adjust fixed delta time according to timescale
                // The fixed delta time will now be 0.02 real-time seconds per frame
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
        }
    }
}