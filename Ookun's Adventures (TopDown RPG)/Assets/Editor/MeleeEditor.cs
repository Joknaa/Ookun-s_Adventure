/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Melee))]
public class MeleeEditor : Editor
{
    Melee melee;
    void OnEnable()
    {
        melee = (Melee)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        melee.ThisEnemyRole = (MeleeEnemyRole)EditorGUILayout.EnumPopup("MeleeEnemyRole", melee.ThisEnemyRole);
        switch (melee.ThisEnemyRole)
        {
            case MeleeEnemyRole.Stander:
                {
                    break;
                }
            case MeleeEnemyRole.Guardian:
                {
                    melee.GuardedArea = (Collider2D)EditorGUILayout.ObjectField("GuardedArea", melee.GuardedArea, typeof(Collider2D), true);
                    melee.GuardPostLocation = (Transform)EditorGUILayout.ObjectField("GuardPostLocation", melee.GuardPostLocation, typeof(Transform), true);
                    melee.RoundingDistance = EditorGUILayout.FloatField("RoundingDistance", melee.RoundingDistance);
                    break;
                }
            case MeleeEnemyRole.Patroller:
                {
                    
                    melee.CurrentPoint = EditorGUILayout.IntField("CurrentPoint", melee.CurrentPoint);
                    melee.CurrentGoal = (Transform)EditorGUILayout.ObjectField("CurrentGoal", melee.CurrentGoal, typeof(Transform), true);
                    break;
                }
        }

    }
}*/