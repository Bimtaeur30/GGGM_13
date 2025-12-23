using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public void ClickSound()
    {
        SoundManager.Instance.PlaySound(SFX.ButtonClick);
    }
}
