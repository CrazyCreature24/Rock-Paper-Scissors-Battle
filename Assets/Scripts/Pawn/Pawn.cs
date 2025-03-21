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

    // TODO: Set up collision so that it can swap targets and sides


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

        Assert.IsTrue(spriteRenderer != null);


    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            FindTarget();
    }

    public PawnTypes GetPawnType()
    {
        return type;
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

    private void SetMaterial(Material mat)
    {
        spriteRenderer.material = mat;
    }

    public void SetupSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FindTarget()
    {
        Targeting.SetNewTarget(gameObject);
    }
}
