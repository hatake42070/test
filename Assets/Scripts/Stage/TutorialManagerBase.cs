using Cysharp.Threading.Tasks; // 追加
using UnityEngine;
using VContainer;

public abstract class TutorialManagerBase : MonoBehaviour
{
    protected PauseManager pauseManager;

    [Inject]
    public void Construct(PauseManager pauseManager)
    {
        this.pauseManager = pauseManager;
    }

    // プレイ中の接触トリガーなどを準備する処理
    public abstract void SetupTriggers();

    // 【追加】扉が開いた直後に呼ばれる、開幕チュートリアルの進行処理
    // ※ チュートリアルが終わるまで UniTask で待機させる
    public abstract UniTask PlayIntroTutorialAsync();

    protected void PauseForTutorial() => pauseManager.SetTutorialPause(true);
    protected void ResumeFromTutorial() => pauseManager.SetTutorialPause(false);
}