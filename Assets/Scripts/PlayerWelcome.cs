using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWelcome : MonoBehaviour
{
    public Text welcome;
    public Text playerName;
    // Start is called before the first frame update
    void Start()
    {
        welcome.text = "Bienvenid@, " + playerName.text + "!";
    }
}
