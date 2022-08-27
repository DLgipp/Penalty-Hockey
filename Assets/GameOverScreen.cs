using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scores;

    // Start is called before the first frame update
    public void ShowGOScreen(float score)
    {
        gameObject.SetActive(true);
        scores.text = "Score: " + score.ToString();
    }
}
