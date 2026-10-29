using UnityEngine;

public class SawRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f; // 1秒間に回転する角度

    private void Update()
    {
        //float angle = rotationSpeed * Time.unscaledDeltaTime;
        // deltaTimeを使うことで、timeScale = 0 (ポーズ中)の時だけ自動的に回転が止まる
        float angle = rotationSpeed * Time.deltaTime;

        transform.Rotate(0, 0, angle);
    }
}
