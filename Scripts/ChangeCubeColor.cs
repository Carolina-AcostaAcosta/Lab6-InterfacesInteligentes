using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeCubeColor : MonoBehaviour
{
    public Color selectColor = Color.red;

    private Renderer meshRenderer;
    private Color originalColor;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    void Awake()
    {
        // Obtener el Renderer para cambiar el material
        meshRenderer = GetComponent<Renderer>();
        if (meshRenderer != null)
        {
            // Guardar el color original al inicio
            originalColor = meshRenderer.material.color;
        }

        // Obtener el componente Interactable para suscribirse a los eventos
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
        {
            // Suscribirse a los eventos de XRI
            interactable.selectEntered.AddListener(OnSelectEntered);
            interactable.selectExited.AddListener(OnSelectExited);
        }
    }

    // Limpiar los listeners al destruir el objeto
    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
            interactable.selectExited.RemoveListener(OnSelectExited);
        }
    }

    // Este método se llama cuando el Ray Interactor SELECCIONA el objeto
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = selectColor;
        }
    }

    // Este método se llama cuando el Ray Interactor DEJA DE SELECCIONAR el objeto
    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = originalColor;
        }
    }
}