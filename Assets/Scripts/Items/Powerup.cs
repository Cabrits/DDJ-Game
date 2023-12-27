using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemEffect itemEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent)) 
        {
            Destroy(this.gameObject);
            itemEffect.Apply(collision.gameObject);
        }
    }
}
