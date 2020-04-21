using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapBehaviour : MonoBehaviour
{
    public bool advancedWrapping = true;

    Renderer[] renderers;

    Transform[] ghosts = new Transform[8];

    float screenWidth;
    float screenHeight;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();

        var cam = Camera.main;

        var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

        screenWidth = screenTopRight.x - screenBottomLeft.x;
        screenHeight = screenTopRight.y - screenBottomLeft.y;

        CreateGhostShips();
    }

    void Update()
    {
        AdvancedScreenWrap();
    }

    void AdvancedScreenWrap()
    {
        var isVisible = false;
        foreach (var renderer in renderers)
        {
            if (renderer.isVisible)
            {
                isVisible = true;
                break;
            }
        }

        if (!isVisible)
        {
            SwapShips();
        }
    }

    void CreateGhostShips()
    {
        for (int i = 0; i < 8; i++)
        {
            ghosts[i] = Instantiate(transform, Vector3.zero, Quaternion.identity) as Transform;

            DestroyImmediate(ghosts[i].GetComponent<ScreenWrapBehaviour>());
        }

        PositionGhostShips();
    }

    void PositionGhostShips()
    {
        var ghostPosition = transform.position;

        ghostPosition.x = transform.position.x + screenWidth;
        ghostPosition.y = transform.position.y;
        ghosts[0].position = ghostPosition;

        ghostPosition.x = transform.position.x + screenWidth;
        ghostPosition.y = transform.position.y - screenHeight;
        ghosts[1].position = ghostPosition;

        ghostPosition.x = transform.position.x;
        ghostPosition.y = transform.position.y - screenHeight;
        ghosts[2].position = ghostPosition;

        ghostPosition.x = transform.position.x - screenWidth;
        ghostPosition.y = transform.position.y - screenHeight;
        ghosts[3].position = ghostPosition;

        ghostPosition.x = transform.position.x - screenWidth;
        ghostPosition.y = transform.position.y;
        ghosts[4].position = ghostPosition;

        ghostPosition.x = transform.position.x - screenWidth;
        ghostPosition.y = transform.position.y + screenHeight;
        ghosts[5].position = ghostPosition;

        ghostPosition.x = transform.position.x;
        ghostPosition.y = transform.position.y + screenHeight;
        ghosts[6].position = ghostPosition;

        ghostPosition.x = transform.position.x + screenWidth;
        ghostPosition.y = transform.position.y + screenHeight;
        ghosts[7].position = ghostPosition;

        for (int i = 0; i < 8; i++)
        {
            ghosts[i].rotation = transform.rotation;
        }
    }

    void SwapShips()
    {
        foreach (var ghost in ghosts)
        {
            if (ghost.position.x < screenWidth && ghost.position.x > -screenWidth &&
                ghost.position.y < screenHeight && ghost.position.y > -screenHeight)
            {
                transform.position = ghost.position;

                break;
            }
        }

        PositionGhostShips();
    }
}
