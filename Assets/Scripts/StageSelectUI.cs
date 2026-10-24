using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] private Button goToTitleButton;
    private SceneController sceneController;

    [Inject]
    public void Construct(SceneController sceneController)
    {
        this.sceneController = sceneController;
    }

    private void Awake()
    {
        goToTitleButton.onClick.AddListener(() => sceneController.ChangeScene("TitleScene"));
    }
}
