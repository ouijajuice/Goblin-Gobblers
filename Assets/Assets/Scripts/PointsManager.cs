using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Score: " + points.ToString();
    }
}
