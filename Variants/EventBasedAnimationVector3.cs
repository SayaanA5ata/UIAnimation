using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	public interface IKeyframeSourceVector3 : IKeyframeSource<Vector3>
	{

	}

	[Serializable]
	public class Vector3KeyframeSource : IKeyframeSourceVector3
	{
		[SerializeField]
		private AnimationCurve _x = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		[SerializeField]
		private AnimationCurve _y = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		[SerializeField]
		private AnimationCurve _z = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		public Vector3 Evaluate(float progress)
		{
			return new Vector3(_x.Evaluate(progress), _y.Evaluate(progress), _z.Evaluate(progress));
		}
	}

	[Serializable]
	public class Vector3OneKeyframeSource : IKeyframeSourceVector3
	{
		[SerializeField]
		private AnimationCurve _all = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		public Vector3 Evaluate(float progress)
		{
			var all = _all.Evaluate(progress);
			return new Vector3(all, all, all);
		}
	}

	public class EventBasedAnimationVector3 : EventBasedAnimation<Vector3, IKeyframeSourceVector3, UnityEventVector3>
	{
	}
}
