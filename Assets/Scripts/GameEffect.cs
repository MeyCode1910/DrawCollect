using UnityEngine;

public class GameEffect : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        Time.timeScale = 0;
    }
}
