using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Tilemaps;

public class CharacterMovements : MonoBehaviour
{
    public float moveSpeed = 5;
    private bool walking;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    private Vector3 moveToPosition;

    public Tilemap obstacles;
    public Tilemap buildings;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!walking)
        {
            movement.x = CrossPlatformInputManager.GetAxis("Horizontal");
            movement.y =  CrossPlatformInputManager.GetAxis("Vertical");

            if(movement.x != 0)
            {
                movement.y = 0;
            }

            if(movement != Vector2.zero)
            {
                moveToPosition = transform.position + new Vector3(movement.x, movement.y, 0);
                Vector3Int obstaclesMapTile = obstacles.WorldToCell(moveToPosition - new Vector3(0, 0.5f, 0));
                if(obstacles.GetTile(obstaclesMapTile) == null && buildings.GetTile(obstaclesMapTile) == null)
                {
                    StartCoroutine(Move(moveToPosition));
                }
                else if(obstacles.GetTile(obstaclesMapTile) != null)
                {
                    if(obstacles.GetTile(obstaclesMapTile).name.Contains("Ledge") && movement.y == -1)
                    {
                        GetComponentInParent<Animation>().Play();
                        StartCoroutine(Move(moveToPosition + new Vector3(0,-1,0)));
                    }
                }
                else if(buildings.GetTile(obstaclesMapTile) != null)
                {
                    if(buildings.GetTile(obstaclesMapTile).name.Contains("Overworld_124") && movement.y == 1)
                    {
                        StartCoroutine(Move(moveToPosition));
                    }

                }

                anim.SetFloat("X", movement.x);
                anim.SetFloat("Y", movement.y);
            }

        }
       


       /* else
        {
            if(walking)
            {
                walking = false;
                anim.SetBool("walking", false);
            }
        }*/
    }

    IEnumerator Move(Vector3 newPos)
    {
        walking = true;

        while((newPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = newPos;

        walking = false;
    }
}