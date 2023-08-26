using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    [SerializeField] private Transform targetTransform;
	
    // How long the object should shake for.
    private float shakeDuration = 0f;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    [SerializeField] private float shakeAmount = 0.7f;
    [SerializeField] private float decreaseFactor = 1.0f;
	
    Vector3 originalPos;
	
    void Awake()
    {
        if (targetTransform == null)
        {
            Debug.LogError("Target transform must be set, Destroying component...");
            Destroy(this);
        }
    }
	
    void OnEnable()
    {
        originalPos = targetTransform.localPosition;
    }

    public void Shake(float duration, float amount, float decreasePerTime)
    {
        shakeDuration = duration;
        shakeAmount = amount;
        decreaseFactor = decreasePerTime;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            targetTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            targetTransform.localPosition = originalPos;
        }
    }

    private void Reset()
    {
        targetTransform = this.transform;
    }
}