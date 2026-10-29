using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public enum StageResult
{
    Clear,
    GameOver
}

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
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;

    // 現在のステージのチュートリアル管理クラスを保持
    private TutorialManagerBase currentTutorialManager;


    [Inject]
    public void Construct(StageProgressManager stageProgressManager)
    {
        this.stageProgressManager = stageProgressManager;
    }

    private void Start()
    {
        leftDoorRectTransform = leftDoor.GetComponent<RectTransform>();
        PlayStageSequenceAsync().Forget();
        pauseButton.onClick.AddListener(() => pauseManager.SetMenuPause(true));
        resumeButton.onClick.AddListener(() => pauseManager.SetTutorialPause(true));
    }

    private void SetStage(int stageIndex)
    {
        if (stagePrefabs[stageIndex] != null)
        {
            GameObject gameObject = Instantiate(stagePrefabs[stageIndex]);
            var notifier = gameObject.GetComponentsInChildren<IStageResultNotifier>();
            foreach (var resultNotifier in notifier)
            {
                resultNotifier.OnStageFinished += HandleStageFinished;
            }
        }
    }

    private async UniTaskVoid PlayStageSequenceAsync()
    {
        myStageIndex = stageProgressManager.GetNextStageIndex();

        SetStage(myStageIndex);

        // 生成されたプレハブの初期化（Startなど）が確実に終わるまで1フレーム待機
        await UniTask.Yield();

        // ポーズ
        //pauseManager.GamePause();

        // 扉を開くアニメーション
        leftDoorRectTransform.DOAnchorPos(new Vector2(-600, 0), 1.0f).SetEase(Ease.Linear);
        rightDoorAnimator.Play("RightDoorOpen");
        rightDoorAnimator.Update(0f);

        await UniTask.Delay(TimeSpan.FromSeconds(1));

        // --- ここまでは共通 ---
    }

    private void HandleStageFinished(StageResult result)
    {
        if (result == StageResult.Clear)
        {
            // クリア処理
        }
        else if (result == StageResult.GameOver)
        {
            // GameOver処理
            Debug.Log("GameOver");

        }
    }
}
