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

    [Inject]
    public void Construct(SceneController sceneController, StageProgressManager stageProgressManager)
    {
        this.sceneController = sceneController;
        this.stageProgressManager = stageProgressManager;
    }

    private void Awake()
    {
        goToTitleButton.onClick.AddListener(() => sceneController.ChangeScene("TitleScene"));
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
                buttonUI.Setup(stageImages[stageIndex], stageClearRankImages[rank], isUnlocked);
            }
            else
            {
                buttonUI.Setup(lockedStageImage, stageClearRankImages[rank], isUnlocked);
            }
        }
    }
}
