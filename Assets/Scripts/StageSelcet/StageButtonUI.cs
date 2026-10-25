using System;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonUI : MonoBehaviour
{
    [SerializeField] private Image buttonImage;  // 1~20のステージボタン画像のどれか
    [SerializeField] private Image starImages;    // クリア状況に応じた星画像
    [SerializeField] private Button button;
    private int myStageIndex;
    private Action<int> onClickCallback;

    public void Setup(Sprite stageSprite, Sprite clearRank, bool isUnlocked, int stageIndex, Action<int> onClick)
    {
        buttonImage.sprite = stageSprite;
        button.enabled = isUnlocked;
        starImages.sprite = clearRank;
        myStageIndex = stageIndex;

        onClickCallback = onClick;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClickCallback?.Invoke(myStageIndex));
    }
}
