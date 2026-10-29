using System;
using UnityEngine;

public class GirlFriend : MonoBehaviour, IStageResultNotifier
{
    public event Action<StageResult> OnStageFinished = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnStageFinished.Invoke(StageResult.Clear);
        }
    }
}
