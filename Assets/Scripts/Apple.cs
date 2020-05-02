using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float PieceSize = 0.33f;
    public int PieceInRow = 2;

    public float ExplosionRadius = 4f;
    public float ExplosionForce = 100f;
    public float ExplosionUpward = 0.4f;

    public static float BottomY = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= BottomY)
        {
            Explode();

            var applePicker = Camera.main.GetComponent<ApplePicker>();
            applePicker.AppleDestroyed();
        }
    }

    private void Explode()
    {
        Destroy(this.gameObject);

        for (var i = 0; i < PieceInRow; i++)
        {
            for(var j = 0; j < PieceInRow; j++)
            {
                for (var k = 0; k < PieceInRow; k++)
                {
                    CreateParticles(i, j, k);
                }
            }
        }

        var explosionPos = this.transform.position;
        
        var colliders = Physics.OverlapSphere(explosionPos, ExplosionRadius);

        foreach (var hit in colliders)
        {
            var rigidBody = hit.GetComponent<Rigidbody>();

            if(rigidBody != null)
            {
                rigidBody.AddExplosionForce(ExplosionForce, explosionPos, ExplosionRadius, ExplosionUpward);
            }
        }

    }

    private void CreateParticles(int x, int y, int z)
    {
        var piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        piece.AddComponent<Rigidbody>();
        piece.AddComponent<TrailRenderer>();


        piece.transform.position = this.transform.position;// + new Vector3(PieceSize * x, PieceSize * y, PieceSize * z) - CubesPivot;
        piece.transform.localScale = new Vector3(PieceSize, PieceSize, PieceSize);
                
        piece.GetComponent<Rigidbody>().mass = PieceSize;

        piece.tag = "Particle";


        var renderer = piece.GetComponent<Renderer>();

        renderer.material.color = Color.red;

        // Trail Renderer

        var trailRenderer = piece.GetComponent<TrailRenderer>();
        trailRenderer.material.color = Color.yellow;

        trailRenderer.widthMultiplier = 0.1f;

        trailRenderer.time = 1f;
    }
}
