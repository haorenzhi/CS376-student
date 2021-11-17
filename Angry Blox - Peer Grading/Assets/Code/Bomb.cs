using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

    void Destruct() {
      Destroy(gameObject);
    }

    void Boom() {
      PointEffector2D explosionEff = gameObject.GetComponent<PointEffector2D>();
      explosionEff.enabled = true;
      SpriteRenderer spriteRen = gameObject.GetComponent<SpriteRenderer>();
      spriteRen.enabled = false;
      var explode = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
      Invoke("Destruct", 0.1f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
      if (collision.relativeVelocity.magnitude >= ThresholdForce) {
        Boom();
      }
    }

}
