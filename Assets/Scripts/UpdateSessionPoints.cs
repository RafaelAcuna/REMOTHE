using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateSessionPoints : MonoBehaviour
{
    public StaticSessionInfo sessionInfo;
    public TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        if (sessionInfo.getPoints() > 0)
            pointsText.text += " " + sessionInfo.getPoints();
        else
            pointsText.text = "";
    }
}
