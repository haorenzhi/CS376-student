using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;
    private bool called;
    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
        called = false;
    }

internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void Scored()
    {
        // FILL ME IN
        if (called) return;
        called = true;
        GetComponent<SpriteRenderer>().color = Color.green;
        ScoreKeeper.AddToScore(GetComponent<Rigidbody2D>().mass);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.tag == "Ground")
            Scored();
    }
}
