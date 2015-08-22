using UnityEngine;
using System.Collections;

public class PulseGlow : MonoBehaviour {

	public float pulseMin = 0.5f;
	public float pulseMax = 0.75f;
	public float pulseSpeedMin = 0.01f;
	public float pulseSpeedMax = 0.01f;

	private float pulseSpeed;
	private float currPulse;
	private bool dir = true;

	// Use this for initialization
	void Start () {
	
		SetPulseSpeed();
		SetShaderProperty( pulseMin );

	}

	// Update is called once per frame
	void Update () {
	
		if( dir )
		{
			SetShaderProperty( currPulse += pulseSpeed );
			if( currPulse >= pulseMax )
			{
				SetPulseSpeed();
				dir = false;
			}
		}
		else
		{
			SetShaderProperty( currPulse -= pulseSpeed );
			if( currPulse <= pulseMin )
			{
				SetPulseSpeed();
				dir = true;
			}
		}

	}

	private void SetPulseSpeed()
	{
		pulseSpeed = Random.Range( pulseSpeedMin, pulseSpeedMax );
	}

	private void SetShaderProperty( float value )
	{
		currPulse = value;
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		renderer.material.SetFloat( "_EmissionGain", currPulse );
	}
}
