using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Stage01Tutorial : TutorialManagerBase
{
    [SerializeField] private GameObject startBubbleUI;
    [SerializeField] private Button closeButton; // 吹き出しを閉じるボタン
    [SerializeField] private SawRotator firstSaw;

    public override void SetupTriggers()
    {
        // 接触時チュートリアルがあればここで登録
    }

    // 開幕チュートリアルの中身
    public override async UniTask PlayIntroTutorialAsync()
    {
        // 1. ポーズをかけて、UIとハイライトを表示
        PauseForTutorial();
        //firstSaw.SetHighlight(true);
        startBubbleUI.SetActive(true);

        // 2. プレイヤーが「閉じる」ボタンを押すまで、この行で処理を一時停止して待つ！
        await closeButton.OnClickAsync();

        // 3. ボタンが押されたらここから下が実行され、チュートリアルを終了して片付ける
        startBubbleUI.SetActive(false);
        //firstSaw.SetHighlight(false);
        ResumeFromTutorial();

        // メソッドが終了すると、StageManagerのawaitが終わって次の処理へ進む
    }
}