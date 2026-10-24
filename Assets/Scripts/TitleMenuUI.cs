using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class TitleMenuUI : MonoBehaviour
{
    private SceneController sceneController;
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Animator settingPanelAnimator;
    [SerializeField] private Button closeSettingButton;

    [Inject]
    public void Construct(SceneController sceneController)
    {
        this.sceneController = sceneController;
    }

    void Awake()
    {
        startButton.onClick.AddListener(() => sceneController.ChangeScene("StageSelectScene"));
        settingButton.onClick.AddListener(OpenSettingPanel);
        settingPanel.SetActive(false);
        closeSettingButton.onClick.AddListener(() => CloseSettingPanel().Forget());
    }

    void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
        settingPanelAnimator.SetBool("Open", true);
    }

    async UniTaskVoid CloseSettingPanel()
    {
        settingPanelAnimator.SetBool("Open", false);
        await UniTask.Delay(TimeSpan.FromSeconds(0.5));
        settingPanel.SetActive(false);
    }
}
