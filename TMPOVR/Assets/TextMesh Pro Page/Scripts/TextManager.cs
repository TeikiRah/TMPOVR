using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [Header("Les TextMesh Pro")]
    /// <summary>
    /// Le texte à afficher.
    /// </summary>
    [Tooltip("Le texte à afficher.")]
    public TextMeshPro textMesh;

    /// <summary>
    /// Le texte affichant le numéro de la page.
    /// </summary>
    [Tooltip("Le texte affichant le numéro de la page.")]
    public TextMeshPro textPage;


    [Header("Les Boutons")]
    /// <summary>
    /// Le bouton allant à la page précédente.
    /// </summary>
    [Tooltip("Le bouton allant à la page précédente.")]
    public SpriteRenderer btnPrecedent;

    /// <summary>
    /// Le bouton allant à la page suivante.
    /// </summary>
    [Tooltip("Le bouton allant à la page suivante.")]
    public SpriteRenderer btnSuivant;


    /// <summary>
    /// La page courante.
    /// </summary>
    private int nbPage;

    /// <summary>
    /// Les boutons permettant de défiler les pages.
    /// </summary>
    private GameObject btnDefilement;



    private void Start()
    {
        btnDefilement = transform.Find("Bouton defilement").gameObject;
        MajText(textMesh.text);
    }

    /// <summary>
    /// Met à jour le numéro de la page.
    /// </summary>
    /// <param name="num">Le numéro de la page courante.</param>
    private void MajPage(int num)
    {
        textPage.text = num + "/" + nbPage;
    }

    /// <summary>
    /// Met à jour le texte.
    /// </summary>
    private void MajText(string txt)
    {
        textMesh.text = txt;
        nbPage = textMesh.GetTextInfo(textMesh.text).pageCount;

        if(nbPage <= 1)
        {
            btnDefilement.SetActive(false);
        }

        else
        {
            btnDefilement.SetActive(true);
            textMesh.pageToDisplay = 1;
            MajPage(1);
        }
    }

    /// <summary>
    /// Passe à la page suivante.
    /// </summary>
    public void Suivant()
    {
        if(nbPage > textMesh.pageToDisplay)
        {
            textMesh.pageToDisplay++;
            MajPage(textMesh.pageToDisplay);
        }
    }

    /// <summary>
    /// Retourne à la page précédente.
    /// </summary>
    public void Precedent()
    {
        if (textMesh.pageToDisplay > 1)
        {
            textMesh.pageToDisplay--;
            MajPage(textMesh.pageToDisplay);
        }
    }

    /// <summary>
    /// Met en surbrillance le sprite.
    /// </summary>
    public void In(SpriteRenderer sr)
    {
        sr.color = new Color(1, 1, 1, 1f);
    }

    /// <summary>
    /// Enlève la surbrillance du sprite.
    /// </summary>
    public void Out(SpriteRenderer sr)
    {
        sr.color = new Color(1, 1, 1, 0.5f);
    }

}
