using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Return no adjustment if there are no neighbours
        if (context.Count == 0)
        {
            return Vector2.zero;
        }
        //Add all locations together
        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform location in context)
        {
            cohesionMove += (Vector2) location.position;
        }
        //Get average location among boids
        Vector2 averageVector = cohesionMove / context.Count;

        //Get vector relative to agent 
        averageVector -= (Vector2)agent.transform.position;
        return averageVector;
    }
}
