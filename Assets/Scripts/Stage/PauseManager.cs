using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool IsMenuPaused { get; private set; }
    public bool IsTutorialPaused { get; private set; }

    // メニュー（通常のポーズ）の切り替え
    public void SetMenuPause(bool isPaused)
    {
        IsMenuPaused = isPaused;
        UpdateTimeScale();
    }

    // チュートリアル（吹き出し）の切り替え
    public void SetTutorialPause(bool isPaused)
    {
        IsTutorialPaused = isPaused;
        UpdateTimeScale();
    }

    private void UpdateTimeScale()
    {
        // どちらか一方でもポーズ中なら、ゲーム内時間を止める
        if (IsMenuPaused || IsTutorialPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}