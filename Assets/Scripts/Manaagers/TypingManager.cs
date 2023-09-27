using System.Collections;
using System.Collections.Generic;
using KoreanTyper;
using TMPro;
using UnityEngine;

public class TypingManager : SingleTon<TypingManager>
{
    private TMP_Text _taget;
    private string _text;
    private Coroutine _typingCoroutine;
    
    public void TypingSetting(TMP_Text taget,string text)
    {
        _taget = taget;
        _text = text;
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
        }

        _typingCoroutine = StartCoroutine(nameof(TypingRoutine));
    }
    
    IEnumerator TypingRoutine()
    {
        int typingLength = _text.GetTypingLength();

        for (int i = 0; i < typingLength; i++)
        {
            _taget.text = _text.Typing(i);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
