using UnityEngine;
using UnityEngine.XR;

public class EyeRaycaster : MonoBehaviour
{
    public float rayLength = 10f;
    public bool showDebug = true;

    private GazeTarget currentTarget;

    void Update()
    {
        InputDevice eye = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);

        if (eye.TryGetFeatureValue(CommonUsages.eyesData, out Eyes eyes))
        {
            if (eyes.TryGetFixationPoint(out Vector3 point))
            {
                if (showDebug)
                    Debug.DrawLine(transform.position, point, Color.green);

                if (Physics.Raycast(transform.position, (point - transform.position).normalized,
                                    out RaycastHit hit, rayLength))
                {
                    GazeTarget target = hit.collider.GetComponent<GazeTarget>();

                    if (target != currentTarget)
                    {
                        currentTarget?.OnGazeExit();
                        currentTarget = target;
                        currentTarget?.OnGazeEnter();
                    }
                }
                else
                {
                    currentTarget?.OnGazeExit();
                    currentTarget = null;
                }
            }
        }
    }
}
