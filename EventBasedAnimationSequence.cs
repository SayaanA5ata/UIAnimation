using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	public class EventBasedAnimationSequence : EventBasedAnimation
	{
		[SerializeField]
		private UnityEventFloat _onUpdate;

		public override void Apply()
		{
			_onUpdate?.Invoke(LocalProgress);
		}
	}
}
