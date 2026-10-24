using System;
using UnityEngine.SceneManagement;

public class SceneController
{
    public void ChangeScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
