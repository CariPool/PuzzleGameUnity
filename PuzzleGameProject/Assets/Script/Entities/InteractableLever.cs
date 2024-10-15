using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLever : InteractableObject
{

    private bool IsToggled;
    public Sprite toggleSprite;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        if (this == null) return;
        IsToggled = true;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = toggleSprite;

        Destroy(this, 1f);
    }

    public bool IsOn()
    {
        return IsToggled;
    }

}
