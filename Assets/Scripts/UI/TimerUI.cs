using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerUI : MonoBehaviour
{
    public Text TimerIndicator;
    // Update is called once per frame
    void Awake()
    {
        TimerIndicator = GetComponent <Text> ();
    }
    void Update()
    {
        TimerIndicator.text = "Timer: " + Mathf.Ceil(Time.time);
    }
}
