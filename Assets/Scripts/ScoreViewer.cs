using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
	private DiceController[] _diceControllers;
	[SerializeField] private TextMeshProUGUI _text;

	private void Start()
	{
		_diceControllers = FindObjectsOfType<DiceController>();
	}

	private void Update()
	{
		int totalScore = 0;
		bool arePlane = true;
		foreach (DiceController diceController in _diceControllers)
		{
			totalScore += diceController.CurrentScore;

			if (diceController.IsPlaned == false)
			{
				arePlane = false;
			}
		}

		_text.color = arePlane ? Color.blue : Color.red;
		_text.text = totalScore.ToString();
	}
}
