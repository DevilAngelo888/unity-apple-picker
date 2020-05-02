using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text ScoreGT;

    // Start is called before the first frame update
    void Start()
    {
        var scoreGO = GameObject.Find("ScoreCounter");

        ScoreGT = scoreGO.GetComponent<Text>();
        ScoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        var pos = this.transform.position;

        pos.x = mousePos3D.x;

        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var colGO = collision.gameObject;

        if (colGO.tag == "Apple")
        {
            Destroy(colGO);

            // Увеличить количество очков
            var score = int.Parse(ScoreGT.text);

            score += 100;

            ScoreGT.text = score.ToString();

            if (score > HighScore.Score)
            {
                HighScore.Score = score;
            }

            if (score % 1000 == 0)
            {
                // Ускорить дерево
                var appleTreeGO = FindObjectOfType<AppleTree>();

                if (Mathf.Abs(appleTreeGO.Speed) < 70)
                {
                    var signMultiplier = appleTreeGO.Speed < 0 ? -1 : 1;
                    appleTreeGO.Speed = signMultiplier * (Mathf.Abs(appleTreeGO.Speed) + 5);
                }

                if (appleTreeGO.SecondsBetweenAppleDrops > 0.2f && score % 7000 == 0)
                {
                    appleTreeGO.SecondsBetweenAppleDrops -= 0.1f;
                }
            }

        }
    }
}
