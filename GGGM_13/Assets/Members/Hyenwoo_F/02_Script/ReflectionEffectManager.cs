using UnityEngine;

public class ReflectionEffectManager : MonoBehaviour
{
    [SerializeField] private GameObject reflectionTxt;

    private void Start()
    {
        reflectionTxt.SetActive(false);
    }

    public void ShowEffect(int persent)
    {
        reflectionTxt.GetComponent<ReflectionTxtAnim>().Show(persent);
    }
}
