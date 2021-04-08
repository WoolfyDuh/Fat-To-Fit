using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExcitementBar : MonoBehaviour
{
    private Slider slider;
	private Action emptyMeterCallback;
	private bool hasBeenCalled = false;
	private float decayRate = 0.35f;
	private float maxExcitement = 1000;
	// Start is called before the first frame update
	private void Awake()
	{
		slider = GetComponent<Slider>();
	}

	private void Start()
	{
		slider.maxValue = maxExcitement;
		RefillMeter();
	}

	// Update is called once per frame
	void LateUpdate()
    {
		if (slider.value > slider.minValue)
			slider.value -= decayRate;
		else if(slider.value <= 0 && !hasBeenCalled)
			emptyMeterCallback();
		
    }

	#region public functions
	public void SetDecayRate(int amount) => decayRate = amount;
	public void RefillMeter()
	{
		slider.value = maxExcitement;
		hasBeenCalled = false; 
	}
	public void FillMeter(float amount) => slider.value += amount;
	public void OnMeterEmpty(Action callback)
	{
		emptyMeterCallback += callback;
		hasBeenCalled = true;
		Debug.Log("Function added to callback");
	}
	/// <summary>
	///  set the max value of the excitement meter based on amount
	/// </summary>
	/// <param name="amount"></param>
	public void SetMaxExcitement(int amount)
	{
		maxExcitement = amount;
		slider.maxValue = maxExcitement;
	}
	/// <summary>
	/// set the max value of the excitement meter and wether or not meter should be refilled
	/// </summary>
	/// <param name="amount"></param>
	/// <param name="refresh"></param>
	public void SetMaxExcitement(float amount, bool refresh)
	{
		maxExcitement = amount;
		slider.maxValue = maxExcitement;
		RefillMeter();
	}
#endregion
}
