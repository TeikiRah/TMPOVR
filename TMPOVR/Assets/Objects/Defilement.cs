using UnityEngine;
using TMPro;

public class Defilement : MonoBehaviour
{
    public TextMeshPro textMesh;
    private float l, r, b,t, maxUp;

    private void Start()
    {
        l = textMesh.margin.x;
        t = textMesh.margin.y;
        r = textMesh.margin.z;
        b = textMesh.margin.w;
        maxUp = -(l + r + 1);
    }

    public void Update()
    {
        if(textMesh.color.a == 1)
        {
            Slider();
        }
    }

    public void Slider()
    {
        Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        
        if ((t >= 0 && pos.y > 0) || (t <= maxUp && pos.y < 0))
        {
        }
        else
        {
            t += pos.y * 2 * Time.deltaTime;
            textMesh.margin = new Vector4(l, t, r, b);
        }
    }

    public void In()
    {
        textMesh.color = new Color(1, 1, 1, 1);
    }

    public void Out()
    {
        textMesh.color = new Color(1, 1, 1, 0.5f);
    }
}
