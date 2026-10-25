using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using VContainer;

public class StageManager : MonoBehaviour
{
    private int myStageIndex;
    private StageProgressManager stageProgressManager;

    [Inject]
    public void Construct(StageProgressManager stageProgressManager)
    {
        this.stageProgressManager = stageProgressManager;
    }

    private void Start()
    {
        PlayStageSequenceAsync().Forget();
    }

    private async UniTaskVoid PlayStageSequenceAsync()
    {
        myStageIndex = stageProgressManager.GetNextStageIndex();

        // 扉を開くアニメーション
        //leftDoorRectTransform.DOAnchorPos(new Vector2(-600, 0), 1.0f).SetEase(Ease.Linear);
        //rightDoorAnimator.Play("RightDoorOpen");

        await UniTask.Delay(TimeSpan.FromSeconds(1));

    }
}
