using System.Collections.Generic;

public class Combinacion
{
    public List<string> tiposObjetos;

    public Combinacion(List<string> tiposObjetos)
    {
        this.tiposObjetos = tiposObjetos;
    }

    public bool Coincide(List<string> entregados)
    {
        if (entregados.Count != tiposObjetos.Count)
        {
            return false;
        }

        foreach (var tipo in tiposObjetos)
        {
            if (!entregados.Contains(tipo))
            {
                return false;
            }
        }

        return true;
    }
}
