using UnityEngine;

public class WaterGrowth : MonoBehaviour
{
    [SerializeField] private bool isGrowing = false;
    [SerializeField] private Vector3 maxScale = new Vector3(2f, 2f, 2f);
    [SerializeField] private Vector3 maxScaleParticles = new Vector3(1f, 1f, 0.1f);
    [SerializeField] private float growthSpeed = 1f;

    public HackObject hack;
    public GameObject electricityParent;
    private ParticleSystem electricityEffect;

    private Vector3 initialScale;

    private void Start()
    {
        electricityEffect = electricityParent.gameObject.GetComponent<ParticleSystem>();
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if(hack.isHacked)
        {
            SetGrowth(true);
        }
        else
        {
            SetGrowth(false);
        }

        if (isGrowing)
        {
            GrowObject();
        }
    }

    private void GrowObject()
    {
        if (transform.localScale.x < maxScale.x || transform.localScale.y < maxScale.y || transform.localScale.z < maxScale.z)
        {
            Vector3 newScale = transform.localScale + Vector3.one * growthSpeed * Time.deltaTime;
            transform.localScale = new Vector3(
                Mathf.Min(newScale.x, maxScale.x),
                Mathf.Min(newScale.y, maxScale.y),
                Mathf.Min(newScale.z, maxScale.z)
            );

            Vector3 newScaleElectricity = electricityEffect.transform.localScale + Vector3.one * growthSpeed * Time.deltaTime;
            electricityEffect.transform.localScale = new Vector3(
                Mathf.Min(newScaleElectricity.x, maxScaleParticles.x),
                Mathf.Min(newScaleElectricity.y, maxScaleParticles.y),
                Mathf.Min(newScaleElectricity.z, maxScaleParticles.z)
            );
            
            var stealShape = electricityEffect.shape;
            stealShape.radius = transform.localScale.x * 2;
        }
    }

    public void SetGrowth(bool value)
    {
        isGrowing = value;
    }
}

