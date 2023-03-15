using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	public interface IKeyframeSourceFloat : IKeyframeSource<float>
	{

	}

	[Serializable]
	public class FloatKeyframeSource : IKeyframeSourceFloat
	{
		[SerializeField]
		private AnimationCurve _value = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		public float Evaluate(float progress)
		{
			return _value.Evaluate(progress);
		}
	}

	public class EventBasedAnimationFloat : EventBasedAnimation<float, IKeyframeSourceFloat, UnityEventFloat>
	{
	}
}
