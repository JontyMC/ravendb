﻿using System;
using Raven.Client.Listeners;
using Raven.Json.Linq;
using Raven.Tests.Bugs;
using Raven.Tests.Document;

namespace Raven.Tryouts
{
	class Program
	{
		static void Main()
		{
			for (int i = 0; i < 8462; i++)
			{
				Console.WriteLine(i);
				using (var conflictsWithIis = new ConflictsWithIIS())
					conflictsWithIis.InnefficientMultiThreadedInsert();
			}
		}
	}
}
