using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private EventChannelSO onAnimalDied;
    [SerializeField] private UnityEvent onCharged;
    private int _currentExp;
    public int CurrentExp
    {
        get
        {
            return _currentExp;
        }
        private set
        {
            _currentExp = value;
        }
    }

    private void Awake()
    {
        onAnimalDied.OnEvent += AddExp;
    }

    private void AddExp()
    {
        slider.value += 1;
        if (slider.value == slider.maxValue)
        {
            slider.value = 0;
            OnExpCharged();
        }
    }

    private void OnExpCharged()
    {
        onCharged?.Invoke();
    }
}
