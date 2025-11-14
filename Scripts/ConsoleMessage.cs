using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConsoleMessage : MonoBehaviour
{
    [Tooltip("El mensaje que se mostrará en la consola")]
    public string message = "Objeto agarrado";

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    void Awake()
    {
        // Obtener el componente Interactable para suscribirse al evento
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(LogMessageOnGrab);
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(LogMessageOnGrab);
        }
    }

    // Este método se llama cuando el Direct Interactor AGARRA el objeto
    public void LogMessageOnGrab(SelectEnterEventArgs args)
    {
        // Imprime el mensaje en la consola de Unity
        Debug.Log(message);
    }
}