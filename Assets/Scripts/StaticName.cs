using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaticName : MonoBehaviour
{
    public Text playerName;
    static public string plName = "Jugador";

    void Start()
    {
        playerName.text = plName;
    }

    public void changeName(TMP_InputField inputField)
    {
        plName = inputField.text;
        playerName.text = inputField.text;
    }
}
