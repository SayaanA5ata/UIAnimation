using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.TemporalAnimation
{
	public interface IKeyframeSourceColor : IKeyframeSource<Color>
	{

	}

	[Serializable]
	public class ColorRGBAKeyframeSource : IKeyframeSourceColor
	{
		[SerializeField]
		private AnimationCurve _r = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		[SerializeField]
		private AnimationCurve _g = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		[SerializeField]
		private AnimationCurve _b = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		[SerializeField]
		private AnimationCurve _a = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		public Color Evaluate(float progress)
		{
			return new Color(_r.Evaluate(progress), _g.Evaluate(progress), _b.Evaluate(progress), _a.Evaluate(progress));
		}
	}

	[Serializable]
	public class ColorAlphaKeyframeSource : IKeyframeSourceColor
	{
		[SerializeField]
		private Color _color = Color.white;

		[SerializeField]
		private AnimationCurve _alpha = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);
	

		public Color Evaluate(float progress)
		{
			return new Color(_color.r, _color.g, _color.b, _alpha.Evaluate(progress));
		}
	}

	[Serializable]
	public class TwoColorKeyframeSource : IKeyframeSourceColor
	{
		[SerializeField]
		private Color _color1 = Color.white;

		[SerializeField]
		private Color _color2 = Color.white;

		[SerializeField]
		private AnimationCurve _blend = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);


		public Color Evaluate(float progress)
		{
			return Color.Lerp(_color1, _color2, _blend.Evaluate(progress));
		}
	}

	public class EventBasedAnimationColor : EventBasedAnimation<Color, IKeyframeSourceColor, UnityEventColor>
	{
	}
}
