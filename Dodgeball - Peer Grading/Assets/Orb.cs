using UnityEngine;

/// <summary>
/// Even handler for Orb objects
/// </summary>
public class Orb : MonoBehaviour
{
    /// <summary>
    /// If this gets called, then we're off screen
    /// So destroy ourselves
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        // TODO
        //if(transform.position.x < SpawnUtilities.Min.x||transform.position.x > SpawnUtilities.Max.x || 
            //transform.position.y < SpawnUtilities.Min.y || transform.position.y > SpawnUtilities.Max.y)
        Destroy(gameObject);
    }

    /// <summary>
    /// If this is called, then we hit something
    /// Destroy ourselves unless the thing we hit was another Orb.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO
        if (collision.collider.gameObject.name != gameObject.name) Destroy(gameObject);
    }
}
