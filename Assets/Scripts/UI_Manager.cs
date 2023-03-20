using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    private TMP_Text _text;
    
    void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void UpdateUI(int number)
    {
        //set number to text
        _text.text = number.ToString();
        
    }

    public void UpdateUI(float number)
    {
        //set number to text
        _text.text = number.ToString();
    }

    public void UpdateUI(string text)
    {
        //set text to text
        _text.text = text;
    }

    public void UpdateUI(ref string text)
    {
        //set memory address to text instead of a copy of a value
        _text.text = text;
    }
}
