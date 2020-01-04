using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector2 center;

    [Range(10f, 40f)]
    public float radius = 15f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float ratioDisFromCenter = centerOffset.magnitude / radius;
        if (ratioDisFromCenter < 0.9f)
        {
            return Vector2.zero;
        }
        return centerOffset * ratioDisFromCenter * ratioDisFromCenter;
    }
}
