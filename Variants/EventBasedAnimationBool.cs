using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	public interface IBoolKeyframeSource : IKeyframeSource<bool>
	{

	}

	[Serializable]
	public class StepKeyframesource : IBoolKeyframeSource
	{
		// Fields

		[SerializeField]
		[Range(0f, 1f)]
		private float _step = 0.5f;

		[SerializeField]
		private AnimationCurve _value = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);


		// Methods

		public bool Evaluate(float progress)
		{
			return _value.Evaluate(progress) >= _step;
		}
	}

	public class EventBasedAnimationBool : EventBasedAnimation<bool, IBoolKeyframeSource, UnityEventBool>
	{
	
	}
}
