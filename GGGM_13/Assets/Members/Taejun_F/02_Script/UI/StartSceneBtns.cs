using UnityEngine;
using UnityEngine.UI;

public class StartSceneBtns : MonoBehaviour
{
    public void OnStartBtn()
    {
        SceneChangeManager.Instance.MoveScene(1);
    }
    public void OnSettingBtn()
    {
        Debug.Log("세팅버튼 클릭");
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}
