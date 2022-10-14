using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;


[RequireComponent(typeof(CanvasGroup))]
sealed class UI : MonoBehaviour
{
    [SerializeField] private TMP_InputField _fieldTimer;
    [SerializeField] private TMP_InputField _fieldSpeed;
    [SerializeField] private TMP_InputField _fieldDistance;


    [Header("defaults setting")]
    [SerializeField] private float _defualtTimer;

    [SerializeField] private Spawn _spawn;

    private void OnEnable()
    {
        _fieldTimer.onEndEdit.AddListener(ChangeRespawnTime) ;
        _fieldSpeed.onEndEdit.AddListener(ChangeSpeed) ;
        _fieldDistance.onEndEdit.AddListener(ChangeDistance) ;

        СallingInitialSettings();
    }
    private void OnDisable()
    {
        _fieldTimer.onEndEdit.RemoveListener(ChangeRespawnTime);
        _fieldSpeed.onEndEdit.RemoveListener(ChangeSpeed) ;
        _fieldDistance.onEndEdit.RemoveListener(ChangeDistance) ;
    }

    private void СallingInitialSettings()
    { 
        CallingInitialSettingsTimerfield();
        CallingInitialSettingsDistancefield();
        CallingInitialSettingsSpeedfield();
    }

    private void CallingInitialSettingsTimerfield()
    {
        string newLine = LineFromInputFieldIsNotEmptyContentIsReplaced(_fieldTimer.text);
        ChangeRespawnTime(newLine);
    }
    private void CallingInitialSettingsDistancefield()
    {
       string newLine = LineFromInputFieldIsNotEmptyContentIsReplaced(_fieldDistance.text);
       ChangeDistance(newLine);
    }

    private void CallingInitialSettingsSpeedfield()
    {
       string newLine = LineFromInputFieldIsNotEmptyContentIsReplaced(_fieldSpeed.text);
       ChangeSpeed(newLine);
    }

    private void ChangeRespawnTime(string newInput)
    {
        newInput = LineFromInputFieldIsNotEmptyContentIsReplaced(newInput);
        _spawn._startTimeBtwSpawns = float.Parse(newInput);
        _fieldTimer.text = newInput;
    }
    private void ChangeDistance(string newInput)
    {
        newInput = LineFromInputFieldIsNotEmptyContentIsReplaced(newInput);
        _spawn._distance = float.Parse(newInput);
        _fieldDistance.text = newInput;
    }
    private void ChangeSpeed(string newInput)
    {
        newInput = LineFromInputFieldIsNotEmptyContentIsReplaced(newInput);
        _spawn._speedCube = float.Parse(newInput);
        _fieldSpeed.text = newInput;
    }

    private string LineFromInputFieldIsNotEmptyContentIsReplaced(string str)
    {
        str = Regex.Replace(str, "(?i)[^0-9,]", "");
        Debug.Log(str);
        if(str == string.Empty || float.Parse(str) == 0f)
        {
            str = _defualtTimer.ToString();
            return str;
        } else 
        {
          return str;
        }
    }
}


/*
if(_fieldTimer.text == string.Empty)
        {
            _fieldTimer.onEndEdit.Invoke("5");
        } else 
        {
          string newString = Regex.Replace(_fieldTimer.text, "(?i)[^1-9]", "");
         _fieldTimer.onEndEdit.Invoke(_fieldTimer.text);
        }
        if(_fieldSpeed.text == string.Empty)
        {
            _fieldSpeed.onEndEdit.Invoke("1");
        } else 
        {
            string newString = Regex.Replace(_fieldSpeed.text, "(?i)[^1-9]", "");
            _fieldSpeed.onEndEdit.Invoke(_fieldSpeed.text);
        }
        if(_fieldDistance.text == string.Empty)
        {
            _fieldDistance.onEndEdit.Invoke("15");
        } else 
        {
            string newString = Regex.Replace(_fieldTimer.text, "(?i)[^1-9]", "");
            _fieldDistance.onEndEdit.Invoke(_fieldDistance.text);  
        }


*/