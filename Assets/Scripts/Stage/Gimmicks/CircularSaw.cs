using System;
using UnityEngine;

public class CircularSaw : MonoBehaviour, IStageResultNotifier
{
    public event Action<StageResult> OnStageFinished = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out PlayerController player))
            {
                player.PlayGameOverAction(transform.position).Forget();
            }

            OnStageFinished.Invoke(StageResult.GameOver);
        }
    }
}
