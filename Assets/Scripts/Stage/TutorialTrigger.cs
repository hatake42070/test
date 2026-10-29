using UnityEngine;
using VContainer;

public class TutorialTrigger : MonoBehaviour
{
    //[SerializeField] private SawRotator targetGimmick; // 説明したいギミック
    [SerializeField] private GameObject tutorialBubbleUI; // 吹き出しUI

    private PauseManager pauseManager;

    [Inject]
    public void Construct(PauseManager pauseManager)
    {
        this.pauseManager = pauseManager;
    }

    // プレイ中に触れた時（ゲーム開始時に呼んでもOK）
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowTutorial();
        }
    }

    private void ShowTutorial()
    {
        // 1. ギミックに「君が主役だよ」と教える
        //targetGimmick.SetHighlight(true);

        // 2. チュートリアル用のポーズをかける（timeScaleが0になる）
        pauseManager.SetTutorialPause(true);

        // 3. 吹き出しを出す
        tutorialBubbleUI.SetActive(true);
    }

    // プレイヤーが吹き出しを閉じた時（ボタン等から呼ばれる）
    public void CloseTutorial()
    {
        //targetGimmick.SetHighlight(false);
        pauseManager.SetTutorialPause(false);
        tutorialBubbleUI.SetActive(false);
    }
}