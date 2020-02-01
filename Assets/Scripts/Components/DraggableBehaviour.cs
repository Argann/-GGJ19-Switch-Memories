using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

/// <summary>
/// Comportement permettant de déplacer un objet en le glissant
/// déposant à la souris
/// </summary>
public class DraggableBehaviour : MonoBehaviour
{
    /// <summary>
    /// Composant Transform cible des mouvements.
    /// </summary>
    public Transform targetTransform;

    /// <summary>
    /// Composant SpriteRenderer permettant de gérer la mise
    /// en avant de l'objet
    /// </summary>
    public SpriteRenderer targetRenderer;

    /// <summary>
    /// Quel ratio doit on appliquer au zoom de l'objet au moment du drag ?
    /// </summary>
    public float zoomScaleRatio;

    /// <summary>
    /// A quel vitesse l'objet doit atteindre son zoom max ?
    /// </summary>
    public float zoomSpeed;

    /// <summary>
    /// A quel vitesse l'objet doit atteindre sa rotation nominale ?
    /// </summary>
    public float rotateSpeed;

    /// <summary>
    /// A quelle vitesse l'objet revient à sa dernière position
    /// si laché au dessus d'une zone vide ?
    /// </summary>
    public float goBackSpeed;

    /// <summary>
    /// L'objet est-il actuellement en train d'être draggé ?
    /// </summary>
    private bool isDragged = false;

    /// <summary>
    /// Echelle par défaut de l'objet cible
    /// </summary>
    private Vector3 baseScale;

    /// <summary>
    /// Rotation de base de l'objet
    /// </summary>
    private Quaternion baseRotation;

    /// <summary>
    /// Position initiale de l'objet
    /// </summary>
    private Vector3 basePosition;

    /// <summary>
    /// Méthode appelée au démarrage de l'application
    /// </summary>
    void Awake()
    {
        DraggablesManager.RegisterBehaviour(this);
        baseScale = targetTransform.localScale;
        baseRotation = targetTransform.rotation;
    }

    /// <summary>
    /// Méthode appelée automatiquement à chaque frame
    /// </summary>
    void Update()
    {
        if (isDragged)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetTransform.position = new Vector3(
                newPos.x,
                newPos.y,
                targetTransform.position.z
            );
        }
    }

    /// <summary>
    /// Méthode appelée lorsque le joueur enfonce la touche gauche de
    /// sa souris sur l'objet
    /// </summary>
    void OnMouseDown()
    {
        if (!isDragged)
        {
            isDragged = true;

            basePosition = targetTransform.position;

            targetTransform.DOScale(new Vector3(
                baseScale.x * zoomScaleRatio, 
                baseScale.y * zoomScaleRatio, 
                baseScale.z), zoomSpeed);

            targetTransform.DORotate(Vector3.zero, rotateSpeed);

            GameEventManager.OnDragBegin.Invoke(new Dictionary<string, object>()
            {
                ["Behaviour"] = this
            }
            );
        }
    }

    /// <summary>
    /// Méthode appelée lorsque le joueur relache la touche gauche de sa
    /// souris sur l'objet
    /// </summary>
    void OnMouseUp()
    {
        if (isDragged)
        {
            isDragged = false;
            targetTransform.DOScale(baseScale, zoomSpeed);

            targetTransform.DORotateQuaternion(baseRotation, rotateSpeed);

            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (!hits.Any(_ => _.collider.CompareTag("Drag Zone")))
            {
                targetTransform.DOMove(basePosition, 0.2f);
            }

            GameEventManager.OnDragEnd.Invoke(new Dictionary<string, object>()
            {
                ["Behaviour"] = this
            }
            );
        }
    }
}
