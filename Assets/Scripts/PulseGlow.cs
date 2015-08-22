using UnityEngine;
using System.Collections;

public class PulseGlow : MonoBehaviour {

	public float pulseMin = 0.5f;
	public float pulseMax = 0.75f;
	public float pulseSpeed = 0.01f;

	private float currPulse;
	private bool dir = true;

	// Use this for initialization
	void Start () {
	
		SetShaderProperty( pulseMin );

	}

	// Update is called once per frame
	void Update () {
	
		if( dir )
		{
			SetShaderProperty( currPulse += pulseSpeed );
			if( currPulse >= pulseMax )
			{
				dir = false;
			}
		}
		else
		{
			SetShaderProperty( currPulse -= pulseSpeed );
			if( currPulse <= pulseMin )
			{
				dir = true;
			}
		}

	}

	private void SetShaderProperty( float value )
	{
		currPulse = value;
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		renderer.material.SetFloat( "_EmissionGain", currPulse );
	}
}
