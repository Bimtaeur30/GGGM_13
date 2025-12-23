using UnityEngine;

public class EndScene : MonoBehaviour
{
    public void OnRetryBtn()
    {
        SceneChangeManager.Instance.MoveScene(1);
    }

    public void OnHomeBtn()
    {
        SceneChangeManager.Instance.MoveScene(0);
    }
}
