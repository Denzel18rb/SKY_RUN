using UnityEngine;

public class ParallaxVelocityBG : MonoBehaviour
{
    [System.Serializable]
    public class Layer
    {
        public SpriteRenderer spriteRenderer;
        public float speed = 1f;

        [HideInInspector] public Vector2 offset;
        [HideInInspector] public Material materialInstance;
    }

    public float baseSpeed = 2f;
    public Layer[] layers;

    void Start()
    {
        foreach (Layer layer in layers)
        {
            if (layer.spriteRenderer != null)
            {
                // Crear instancia del material para no afectar otros sprites
                layer.materialInstance = Instantiate(layer.spriteRenderer.material);
                layer.spriteRenderer.material = layer.materialInstance;
            }
        }
    }

    void Update()
    {
        foreach (Layer layer in layers)
        {
            if (layer.materialInstance == null) continue;

            float movement = baseSpeed * layer.speed * Time.deltaTime;
            layer.offset.x += movement;

            layer.materialInstance.mainTextureOffset = layer.offset;
        }
    }
}
