using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] private Button goToTitleButton;
    private SceneController sceneController;
    private StageProgressManager stageProgressManager;

    [SerializeField] private StageButtonUI stageButtonPrefab;
    [SerializeField] private Transform[] rows;
    [SerializeField] private Sprite[] stageImages; // 20枚のステージ画像
    [SerializeField] private Sprite[] stageClearRankImages;
    [SerializeField] private Sprite lockedStageImage;
    [SerializeField] private GameObject buttonPanel;

    // 左右の扉
    [SerializeField] private GameObject leftDoor;
    private RectTransform leftDoorRectTransform;
    [SerializeField] private GameObject rightDoor;
    private RectTransform rightDoorRectTransform;
    [SerializeField] private Animator rightDoorAnimator;

    [Inject]
    public void Construct(SceneController sceneController, StageProgressManager stageProgressManager)
    {
        this.sceneController = sceneController;
        this.stageProgressManager = stageProgressManager;
    }

    private void Awake()
    {
        goToTitleButton.onClick.AddListener(() => sceneController.ChangeScene("TitleScene"));
        leftDoorRectTransform = leftDoor.GetComponent<RectTransform>();
        rightDoorRectTransform = rightDoor.GetComponent<RectTransform>();


    }

    private void Start()
    {
        GenerateStageButtons();
    }

    private void GenerateStageButtons()
    {
        for (int stageIndex = 0; stageIndex < stageImages.Length; stageIndex++)
        {
            int rowIndex = stageIndex / 5; // 1~4行目
            var buttonUI = Instantiate(stageButtonPrefab, rows[rowIndex]);

            int rank = stageProgressManager.GetClearRank(stageIndex);
            bool isUnlocked = stageProgressManager.IsStageUnlocked(stageIndex);

            if (isUnlocked)
            {
                buttonUI.Setup(stageImages[stageIndex], stageClearRankImages[rank], isUnlocked, stageIndex, StageButtonClicked);
            }
            else
            {
                buttonUI.Setup(lockedStageImage, stageClearRankImages[rank], isUnlocked, stageIndex, StageButtonClicked);
            }
        }
    }

    // ステージ選択ボタンが押されたときの処理
    private void StageButtonClicked(int stageIndex)
    {
        Debug.Log(stageIndex);
        stageProgressManager.SetNextStageIndex(stageIndex);
        //PlayStageSequence(stageIndex).Forget();
        sceneController.ChangeScene("StageScene");
    }

    private async UniTaskVoid PlayStageSequence(int stageIndex)
    {
        // ボタン非表示
        buttonPanel.SetActive(false);

        // 扉を開くアニメーション
        leftDoorRectTransform.DOAnchorPos(new Vector2(-600, 0), 1.0f).SetEase(Ease.Linear);
        rightDoorAnimator.Play("RightDoorOpen");

        await UniTask.Delay(TimeSpan.FromSeconds(1));

    }
}
