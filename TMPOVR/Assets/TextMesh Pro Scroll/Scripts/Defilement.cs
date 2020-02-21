using UnityEngine;
using TMPro;

public class Defilement : MonoBehaviour
{
    /// <summary>
    /// Le texte à afficher.
    /// </summary>
    [Tooltip("Le texte à afficher")]
    public TextMeshPro textMesh;


    /// <summary>
    /// Les valeurs de marge du texte.
    /// </summary>
    private float left, right, back, top;

    /// <summary>
    /// L'axe Vertical entre -1 et 1.
    /// </summary>
    private float axisVertical;


    private void Start()
    {
        left = textMesh.margin.x;
        top = textMesh.margin.y;
        right = textMesh.margin.z;
        back = textMesh.margin.w;
    }

    private void Update()
    {
        if (textMesh.color.a == 1)
        {
            Scroll();
        }
    }

    /// <summary>
    /// Scrolle le texte.
    /// </summary>
    public void Scroll()
    {
        axisVertical = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");
        if ((top >= 0 && axisVertical > 0) || (textMesh.isTextOverflowing == false && axisVertical < 0))
        {
        }
        else
        {
            top += axisVertical * 2 * Time.deltaTime;
            textMesh.margin = new Vector4(left, top, right, back);
        }
    }

    /// <summary>
    /// Met en surbrillance le texte.
    /// </summary>
    public void In()
    {
        textMesh.color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// Enlève la surbrillance du texte.
    /// </summary>
    public void Out()
    {
        textMesh.color = new Color(1, 1, 1, 0.5f);
    }
}
