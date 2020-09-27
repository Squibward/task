using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private Material onMaterial;

    private Material defaultMaterial;

    private Renderer rend;

    public void ToggleLight(bool isOn)
    {
        if(isOn)
        {
            rend.material = onMaterial;
        }
        else
        {
            rend.material = defaultMaterial;
        }
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();

        defaultMaterial = rend.material;
    }
}
