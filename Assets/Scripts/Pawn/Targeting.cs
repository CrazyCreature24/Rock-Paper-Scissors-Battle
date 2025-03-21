using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    // Needs a method that can be called whenever a pawn needs to swap a target.
    // Should have a list of each type of pawn (Rock, Paper, or Scissors). This is in LevelManager.

    // Does not need to be a singlton



    public static void SetNewTarget(GameObject obj)
    {
        Pawn pawn = obj.GetComponent<Pawn>();
        if (pawn == null)
            Debug.Log("SetNewTarget: pawn variable is null");

        PawnTypes currentType = pawn.GetPawnType();
        GameObject closest = null;

        if (currentType == PawnTypes.Rock)
        {
            closest = FindClosestTarget(obj, LevelManager.instance.scissors);
        }
        else if (currentType == PawnTypes.Scissors)
        {
            closest = FindClosestTarget(obj, LevelManager.instance.papers);
        }
        else if (currentType == PawnTypes.Paper)
        {
            closest = FindClosestTarget(obj, LevelManager.instance.rocks);
        }

        pawn.target = closest;
    }

    private static GameObject FindClosestTarget(GameObject obj, List<GameObject> targetList)
    {
        GameObject closest = targetList[0];
        Vector3 currentPos = obj.transform.position;
        float closestDis = float.MaxValue;

        if(closest == null) 
            return null;

        if (targetList.Count > 1)
        {
            for (int i = 1; i < targetList.Count; i++)
            {
                float dis = (targetList[i].transform.position - currentPos).magnitude;
                if (dis < closestDis)
                {
                    closest = targetList[i];
                    closestDis = dis;
                }
            }
        }

        return closest;
    }

}
