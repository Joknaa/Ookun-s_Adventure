using UnityEngine;
using UnityEditor;


public class Melee : Enemy
{
    void FixedUpdate()
    {
        ReactToPlayer();
    }

    public virtual void ReactToPlayer() {}
}
