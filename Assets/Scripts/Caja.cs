using UnityEngine;

public class Caja : MonoBehaviour
{
    public Transform UbicacionProcesador;
    public Transform UbicacionGrafica;
    public Transform UbicacionRam;

    private GameObject procesador;
    private GameObject grafica;
    private GameObject ram;

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
            Debug.Log("Antes debes limpiar el " + component.name);
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
