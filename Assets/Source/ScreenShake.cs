using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {
    public float baseIntensity = 1f;
    public float shakeTime = 0.3f;

    private float scale = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ShakeCamera(float intensityScale)
    {
        scale = intensityScale;
        InvokeRepeating("Shake", 0f, Time.fixedDeltaTime);
        Invoke("StopShake", shakeTime);
    }

    private void Shake()
    {
        float sampleIndex = Random.Range(0f, 1000f);
        float xNoise = Mathf.Clamp(Mathf.PerlinNoise(Time.realtimeSinceStartup, sampleIndex), 0f, 1f) - 0.5f;
        float yNoise = Mathf.Clamp(Mathf.PerlinNoise(sampleIndex, Time.realtimeSinceStartup), 0f, 1f) - 0.5f;
        xNoise *= scale * baseIntensity;
        yNoise *= scale * baseIntensity;

        gameObject.transform.Translate(xNoise, yNoise, 0f);
    }

    private void StopShake()
    {
        CancelInvoke("Shake");
        gameObject.transform.position = new Vector3(0f, 0f, gameObject.transform.position.z);
    }
}
