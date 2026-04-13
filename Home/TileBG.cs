using UnityEngine;

public class TileBG : MonoBehaviour
{
    private RectTransform self;
    private float posY = 0;

    void Awake()
    {
        self = GetComponent<RectTransform>();
    }

    void Update()
    {
        float turnoverPoint = Screen.height * 0.137037037037f;
        posY = (posY + turnoverPoint * Time.unscaledDeltaTime * 0.75f) % turnoverPoint;
        self.anchoredPosition = new UnityEngine.Vector3(0.5f, posY+0.5f, 0);
    }
}
