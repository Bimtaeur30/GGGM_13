using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReflectionEffectManager : MonoBehaviour
{
    [SerializeField] private GameObject reflectionTxt;
    private List<GameObject> reflectionTxtPool;

    private void Start()
    {
        ReflectionTxtPool();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShowEffect(25);
        }
    }

    public void ShowEffect(int persent)
    {
        foreach (var item in reflectionTxtPool)
        {
            if (!item.activeSelf)
            {
                item.transform.position = transform.position;
                item.GetComponent<ReflectionTxtAnim>().Show(persent);
                break;
            }
        }
    }

    private void ReflectionTxtPool()
    {
        reflectionTxtPool = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            reflectionTxtPool.Add(Instantiate(reflectionTxt, gameObject.transform));
            reflectionTxtPool[i].SetActive(false);
        }
    }
}
