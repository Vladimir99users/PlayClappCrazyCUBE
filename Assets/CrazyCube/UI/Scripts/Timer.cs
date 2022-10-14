using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _textTimer;
    public bool _isStart {get;private set;}
    private float timer = 0f;

    private void Start()
    {
        _isStart = false;
    }
    public void StartTimer()
    {
        _isStart = true;
    }
    private void Update()
    {
        if(_isStart ==  false) return;

        timer += Time.deltaTime;

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _textTimer.text = timer.ToString("N2");
    }
}
