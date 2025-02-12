using UnityEngine;

/// <summary>
/// Control the player on screen
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// Prefab for the orbs we will shoot
    /// </summary>
    public GameObject OrbPrefab;

    /// <summary>
    /// How fast our engines can accelerate us
    /// </summary>
    public float EnginePower = 1;
    
    /// <summary>
    /// How fast we turn in place
    /// </summary>
    public float RotateSpeed = 1;

    /// <summary>
    /// How fast we should shoot our orbs
    /// </summary>
    public float OrbVelocity = 10;

    /// <summary>
    /// Field to store the RigidBody2D component of the player game object
    /// </summary>
    public Rigidbody2D Body;

    /// <summary>
    /// Initializes the RigidBody variable
    /// </summary>
    void Start()
    {
        Body = this.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Fire if the player is pushing the button for the Fire axis
    /// Unlike the Enemies, the player has no cooldown, so they shoot a whole blob of orbs
    /// The orb should be placed one unit "in front" of the player.  transform.right will give us a vector
    /// in the direction the player is facing.
    /// It should move in the same direction (transform.right), but at speed OrbVelocity.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        // instantiate an orb when firing
        if (Input.GetAxis("Fire") == 1)
        {
            GameObject NewOrb = Instantiate(OrbPrefab, this.transform.right + this.transform.position, Quaternion.identity);
            // set orb velocity
            NewOrb.GetComponent<Rigidbody2D>().velocity = OrbVelocity * this.transform.right;
        }
    }

    /// <summary>
    /// Accelerate and rotate as directed by the player
    /// Apply a force in the direction (Horizontal, Vertical) with magnitude EnginePower
    /// Note that this is in *world* coordinates, so the direction of our thrust doesn't change as we rotate
    /// Set our angularVelocity to the Rotate axis time RotateSpeed
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void FixedUpdate()
    {
        // get direction of controller joystick
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // scale direction by EnginePower and apply it to the player to allow movement
        direction = direction * EnginePower;
        Body.AddForce(direction);
        // enable player aiming by setting angular velocity
        Body.angularVelocity = Input.GetAxis("Rotate") * RotateSpeed;

    }

    /// <summary>
    /// If this is called, we got knocked off screen.  Deduct a point!
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        ScoreKeeper.ScorePoints(-1);
    }
}
