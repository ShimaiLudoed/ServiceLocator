using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject fragmentPrefab;
    [SerializeField] private int numberFragment;
    [SerializeField] private LayerMask bulletMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayerMaskCheck.ContainsLayer(bulletMask,collision.gameObject.layer))
        {
            DestroyWall();
            Destroy(collision.gameObject);
        }
    }
    private void DestroyWall()
    {
        for (int i = 0; i < numberFragment; i++)
        {
            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Random.rotation);
            float scale = Random.Range(0.5f, 1.5f);
            fragment.transform.localScale *= scale;
            Rigidbody2D rb = fragment.AddComponent<Rigidbody2D>();
            rb.AddForce(Random.insideUnitCircle * Random.Range(1f, 5f), ForceMode2D.Impulse);
            rb.mass = 1;
        }
        Destroy(gameObject);
    }
}
