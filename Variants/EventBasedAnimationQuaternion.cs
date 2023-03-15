using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	[Serializable]
	public class QuaternionKeyframeSource : IKeyframeSource<Quaternion>
	{
		[SerializeField]
		private AnimationCurve _rotationX = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		[SerializeField]
		private AnimationCurve _rotationY = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		[SerializeField]
		private AnimationCurve _rotationZ = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);


		public Quaternion Evaluate(float progress)
		{
			return Quaternion.Euler(_rotationX.Evaluate(progress), _rotationY.Evaluate(progress), _rotationZ.Evaluate(progress));
		}
	}

	[Serializable]
	public class EventBasedAnimationQuaternion : EventBasedAnimation<Quaternion, QuaternionKeyframeSource, UnityEventQuaternion>
	{
	}
}
