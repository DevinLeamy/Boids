using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;
    public float[] weights;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (weights.Length != behaviors.Length)
        {
            Debug.Log("# of behaviors != # of weights");
            return Vector2.zero;
        }
        //Set up move;
        Vector2 compoundMove = Vector2.zero;

        //Go through the behaviors

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 behaviorMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i];

            if (behaviorMove != Vector2.zero)
            {
                if (behaviorMove.sqrMagnitude > weights[i] * weights[i])
                {
                    behaviorMove.Normalize();
                    behaviorMove *= weights[i];
                }

                compoundMove += behaviorMove;
            }
        }

        return compoundMove;
    }
}
