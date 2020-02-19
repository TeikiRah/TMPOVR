using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshPro textMesh;
    public TextMeshPro page;
    private int nb_page;
    public SpriteRenderer tri1;
    public SpriteRenderer tri2;

    private void Start()
    {
        nb_page = textMesh.GetTextInfo(textMesh.text).pageCount;
        textMesh.pageToDisplay = 1;
        Maj_page(1);
        tri1.color = new Color(1, 1, 1, 0.5f);
        tri2.color = new Color(1, 1, 1, 0.5f);
    }

    private void Maj_page(int num)
    {
        page.text = num + "/" + nb_page;
    }

    public void Suivant()
    {
        if(nb_page > textMesh.pageToDisplay)
        {
            textMesh.pageToDisplay++;
            Maj_page(textMesh.pageToDisplay);
        }
    }

    public void Precedent()
    {
        if (textMesh.pageToDisplay > 1)
        {
            textMesh.pageToDisplay--;
            Maj_page(textMesh.pageToDisplay);
        }
    }

    public void In(SpriteRenderer sr)
    {
        sr.color = new Color(1, 1, 1, 1f);
    }

    public void Out(SpriteRenderer sr)
    {
        sr.color = new Color(1, 1, 1, 0.5f);
    }

}
