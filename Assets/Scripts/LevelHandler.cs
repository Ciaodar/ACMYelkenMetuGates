using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private static int _factCounter = 1,_answerCounter = 1;

    public static void SaveTheFact(String factText)
    {
        PlayerPrefs.SetString("Fact" + _factCounter++, factText);
    }
    
    public static void SaveTheAnswer(String answerText)
    {
        PlayerPrefs.SetString("Answer" + _answerCounter++, answerText);
    }
    
}
