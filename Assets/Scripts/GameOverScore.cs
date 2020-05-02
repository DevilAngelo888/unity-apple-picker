using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public static string FinalScore = "0";
    
    // Start is called before the first frame update
    void Start()
    {
        var text = this.GetComponent<Text>();
        text.text = $"Final score: {FinalScore} \nHigh Score: {HighScore.Score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
