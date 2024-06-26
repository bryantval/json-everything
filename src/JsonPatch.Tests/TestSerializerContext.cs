﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Json.Patch.Tests.Suite;
using Json.Schema;

namespace Json.Patch.Tests;

[JsonSerializable(typeof(PatchExtensionTests.TestModel))]
[JsonSerializable(typeof(List<PatchExtensionTests.TestModel>))]
[JsonSerializable(typeof(List<PatchExtensionTests.TestModel>))]
[JsonSerializable(typeof(List<GithubTests.Target543>))]
[JsonSerializable(typeof(JsonPatchTest))]
[JsonSerializable(typeof(JsonPatchTestJsonConverter.Model))]
[JsonSerializable(typeof(JsonPatchTest[]))]
[JsonSerializable(typeof(Guid))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(int[]))]
[JsonSerializable(typeof(List<int>))]
[JsonSerializable(typeof(JsonElement))]
[JsonSerializable(typeof(JsonElement?))]
[JsonSerializable(typeof(JsonNode))]
[JsonSerializable(typeof(JsonPatch))]
[JsonSerializable(typeof(PatchResult))]
[JsonSerializable(typeof(EvaluationResults))]
internal partial class TestSerializerContext : JsonSerializerContext;