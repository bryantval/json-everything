﻿using System;
using System.Text.Json.Nodes;

namespace Json.Schema;

public class KeywordEvaluation
{
	private bool _evaluated;
	private bool _skipped;

	internal static KeywordEvaluation Skip { get; } = new() { _skipped = true };

	public JsonNode? LocalInstance { get; }
	public EvaluationResults Results { get; }

	public KeywordEvaluation[] SiblingEvaluations { get; set; } = Array.Empty<KeywordEvaluation>();
	public SchemaEvaluation[] ChildEvaluations { get; set; } = Array.Empty<SchemaEvaluation>();

	internal Guid Id { get; set; }
	internal KeywordConstraint Constraint { get; }

	internal KeywordEvaluation(KeywordConstraint constraint, JsonNode? localInstance, EvaluationResults results)
	{
		Constraint = constraint;
		LocalInstance = localInstance;
		Results = results;
	}
	private KeywordEvaluation(){}

	public void MarkAsSkipped()
	{
		_skipped = true;
	}

	internal void Evaluate(ConstraintBuilderContext context)
	{
		if (_evaluated || _skipped) return;

		foreach (var evaluation in ChildEvaluations)
		{
			evaluation.Evaluate(context);
		}

		Constraint.Evaluator(this, context); // this can change _skipped

		if (!_skipped)
		{
			foreach (var evaluation in ChildEvaluations)
			{
				Results.AddNestedResult(evaluation.Results);
			}
		}

		_evaluated = true;
	}
}