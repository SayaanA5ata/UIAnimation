using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI.TemporalAnimation
{
	public interface IKeyframeSource<TValue>
	{
		TValue Evaluate(float progress);
	}

	[ExecuteInEditMode]
	public abstract class EventBasedAnimation : MonoBehaviour
	{
		// Fields
		[SerializeField]
		[Range(0f, 1f)]
		protected float _progress = 0f;

		[SerializeField]
		[Range(0f, 1f)]
		protected float _begin = 0f;

		[SerializeField]
		[Range(0f, 1f)]
		protected float _end = 1f;

		private bool _isDirty = true;

		[SerializeField]
		protected UnityEvent onAnimationStarted;
		// Properties

		public float Progress
		{
			get => _progress;
			set
			{
				if (!Mathf.Approximately(_progress, value))
				{
					if(_progress == 0 && value != 0)
					{
						onAnimationStarted?.Invoke();
					}
					_progress = Mathf.Clamp01(value);
					_isDirty = true;
				}
			}
		}

		public float Begin 
		{
			get => _begin;
			set
			{
				_begin = Mathf.Clamp01(value);
				_isDirty = true;
			}
		}

		public float End
		{
			get => _end;
			set
			{
				_end = Mathf.Clamp01(value);
				_isDirty = true;
			}
		}

		public float LocalProgress => Mathf.Clamp01(Mathf.InverseLerp(_begin, _end, _progress));


		// Messages

		protected virtual void OnValidate()
		{
			_isDirty = true;
		}

		protected virtual void Update()
		{
			if(!_isDirty)
			{
				return;
			}

			Apply();

			_isDirty = false;
		}


		// Methods

		public abstract void Apply();
	}

	public abstract class EventBasedAnimation<TValue, TKeyframeSource, TEvent> : EventBasedAnimation
		where TKeyframeSource : IKeyframeSource<TValue>
		where TEvent : UnityEvent<TValue>
	{
		// Fields

		[SerializeReference]
		private TKeyframeSource _source;

		[SerializeField]
		private TEvent _onUpdate;


		// Methods

		public override void Apply()
		{
			if (_source == null)
			{
				return;
			}
			_onUpdate?.Invoke(_source.Evaluate(LocalProgress));
		}
	}
}
