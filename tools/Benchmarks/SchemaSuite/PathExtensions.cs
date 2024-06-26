﻿using System;

namespace Json.Benchmarks.SchemaSuite;

public static class PathExtensions
{
	public static string AdjustForPlatform(this string path)
	{
		return Environment.OSVersion.Platform == PlatformID.MacOSX ||
			   Environment.OSVersion.Platform == PlatformID.Unix
			? path.Replace("\\", "/")
			: path.Replace("/", "\\");
	}
}