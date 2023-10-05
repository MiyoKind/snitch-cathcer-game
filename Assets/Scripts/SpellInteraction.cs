using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInteraction : MonoBehaviour
{
    public SpellType spellType;
    public Gravity gravity;
    public FlappyBirdControl flappyBirdControl;

    private void Start()
    {
        gravity = FindObjectOfType<Gravity>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Gravity gravity = collision.GetComponent<Gravity>();
            ApplySpellEffect();
            Destroy(gameObject);
        }
    }

    public void ApplySpellEffect()
    {
        switch (spellType)
        {
            case SpellType.Ligilimens:
                break;
            case SpellType.VergandiumLeviosa:
                gravity.Rotate();
                break;
            case SpellType.PetrificusTotalus:
                flappyBirdControl.Update();
                break;
            case SpellType.Accio:
                break;
            case SpellType.Protego:
                
                break;
        }
    }

    public enum SpellType
    {
        Ligilimens,
        VergandiumLeviosa,
        PetrificusTotalus,
        Accio,
        Protego
    }
}
