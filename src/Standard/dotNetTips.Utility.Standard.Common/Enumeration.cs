﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Standard.Common
// Author           : David McCarter
// Created          : 12-27-2020
//
// Last Modified By : David McCarter
// Last Modified On : 01-07-2021
// ***********************************************************************
// <copyright file="Enumeration.cs" company="David McCarter -  dotNetTips.com">
//     McCarter Consulting (David McCarter)
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using dotNetTips.Utility.Standard.Common;

namespace dotNetTips.Utility.Standard
{
    /// <summary>
    /// Enumeration class.
    /// Implements the <see cref="System.IComparable" />.
    /// </summary>
    /// <seealso cref="System.IComparable" />
    /// <remarks>Original code by: Jimmy Bogard.</remarks>
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// The display name.
        /// </summary>
        private readonly string _displayName;

        /// <summary>
        /// The value.
        /// </summary>
        private readonly int _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration" /> class.
        /// </summary>
        public Enumeration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="displayName">The display name.</param>
        [Information(nameof(Enumeration), UnitTestCoverage = 100, Status = Status.Available)]
        protected Enumeration(int value, string displayName)
        {
            this._value = value;
            this._displayName = displayName;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [Information(nameof(DisplayName), UnitTestCoverage = 100, Status = Status.Available)]
        public string DisplayName
        {
            get { return this._displayName; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [Information(nameof(Value), UnitTestCoverage = 0, Status = Status.Available)]
        public int Value
        {
            get { return this._value; }
        }

        /// <summary>
        /// Absolutes the difference.
        /// </summary>
        /// <param name="firstValue">The first value.</param>
        /// <param name="secondValue">The second value.</param>
        /// <returns>System.Int32.</returns>
        [Information(nameof(AbsoluteDifference), UnitTestCoverage = 0, Status = Status.Available)]
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            if (firstValue is null)
            {
                ExceptionThrower.ThrowArgumentNullException(nameof(firstValue));
            }

            if (secondValue is null)
            {
                ExceptionThrower.ThrowArgumentNullException(nameof(secondValue));
            }

            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);

            return absoluteDifference;
        }

        /// <summary>
        /// Convert display name to Enumeration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName">The display name.</param>
        /// <returns>T.</returns>
        [Information(nameof(FromDisplayName), UnitTestCoverage = 0, Status = Status.Available)]
        public static T FromDisplayName<T>(string displayName)
            where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);

            return matchingItem;
        }

        /// <summary>
        /// Converts number value to enumeration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        [Information(nameof(FromValue), UnitTestCoverage = 0, Status = Status.Available)]
        public static T FromValue<T>(int value)
            where T : Enumeration, new()
        {
            var matchingItem = Parse<T, int>(value, nameof(value), item => item.Value == value);

            return matchingItem;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        [Information(nameof(GetAll), UnitTestCoverage = 0, Status = Status.Available)]
        public static IEnumerable<T> GetAll<T>()
            where T : Enumeration, new()
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();

                if (info.GetValue(instance) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>System.Int32.</returns>
        [Information(nameof(CompareTo), UnitTestCoverage = 100, Status = Status.Available)]
        public int CompareTo(object other)
        {
            return this.Value.CompareTo(( (Enumeration)other ).Value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [Information(nameof(Equals), UnitTestCoverage = 99, Status = Status.Available)]
        public override bool Equals(object obj)
        {
            if (!( obj is Enumeration otherValue ))
            {
                return false;
            }

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this._value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        [Information(nameof(GetHashCode), UnitTestCoverage = 100, Status = Status.Available)]
        public override int GetHashCode()
        {
            return this.Value.GetHashCode() + this.DisplayName.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        [Information(nameof(ToString), UnitTestCoverage = 100, Status = Status.Available)]
        public override string ToString()
        {
            return this.DisplayName;
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="description">The description.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>T.</returns>
        /// <exception cref="ApplicationException"></exception>
        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate)
            where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = $"'{value}' is not a valid {description} in {typeof(T)}";

                throw new ApplicationException(message);
            }

            return matchingItem;
        }
    }
}
