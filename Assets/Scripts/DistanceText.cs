using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceText : MonoBehaviour
{
    TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        t.text = "Расстояние пройдено: " + (int)Player.player.transform.position.x + " м";
    }
}
