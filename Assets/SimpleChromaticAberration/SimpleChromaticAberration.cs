using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Camera/Simple Chromatic Aberration")]
public class SimpleChromaticAberration : MonoBehaviour
{
    public float amount = 3.0f;

    [SerializeField] Shader shader;

    Material material;

    void SetUpObjects()
    {
        if (material != null) return;
        material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
    }

    void Start()
    {
        SetUpObjects();
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        SetUpObjects();
        material.SetFloat("_Amount", amount);
        Graphics.Blit(source, destination, material);
    }
}
