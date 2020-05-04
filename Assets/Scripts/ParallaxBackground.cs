using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Vector2 parallaxEffectMultipier;

    private Transform camT;
    private Vector3 lastCamPos;
    private float textureUnitSizeY;

    public bool repeat;

    void Start()
    {
        camT = Camera.main.transform;
        lastCamPos = camT.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = camT.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultipier.x, deltaMovement.y * parallaxEffectMultipier.y, 0);
        lastCamPos = camT.position;

        if(camT.position.y - transform.position.y >= textureUnitSizeY && repeat)
        {
            float offsetPositionY = (camT.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x, camT.position.y + offsetPositionY);
        }
    }
}
