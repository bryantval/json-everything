﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Json.More;

namespace Json.Schema
{
	public static partial class MetaSchemas
	{
		public static readonly Uri Draft6_Id = new Uri("http://json-schema.org/draft-06/schema#");

		public static readonly JsonSchema Draft6 = new JsonSchemaBuilder()
			.Schema(Draft6_Id)
			.Id(Draft6_Id)
			.Title("Core schema meta-schema")
			.Definitions(
				("schemaArray", new JsonSchemaBuilder()
					.Type(SchemaValueType.Array)
					.MinItems(1)
					.Items(JsonSchemaBuilder.RefRoot())
				),
				("nonNegativeInteger", new JsonSchemaBuilder()
					.Type(SchemaValueType.Integer)
					.Minimum(0)
				),
				("nonNegativeIntegerDefault0", new JsonSchemaBuilder()
					.AllOf(
						new JsonSchemaBuilder().Ref("#/definitions/nonNegativeInteger"),
						new JsonSchemaBuilder().Default(0.AsJsonElement())
					)
				),
				("simpleTypes", new JsonSchemaBuilder()
					.Enum("array".AsJsonElement(),
						"boolean".AsJsonElement(),
						"integer".AsJsonElement(),
						"null".AsJsonElement(),
						"number".AsJsonElement(),
						"object".AsJsonElement(),
						"string".AsJsonElement())
				),
				("stringArray", new JsonSchemaBuilder()
					.Type(SchemaValueType.Array)
					.Items(new JsonSchemaBuilder().Type(SchemaValueType.String))
					.UniqueItems(true)
					.Default(Enumerable.Empty<JsonElement>().AsJsonElement())
				)
			)
			.Type(SchemaValueType.Object | SchemaValueType.Boolean)
			.Properties(
				("$id", new JsonSchemaBuilder()
					.Type(SchemaValueType.String)
					.Format(Formats.UriReference)
				),
				("$schema", new JsonSchemaBuilder()
					.Type(SchemaValueType.String)
					.Format(Formats.UriReference)
				),
				("$ref", new JsonSchemaBuilder()
					.Type(SchemaValueType.String)
					.Format(Formats.UriReference)
				),
				("title", new JsonSchemaBuilder()
					.Type(SchemaValueType.String)
				),
				("description", new JsonSchemaBuilder()
					.Type(SchemaValueType.String)
				),
				("default", JsonSchema.Empty),
				("examples", new JsonSchemaBuilder()
					.Type(SchemaValueType.Array)
					.Items(JsonSchema.Empty)
				),
				("multipleOf", new JsonSchemaBuilder()
					.Type(SchemaValueType.Number)
					.ExclusiveMinimum(0)
				),
				("maximum", new JsonSchemaBuilder()
					.Type(SchemaValueType.Number)
				),
				("exclusiveMaximum", new JsonSchemaBuilder()
					.Type(SchemaValueType.Number)
				),
				("minimum", new JsonSchemaBuilder()
					.Type(SchemaValueType.Number)
				),
				("exclusiveMinimum", new JsonSchemaBuilder()
					.Type(SchemaValueType.Number)
				),
				("maxLength", new JsonSchemaBuilder()
					.Ref("#/definitions/nonNegativeInteger")
				),
				("minLength", new JsonSchemaBuilder()
					.Ref("#/definitions/nonNegativeIntegerDefault0")
				),
				("pattern", new JsonSchemaBuilder()
					.Type(SchemaValueType.String)
					.Format(Formats.Regex)
				),
				("additionalItems", JsonSchemaBuilder.RefRoot()),
				("items", new JsonSchemaBuilder()
					.AnyOf(
						JsonSchemaBuilder.RefRoot(),
						new JsonSchemaBuilder().Ref("#/definitions/schemaArray")
					)
					.Default(new Dictionary<string, JsonElement>().AsJsonElement())
				),
				("maxItems", new JsonSchemaBuilder().Ref("#/definitions/nonNegativeInteger")),
				("minItems", new JsonSchemaBuilder().Ref("#/definitions/nonNegativeIntegerDefault0")),
				("uniqueItems", new JsonSchemaBuilder()
					.Type(SchemaValueType.Boolean)
					.Default(false.AsJsonElement())
				),
				("contains", JsonSchemaBuilder.RefRoot()),
				("maxProperties", new JsonSchemaBuilder().Ref("#/definitions/nonNegativeInteger")),
				("minProperties", new JsonSchemaBuilder().Ref("#/definitions/nonNegativeIntegerDefault0")),
				("required", new JsonSchemaBuilder().Ref("#/definitions/stringArray")),
				("additionalProperties", JsonSchemaBuilder.RefRoot()),
				("definitions", new JsonSchemaBuilder()
					.Type(SchemaValueType.Object)
					.AdditionalProperties(JsonSchemaBuilder.RefRoot())
					.Default(new Dictionary<string, JsonElement>().AsJsonElement())
				),
				("properties", new JsonSchemaBuilder()
					.Type(SchemaValueType.Object)
					.AdditionalProperties(JsonSchemaBuilder.RefRoot())
					.Default(new Dictionary<string, JsonElement>().AsJsonElement())
				),
				("patternProperties", new JsonSchemaBuilder()
					.Type(SchemaValueType.Object)
					.AdditionalProperties(JsonSchemaBuilder.RefRoot())
					.Default(new Dictionary<string, JsonElement>().AsJsonElement())
				),
				("dependencies", new JsonSchemaBuilder()
					.Type(SchemaValueType.Object)
					.AdditionalProperties(new JsonSchemaBuilder()
						.AnyOf(
							JsonSchemaBuilder.RefRoot(),
							new JsonSchemaBuilder().Ref("#/definitions/stringArray")
						)
					)
				),
				("propertyNames", JsonSchemaBuilder.RefRoot()),
				("const", JsonSchema.Empty),
				("enum", new JsonSchemaBuilder()
					.Type(SchemaValueType.Array)
					.MinItems(1)
					.UniqueItems(true)
				),
				("type", new JsonSchemaBuilder()
					.AnyOf(
						new JsonSchemaBuilder().Ref("#/definitions/simpleTypes"),
						new JsonSchemaBuilder()
							.Type(SchemaValueType.Array)
							.Items(new JsonSchemaBuilder().Ref("#/definitions/simpleTypes"))
							.MinItems(1)
							.UniqueItems(true)
					)
				),
				("format", new JsonSchemaBuilder().Type(SchemaValueType.String)),
				("allOf", new JsonSchemaBuilder().Ref("#/definitions/schemaArray")),
				("anyOf", new JsonSchemaBuilder().Ref("#/definitions/schemaArray")),
				("oneOf", new JsonSchemaBuilder().Ref("#/definitions/schemaArray")),
				("not", JsonSchemaBuilder.RefRoot())
			)
			.Default(new Dictionary<string, JsonElement>().AsJsonElement());
	}
}