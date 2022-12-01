using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    private void OnEnable()//Highlights button when it is selected to show which button is selected. (For Arcade Purposes)
    {
        GetComponent<Button>().Select();
    }
}
