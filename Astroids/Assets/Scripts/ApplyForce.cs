using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    [SerializeField] Vector2 direction = Vector2.up;
    [SerializeField] float force = 0;
    [SerializeField] float torgue = 0;

    public void Apply(GameObject ob)
    {
        var rigi = ob.GetComponent<Rigidbody2D>();
        rigi.AddForce(transform.TransformVector(direction.normalized) * force, ForceMode2D.Impulse);
        rigi.AddTorque(torgue, ForceMode2D.Impulse);
    }
}
