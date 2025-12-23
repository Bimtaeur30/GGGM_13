using UnityEngine;

public class TestMainBtn : MonoBehaviour
{
    public void OnBtn()
    {
        SceneChangeManager.Instance.MoveScene(0);
    }
}
