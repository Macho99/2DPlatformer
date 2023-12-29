using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] SpriteRenderer[] renderers;

    private void Awake()
    {
        renderers = background.GetComponentsInChildren<SpriteRenderer>();
    }


}
