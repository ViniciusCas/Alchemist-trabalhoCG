using UnityEngine;
using UnityEngine.UI;

public static class PointsClass
{
    public static int playerScore = 0;
}

public class PointsUI : MonoBehaviour
{
    public Text PointsFinal;

    void Awake()
    {
        PointsFinal = GetComponent<Text>();
    }

    void Update()
    {
        // Update the score display
        PointsFinal.text = "Pontos: " + PointsClass.playerScore;
    }
}
