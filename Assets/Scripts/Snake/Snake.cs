using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float tailspringls;
	[SerializeField]  private SnakeHead head;

	[SerializeField] private int tailSize;

	private TailGenerator tailsGenerator;
	private List<Segment> tail;
	private SnakeInput input;


	public event UnityAction<int> SizeUpdated;

	private void Awake()
	{
		tailsGenerator = GetComponent<TailGenerator>();
		input = GetComponent<SnakeInput>();
		tail = tailsGenerator.Generate(tailSize);
		//SizeUpdated?.Invoke(tail.Count);
	}

	private void Start()
	{
		SizeUpdated?.Invoke(tail.Count);
	}

	private void FixedUpdate()
	{
		Move(head.transform.position + head.transform.up * speed * Time.fixedDeltaTime);
		head.transform.up = input.GetDirectionToClick(head.transform.position);
	}

	private void Move(Vector3 nextPosition) {
		Vector3 previousPosition = head.transform.position;

		foreach (var segment in tail) {
			Vector3 tempPosition = segment.transform.position;
			segment.transform.position = Vector2.Lerp(segment.transform.position,previousPosition, tailspringls * Time.deltaTime);
			previousPosition = tempPosition;
		}

		head.Move(nextPosition);
	}


	private void OnEnable()
	{
		head.BlockCollided += OnBlockCollided;
		head.BonusCollected += OnBonusCollected;

	}

	private void OnDisable()
	{
		head.BlockCollided -= OnBlockCollided;
		head.BonusCollected -= OnBonusCollected;

	}
	private void OnBonusCollected(int bonusSize)
	{
		tail.AddRange(tailsGenerator.Generate(bonusSize));
		SizeUpdated?.Invoke(tail.Count);
	}
	private void OnBlockCollided() {
		Segment deletedSegment = tail[tail.Count - 1];
		tail.Remove(deletedSegment);
		Destroy(deletedSegment.gameObject);
		SizeUpdated?.Invoke(tail.Count);
	}


}
