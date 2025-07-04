using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        gameObject.SetActive(false);
        GameManager.instance.score += 1;
    }
}
