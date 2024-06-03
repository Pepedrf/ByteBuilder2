using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Caja : MonoBehaviour
{
    public Transform UbicacionProcesador;
    public Transform UbicacionGrafica;
    public Transform UbicacionRam;

    private Image limpiarImagen; // Componente Image de la imagen de limpieza
    private Image repararImagen; // Componente Image de la imagen de reparación

    private GameObject procesador;
    private GameObject grafica;
    private GameObject ram;

    private void Start()
    {
        // Buscar y asignar las imágenes en la escena
        limpiarImagen = GameObject.Find("LimpiarImagen").GetComponent<Image>();
        repararImagen = GameObject.Find("RepararImagen").GetComponent<Image>();

        if (limpiarImagen == null || repararImagen == null)
        {
            Debug.LogError("No se pudieron encontrar las imágenes. Asegúrate de que los nombres son correctos.");
            return;
        }

        limpiarImagen.enabled = false; 
        repararImagen.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            AddComponent(collision.gameObject);
        }
    }

    private void AddComponent(GameObject component)
    {
        if (component.name == "Procesador(Clone)")
        {
            AddComponentToSlot(component, UbicacionProcesador, ref procesador);
        }
        else if (component.name == "Grafica(Clone)")
        {
            AddComponentToSlot(component, UbicacionGrafica, ref grafica);
        }
        else if (component.name == "ram(Clone)")
        {
            AddComponentToSlot(component, UbicacionRam, ref ram);
        }
        else
        {
            Debug.Log("Componente desconocido");
        }
    }

    private void AddComponentToSlot(GameObject component, Transform slot, ref GameObject slotObject)
    {
        if (component.GetComponent<ObjetoLimpieza>() != null && !component.GetComponent<ObjetoLimpieza>().haSidoLimpiado)
        {
            StartCoroutine(ShowImage(limpiarImagen));
            return;
        }
        if (component.GetComponent<ObjetoReparacion>() != null && !component.GetComponent<ObjetoReparacion>().haSidoReparado)
        {
            StartCoroutine(ShowImage(repararImagen));
            return;
        }
        if (slotObject == null) // Verifica si el slot está libre
        {
            slotObject = component;
            MoveComponentToSlot(component, slot);
            SetComponentPhysicsProperties(component);
            ChangeTag(component, "Entregado");
        }
        else
        {
            Debug.Log("El slot de " + slotObject.name + " ya está ocupado");
        }
    }

    private IEnumerator ShowImage(Image image)
    {
        image.enabled = true;
        yield return new WaitForSeconds(2);
        image.enabled = false;
    }

    private void SetComponentPhysicsProperties(GameObject component)
    {
        Rigidbody rb = component.GetComponent<Rigidbody>(); // Obtén el componente Rigidbody

        if (rb != null)
        {
            rb.useGravity = false; // Desactiva la gravedad
            rb.isKinematic = true; // Haz el objeto kinemático
        }
        else
        {
            Debug.Log("El objeto no tiene Rigidbody para ajustar las propiedades de física.");
        }
    }

    private void MoveComponentToSlot(GameObject component, Transform slot)
    {
        component.transform.position = slot.position;
        component.transform.rotation = slot.rotation;
        component.transform.SetParent(slot);
    }

    private void ChangeTag(GameObject component, string newTag)
    {
        component.tag = newTag; // Cambiar la etiqueta del objeto
    }
}
