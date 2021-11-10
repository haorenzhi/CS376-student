using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

    private void Destruct()
    {
        Destroy(gameObject);
    }

    private void Boom()
    {
        GetComponent<PointEffector2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = false;
        var explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var rd = col.collider.GetComponent<Rigidbody2D>();
        if (rd == null)
            return;
        else
        {
            var velocity = Mathf.Sqrt(Mathf.Pow(rd.velocity[0], 2) + Mathf.Pow(rd.velocity[1], 2));
            if(velocity >= ThresholdForce)
            {
                Boom();
            }
        }
    }
}
