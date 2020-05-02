using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject BasketPrefab;
    public int NumBaskets = 1;
    public float BasketBottomY = 22f;
    public float BasketSpacingY = 2f;
    public List<GameObject> BasketList;

    // Start is called before the first frame update
    void Start()
    {
        BasketList = new List<GameObject>();

        Cursor.visible = false;

        for(var i = 0; i < NumBaskets; i++)
        {
            var tBasketGO = Instantiate<GameObject>(BasketPrefab);

            var pos = Vector3.zero;

            pos.y = BasketBottomY + (BasketSpacingY * i);
            pos.x = 110;
            pos.z = 400;

            tBasketGO.transform.position = pos;

            BasketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed()
    {
        var allApples = GameObject.FindGameObjectsWithTag("Apple");

        foreach(var apple in allApples)
        {
            Destroy(apple);
        }

        int basketIndex = BasketList.Count - 1;
        var tBasketGo = BasketList[basketIndex];

        BasketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        if (BasketList.Count == 0)
        {
            var scoreGO = GameObject.Find("ScoreCounter");

            var scoreGT = scoreGO.GetComponent<Text>();

            GameOverScore.FinalScore = scoreGT.text;

            SceneManager.LoadScene("GameOver");
        }
    }
}
