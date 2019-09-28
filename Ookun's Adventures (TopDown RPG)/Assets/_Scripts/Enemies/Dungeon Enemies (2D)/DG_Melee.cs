using UnityEngine;
using UnityEditor;


public class DG_Melee : DG_Enemy
{
    void FixedUpdate()
    {
        ReactToPlayer();
    }

    public virtual void ReactToPlayer() { }
}