using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	public interface IKeyframeSourceVector2 : IKeyframeSource<Vector2>
	{

	}

	[Serializable]
	public class Vector2KeyframeSource : IKeyframeSourceVector2
	{
		[SerializeField]
		private AnimationCurve _x = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		[SerializeField]
		private AnimationCurve _y = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		public Vector2 Evaluate(float progress)
		{
			return new Vector3(_x.Evaluate(progress), _y.Evaluate(progress));
		}
	}

	[Serializable]
	public class Vector2OneKeyframeSource : IKeyframeSourceVector2
	{
		[SerializeField]
		private AnimationCurve _all = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		public Vector2 Evaluate(float progress)
		{
			var all = _all.Evaluate(progress);
			return new Vector3(all, all, all);
		}
	}

	public class EventBasedAnimationVector2 : EventBasedAnimation<Vector2, IKeyframeSourceVector2, UnityEventVector2>
	{
	}
}
