using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class AutoPPU : MonoBehaviour
{
    public float multiply = 1.0f;
    private Image targetSprite;

    void Awake()
    {
        targetSprite = GetComponent<Image>();
    }

    void Update()
    {
        if (targetSprite == null)
            return;

        targetSprite.pixelsPerUnitMultiplier = (InternalConfig.AutoPPUBaseResolution / (float)Screen.height) * multiply;
    }
}