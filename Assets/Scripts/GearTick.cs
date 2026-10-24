using UnityEngine;

public class GearTick : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Tick", 1f, 1f);
    }

    private void Tick()
    {
        transform.Rotate(0, 0, -6f);
    }
}
