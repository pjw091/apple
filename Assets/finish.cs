using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D finish)
    {
        if (finish.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        GameManager.instance.StageClear();
    }
}
