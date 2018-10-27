using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float force;
    [SerializeField] float torgue;

    public void Apply(GameObject ob)
    {
        var rigi = ob.GetComponent<Rigidbody2D>();
        rigi.AddForce(transform.TransformVector(direction.normalized) * force, ForceMode2D.Impulse);
        rigi.AddTorque(torgue, ForceMode2D.Impulse);
    }
}
