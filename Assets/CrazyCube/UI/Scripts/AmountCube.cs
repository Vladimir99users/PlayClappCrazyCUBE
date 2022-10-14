using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class AmountCube : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textCube;
    private int _score = 0;
    public static UnityAction OnAmountCube;

    private void OnEnable()
    {
        OnAmountCube += CountingCube;
    }

    private void OnDisable()
    {
        OnAmountCube -= CountingCube;
    }

    public void CountingCube()
    {
        _score++;
        _textCube.text = "Cube death = " + _score.ToString();
    }
}
