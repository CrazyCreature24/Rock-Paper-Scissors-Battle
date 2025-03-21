using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Assertions;

public enum PawnTypes
{
    Rock,
    Paper,
    Scissors
}

public class Pawn : MonoBehaviour
{
    // Needs to track which pawns are tracking it, so that when the pawn changes which type it is,
    // it can now change targets.

    // TODO: Move AI to PawnAI. (Break up into components)


    public Material rockMat;
    public Material paperMat;
    public Material scissorsMat;
    public float moveSpeed = 3.0f;
    public GameObject target;
    public List<GameObject> followers = new List<GameObject>();

    
    private PawnTypes type;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            FindTarget();
    }

    public void SetPawnType(PawnTypes nType)
    {
        this.type = nType;

        if (nType == PawnTypes.Rock)
            SetMaterial(rockMat);
        else if (nType == PawnTypes.Paper) 
            SetMaterial(paperMat);
        else if (nType == PawnTypes.Scissors) 
            SetMaterial(scissorsMat);
    }

    public void FindTarget()
    {
        Targeting.SetNewTarget(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Pawn otherPawn = other.GetComponentInParent<Pawn>();
        PawnTypes othersType = otherPawn.GetPawnType();

        if (type == PawnTypes.Rock)
        {
            if (othersType == PawnTypes.Paper) // Paper beats rock
                HandleValidCollision();
        }
        else if (type == PawnTypes.Paper)
        {
            if (othersType == PawnTypes.Scissors) // Scissors beats paper
                HandleValidCollision();
        }
        else if (type == PawnTypes.Scissors)
        {
            if (othersType == PawnTypes.Rock) // Rock beats Scissors
                HandleValidCollision();
        }
    }


    private void HandleValidCollision()
    {
        if (target)
            target.GetComponent<Pawn>().RemoveFollower(gameObject);

        LevelManager.instance.SwapList(gameObject);

        HandleFollowers();
    }

    private void HandleFollowers()
    {
        foreach (var item in followers)
        {
            item.GetComponent<Pawn>().FindTarget();
        }
        followers.Clear();
    }

    public void RemoveFollower(GameObject follower)
    {
        // Removes the game object from the followers list
        followers.Remove(follower);
    }

    public PawnTypes GetPawnType()
    {
        return type;
    }
    private void SetMaterial(Material mat)
    {
        spriteRenderer.material = mat;
    }

    public void SetupSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
