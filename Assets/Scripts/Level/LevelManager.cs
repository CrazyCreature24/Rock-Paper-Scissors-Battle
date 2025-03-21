using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }







    public List<GameObject> scissors = new List<GameObject>();
    public List<GameObject> papers = new List<GameObject>();
    public List<GameObject> rocks = new List<GameObject>();

    public void AddToList(GameObject pawn)
    {
        PawnTypes type = pawn.GetComponent<Pawn>().GetPawnType();

        if (type == PawnTypes.Rock)
        {
            rocks.Add(pawn);
        }
        else if (type == PawnTypes.Paper)
        {
            papers.Add(pawn);
        }
        else if (type == PawnTypes.Scissors)
        {
            scissors.Add(pawn);
        }
    }

    public void RemoveToList(GameObject pawn)
    {

    }

    public void SwapList(GameObject pawn)
    {

    }

}
