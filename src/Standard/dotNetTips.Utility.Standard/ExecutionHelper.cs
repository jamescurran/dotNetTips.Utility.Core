﻿// ***********************************************************************
// Assembly         :
// Author           : David McCarter
// Created          : 01-21-2020
//
// Last Modified By : David McCarter
// Last Modified On : 11-11-2020
// ***********************************************************************
// <copyright file="ExecutionHelper.cs" company="David McCarter - dotNetTips.com">
//     Copyright (c) David McCarter - dotNetTips.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using dotNetTips.Utility.Standard.Extensions;
using dotNetTips.Utility.Standard.OOP;

namespace dotNetTips.Utility.Standard
{
	/// <summary>
	/// Helper class for executing methods.
	/// </summary>
	public static class ExecutionHelper
	{
		/// <summary>
		/// Progressive retry for a function call.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <param name="retryCount">The retry count (default 3).</param>
		/// <param name="retryWaitMilliseconds">The retry wait milliseconds (default 100).</param>
		/// <returns>System.Int32.</returns>
		public static int ProgressiveRetry(Action operation, byte retryCount = 3, int retryWaitMilliseconds = 100)
		{
			Encapsulation.TryValidateParam<ArgumentNullException>(operation != null);
			Encapsulation.TryValidateParam<ArgumentOutOfRangeException>(retryCount > 0);
			Encapsulation.TryValidateParam<ArgumentOutOfRangeException>(retryWaitMilliseconds > 0);

			var attempts = 0;

			do
			{
				try
				{
					attempts++;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
					operation();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

					return attempts;
				}
				catch (Exception ex)
				{
					// Using Exception since the actual exception is unknown beforehand.
					if (attempts == retryCount)
					{
						throw;
					}

					Debug.WriteLine(ex.GetAllMessages());

					Task.Delay(retryWaitMilliseconds * attempts).Wait();
				}
			} while (true);
		}
	}
}
