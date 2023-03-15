using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	public interface ISpriteKeyframeSource : IKeyframeSource<Sprite>
	{

	}

	[Serializable]
	public class SpritesheetKeyframeSource : ISpriteKeyframeSource
	{
		[SerializeField]
		private List<Sprite> _sprites = new List<Sprite>();

		public Sprite Evaluate(float progress)
		{
			if(_sprites == null || _sprites.Count == 0)
			{
				return null;
			}

			return _sprites[(int)Mathf.Lerp(0, _sprites.Count - 1, progress)];
		}
	}

	public class EventBasedAnimationSprite : EventBasedAnimation<Sprite, ISpriteKeyframeSource, UnityEventSprite>
	{

	}
}
