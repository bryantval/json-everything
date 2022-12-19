﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Json.Path;

/// <summary>
/// Represents a JSON Path.
/// </summary>
[JsonConverter(typeof(JsonPathConverter))]
public class JsonPath
{
	private readonly IEnumerable<PathSegment> _segments;

	public static JsonPath Root { get; } = new(PathScope.Global, Enumerable.Empty<PathSegment>());

	public PathScope Scope { get; }

	internal JsonPath(PathScope scope, IEnumerable<PathSegment> segments)
	{
		Scope = scope;
		_segments = segments;
	}

	/// <summary>
	/// Parses a <see cref="JsonPath"/> from a string.
	/// </summary>
	/// <param name="source">The source string.</param>
	/// <returns>The parsed path.</returns>
	/// <exception cref="PathParseException">Thrown if a syntax error occurred.</exception>
	public static JsonPath Parse(string source) => PathParser.Parse(source);

	/// <summary>
	/// Evaluates the path against a JSON instance.
	/// </summary>
	/// <param name="root">The root of the JSON instance.</param>
	/// <param name="options">Evaluation options.</param>
	/// <returns>The results of the evaluation.</returns>
	public PathResult Evaluate(JsonNode? root, PathEvaluationOptions? options = null)
	{
		IEnumerable<PathMatch> currentMatches = new[] { new PathMatch(root, Root) };

		foreach (var segment in _segments)
		{
			currentMatches = currentMatches.SelectMany(x => segment.Evaluate(x.Value));
		}

		return new PathResult(currentMatches.ToList());
	}

	/// <summary>Returns a string that represents the current object.</summary>
	/// <returns>A string that represents the current object.</returns>
	public override string ToString()
	{
		var builder = new StringBuilder();

		BuildString(builder);

		return builder.ToString();
	}

	public void BuildString(StringBuilder builder)
	{
		builder.Append(Scope == PathScope.Global ? '$' : '@');

		foreach (var segment in _segments)
		{
			segment.BuildString(builder);
		}
	}
}

public class PathEvaluationOptions
{
	
}