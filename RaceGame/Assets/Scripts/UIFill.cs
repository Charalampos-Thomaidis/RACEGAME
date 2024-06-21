using UnityEngine;
using UnityEngine.UI;

public class UIFill : MonoBehaviour
{

	public Rigidbody objectToMeasure;
	public float maxVelocity = 10.0f;
	public bool disallowBackwards = false;

	public Image image;

	void Start()
	{
		image = GetComponent<Image>();
	}

	void Update()
	{
		if (!disallowBackwards || Vector3.Dot(objectToMeasure.velocity, objectToMeasure.transform.forward) > 0.0f)
		{
			image.fillAmount = objectToMeasure.velocity.magnitude / maxVelocity;
		}
		else
		{
			image.fillAmount = 0.0f;
		}
	}
}