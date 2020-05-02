using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Det in Inspector")]
    public GameObject ApplePrefab;

    // Скорость движения яблони
    public float Speed = 10f;

    //РАсстояние, на котором должно изменяться направление движения яблони
    public float LeftAndRightEdge = 50f;

    // Вероятность изменения направления
    public float ChanceToChangeDirections = 0.05f;

    // Частота создания экземпляров яблок
    public float SecondsBetweenAppleDrops = 0.5f;

    // Центр древа
    public float Center = 110;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = this.transform.position;
        pos.x += Speed * Time.deltaTime;
        this.transform.position = pos;

        if (pos.x < (Center - LeftAndRightEdge))
        {
            Speed = Mathf.Abs(Speed);
        }
        else if (pos.x > (Center + LeftAndRightEdge))
        {
            Speed = -Mathf.Abs(Speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < ChanceToChangeDirections)
        {
            Speed *= -1;
        }
    }

    void DropApple()
    {
        var apple = Instantiate<GameObject>(ApplePrefab);
        apple.transform.position = this.transform.position;
        Invoke("DropApple", SecondsBetweenAppleDrops);
    }
}
