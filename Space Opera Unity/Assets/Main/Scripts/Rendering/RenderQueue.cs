//
//
// purpose: set render queue for all renderers within game object's hierarchy
//
//
// author: ge
//
// (c) 2017 innovation.rocks consulting gmbh
//

using UnityEngine;


public class RenderQueue : MonoBehaviour
{
    public int renderQueue = 2000;

    private void OnEnable ()
    {
        Renderer [] renderers = GetComponentsInChildren<Renderer> (true);
        foreach (Renderer renderer in renderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.renderQueue = renderQueue;
            }
        }
    }

}
