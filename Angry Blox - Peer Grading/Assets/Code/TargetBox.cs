using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;


    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    bool detected = false;

    private void Scored()
    {
          SpriteRenderer rTarget = gameObject.GetComponent<SpriteRenderer>();
          rTarget.color = Color.green;
          if (detected) {
            return;
          }
          TargetBox tBox = gameObject.GetComponent<TargetBox>();
          if (tBox) {
            tBox.detected = true;
          }

          ScoreKeeper.AddToScore(gameObject.GetComponent<Rigidbody2D>().mass);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Ground") {
          Scored();
        }
    }
}
