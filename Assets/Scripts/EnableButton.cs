using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnableButton : MonoBehaviour
{
    public Button button;
    public TMP_InputField inputField;

    public void updateButton()
    {
        if (inputField.text.Length > 0)
            button.interactable = true;
        else
            button.interactable = false;
    }
}
