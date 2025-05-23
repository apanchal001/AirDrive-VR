using UnityEngine;

public class LapTrigger : MonoBehaviour
{
    public LapManager lapManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            lapManager.OnLapTriggerEnter();
        }
    }
}
