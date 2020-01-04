using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
    //Calculates the agents new orientation
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Return no change if there are no neighbours
        if (context.Count == 0)
        {
            return agent.transform.up;
        }
        //Add all locations together
        Vector2 alignmentTotal = Vector2.zero;
        foreach (Transform location in context)
        {
            alignmentTotal += (Vector2)agent.transform.up;
        }
        //Get average location among boids
        Vector2 averageDirection = alignmentTotal / context.Count;
        return averageDirection;
    }
}
