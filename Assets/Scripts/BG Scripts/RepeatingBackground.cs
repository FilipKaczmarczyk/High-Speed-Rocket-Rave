using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D bgCollider;    
    
    private float bgVerticalLength;        

    private void Awake()
    {
        bgCollider = GetComponent<BoxCollider2D>();

        bgVerticalLength = bgCollider.size.y;
    }

    private void Update()
    {
        if (transform.position.y < -bgVerticalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 bgOffSet = new Vector2(0, bgVerticalLength * 2f);

        transform.position = (Vector2)transform.position + bgOffSet;
    }
}