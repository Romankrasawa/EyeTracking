using UnityEngine;

public class GazeTarget : MonoBehaviour
{
    public Material defaultMaterial;
    public Material highlightMaterial;

    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        if (defaultMaterial != null)
            rend.material = defaultMaterial;
    }

    public void OnGazeEnter()
    {
        if (highlightMaterial != null)
            rend.material = highlightMaterial;
    }

    public void OnGazeExit()
    {
        if (defaultMaterial != null)
            rend.material = defaultMaterial;
    }
}
