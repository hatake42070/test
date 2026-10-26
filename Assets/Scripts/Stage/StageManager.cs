using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;
using VContainer;

/// <summary>
/// Stageのシーケンスを実行する
/// </summary>
public class StageManager : MonoBehaviour
{
    private int myStageIndex;
    private StageProgressManager stageProgressManager;

    [SerializeField] private GameObject leftDoor;
    private RectTransform leftDoorRectTransform;
    [SerializeField] private GameObject rightDoor;
    private RectTransform rightDoorRectTransform;
    [SerializeField] private Animator rightDoorAnimator;

    [SerializeField] private GameObject[] stagePrefabs;


    [Inject]
    public void Construct(StageProgressManager stageProgressManager)
    {
        this.stageProgressManager = stageProgressManager;
    }

    private void Start()
    {
        leftDoorRectTransform = leftDoor.GetComponent<RectTransform>();
        PlayStageSequenceAsync().Forget();
    }

    private void SetStage(int stageIndex)
    {
        if (stagePrefabs[stageIndex] != null)
        {
            Instantiate(stagePrefabs[stageIndex]);
        }
    }

    private async UniTaskVoid PlayStageSequenceAsync()
    {
        myStageIndex = stageProgressManager.GetNextStageIndex();

        SetStage(myStageIndex);

        // 生成されたプレハブの初期化（Startなど）が確実に終わるまで1フレーム待機
        await UniTask.Yield();

        // 扉を開くアニメーション
        leftDoorRectTransform.DOAnchorPos(new Vector2(-600, 0), 1.0f).SetEase(Ease.Linear);
        rightDoorAnimator.Play("RightDoorOpen");

        await UniTask.Delay(TimeSpan.FromSeconds(1));


        // --- ここまでは共通 ---


    }
}
