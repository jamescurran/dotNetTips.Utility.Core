﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Standard.Common
// Author           : David McCarter
// Created          : 07-29-2020
//
// Last Modified By : David McCarter
// Last Modified On : 11-19-2020
// ***********************************************************************
// <copyright file="InformationAttribute.cs" company="David McCarter - dotNetTips.com">
//     McCarter Consulting (David McCarter)
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace dotNetTips.Utility.Standard.Common
{
	/// <summary>
	/// BenchMarkStatus attribute to add more meta data for types.
	/// </summary>
	/// <remarks>For use in InformationAttribute.</remarks>
	[Information(description: "For use in InformationAttribute.", author: "David McCarter", createdOn: "7/29/2020", modifiedOn: "8/4/2020", BenchMarkStatus = BenchMarkStatus.NotRequired, Status = Status.Available)]
	public enum BenchMarkStatus
	{
		/// <summary>
		/// No benchmark.
		/// </summary>
		None,

		/// <summary>
		/// Benchmark is not required
		/// </summary>
		NotRequired,

		/// <summary>
		/// Benchmark work is in progress.
		/// </summary>
		WIP,

		/// <summary>
		/// Benchmarks done.
		/// </summary>
		Completed,
	}

	/// <summary>
	/// Information status.
	/// </summary>
	/// <remarks>For use in InformationAttribute.</remarks>
	[Information(description: "For use in InformationAttribute.", author: "David McCarter", createdOn: "7/29/2020", modifiedOn: "8/4/2020", BenchMarkStatus = BenchMarkStatus.NotRequired, Status = Status.Available)]
	public enum Status
	{
		/// <summary>
		/// The not set
		/// </summary>
		NotSet,

		/// <summary>
		/// New method or class.
		/// </summary>
		New,

		/// <summary>
		/// Method or class is available for use (from other assemblies).
		/// </summary>
		Available,

		/// <summary>
		/// Method or class not in use.
		/// </summary>
		NotUsed,
	}

	/// <summary>
	/// Class InformationAttribute. This class cannot be inherited.
	/// Implements the <see cref="System.Attribute" />.
	/// </summary>
	/// <seealso cref="System.Attribute" />
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Delegate, Inherited = false)]
	public sealed class InformationAttribute : Attribute
	{
		/// <summary>
		/// The unit test coverage.
		/// </summary>
		private double _unitTestCoverage = 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="InformationAttribute" /> class.
		/// </summary>
		public InformationAttribute()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InformationAttribute"/> class.
		/// </summary>
		/// <param name="description">The description.</param>
		public InformationAttribute(string description)
			: this(description, string.Empty, string.Empty, string.Empty)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InformationAttribute" /> class.
		/// </summary>
		/// <param name="description">The message.</param>
		/// <param name="author">The author.</param>
		/// <param name="createdOn">The created on.</param>
		public InformationAttribute(string description, string author, string createdOn)
			: this(description, author, createdOn, createdOn)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InformationAttribute" /> class.
		/// </summary>
		/// <param name="description">The message.</param>
		/// <param name="author">The author.</param>
		/// <param name="createdOn">The created on.</param>
		/// <param name="modifiedOn">The modified on.</param>
		public InformationAttribute(string description, string author, string createdOn, string modifiedOn)
		{
			this.Description = description;

			this.Author = string.IsNullOrEmpty(author) ? Resources.UserUnkown : author;

			if (string.IsNullOrEmpty(createdOn) == false && DateTimeOffset.TryParse(createdOn, out DateTimeOffset createdDate))
			{
				this.CreatedOn = createdDate;

				if (string.IsNullOrEmpty(modifiedOn) == DateTimeOffset.TryParse(modifiedOn, out DateTimeOffset modifiedDate))
				{
					this.ModifiedOn = modifiedDate;
				}
			}

			if (string.IsNullOrEmpty(this.ModifiedBy))
			{
				this.ModifiedBy = author;
			}
		}

		/// <summary>
		/// Gets the author.
		/// </summary>
		/// <value>The author.</value>
		public string Author { get; }

		/// <summary>
		/// Gets or sets the benchmark status.
		/// </summary>
		/// <value>The bench mark status.</value>
		public BenchMarkStatus BenchMarkStatus { get; set; } = BenchMarkStatus.None;

		/// <summary>
		/// Gets the created on date.
		/// </summary>
		/// <value>The created on.</value>
		public DateTimeOffset CreatedOn { get; }

		/// <summary>
		/// Gets the description of the type, method or event.
		/// </summary>
		/// <value>The message.</value>
		public string Description { get; }

		/// <summary>
		/// Gets or sets the modified by.
		/// </summary>
		/// <value>The modified by.</value>
		public string ModifiedBy { get; set; }

		/// <summary>
		/// Gets the modified on date.
		/// </summary>
		/// <value>The modified on.</value>
		public DateTimeOffset ModifiedOn { get; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public Status Status { get; set; } = Status.NotSet;

		/// <summary>
		/// Gets or sets the unit test coverage.
		/// </summary>
		/// <value>The unit test coverage.</value>
		/// <exception cref="ArgumentOutOfRangeException">UnitTestCoverage - Unit test coverage must be in the range of 0 - 100.</exception>
		/// <remarks>Value must be between 0 - 100.</remarks>
		public double UnitTestCoverage
		{
			get => this._unitTestCoverage;
			set
			{
				this._unitTestCoverage = IsInRange(value, 0, 100) ? value : throw new ArgumentOutOfRangeException(nameof(this.UnitTestCoverage), "Unit test coverage must be in the range of 0 - 100.");
			}
		}

		/// <summary>
		/// Determines whether [is in range] [the specified value].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="lower">The lower.</param>
		/// <param name="upper">The upper.</param>
		/// <returns><c>true</c> if [is in range] [the specified value]; otherwise, <c>false</c>.</returns>
		private static bool IsInRange(double value, double lower, double upper)
		{
			return value >= lower && value <= upper;
		}
	}
}
