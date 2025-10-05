using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    public float initialSpeed = 7f;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 15f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(LaunchWithDelay(1f));
    }

    public IEnumerator LaunchWithDelay(float delay)
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(delay);
        Launch();
    }

    public void Launch()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        Vector2 dir = new Vector2(x, y).normalized;
        rb.velocity = dir * initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Si choca con la raqueta, ajusta ángulo según punto de impacto y aumenta velocidad
        if (col.gameObject.CompareTag("Paddle"))
        {
            float paddleHeight = col.collider.bounds.size.y;
            float y = (transform.position.y - col.transform.position.y) / (paddleHeight / 2f); // -1..1

            float dirX = -Mathf.Sign(rb.velocity.x); // invierte la componente X
            Vector2 dir = new Vector2(dirX, y).normalized;

            float newSpeed = Mathf.Min(rb.velocity.magnitude + speedIncrease, maxSpeed);
            rb.velocity = dir * newSpeed;
        }
    }
}

