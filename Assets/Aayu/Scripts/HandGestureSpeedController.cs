/*using UnityEngine;

public class HandGestureSpeedController : MonoBehaviour
{
    [Header("Car Controller Reference")]
    public CarController carController;

    [Header("Speed Settings")]
    public float gestureSpeed = 50f; // 30 km/h in m/s

    // This method will be called by the Selector Unity Event Wrapper when the gesture is recognized
    public void SetSpeedTo30()
    {
        if (carController != null)
        {
            carController.SetSpeed(gestureSpeed);
            Debug.Log("Hand gesture recognized: Speed set to 30 km/h");
        }
        else
        {
            Debug.LogWarning("CarController reference not set in HandGestureSpeedController.");
        }
    }
}
*/