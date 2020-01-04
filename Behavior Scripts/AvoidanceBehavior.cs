using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Return no adjustment if there are no neighbours
        if (context.Count == 0)
        {
            return Vector2.zero;
        }
        //Add all locations together
        Vector2 avoidanceMove = Vector2.zero;
        int numberToAvoid = 0;

        foreach (Transform location in context)
        {
            if (Vector2.SqrMagnitude(location.position - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                numberToAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - location.position);
            }
        }
        if (numberToAvoid > 0)
        {
            avoidanceMove /= numberToAvoid;
        }
        return avoidanceMove;
    }
}
