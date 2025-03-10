﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Standard.Tester
// Author           : David McCarter
// Created          : 01-19-2019
//
// Last Modified By : David McCarter
// Last Modified On : 11-01-2020
// ***********************************************************************
// <copyright file="RandomData.cs" company="dotNetTips.Utility.Standard.Tester">
//     Copyright (c) dotNetTips.com - McCarter Consulting. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNetTips.Utility.Standard.Extensions;
using dotNetTips.Utility.Standard.OOP;
using dotNetTips.Utility.Standard.Tester.Collections;
using dotNetTips.Utility.Standard.Tester.Models;
using dotNetTips.Utility.Standard.Tester.Properties;

namespace dotNetTips.Utility.Standard.Tester
{
	/// <summary>
	/// Methods to randomly generate data for unit and benchmark testing.
	/// </summary>
	/// <remarks>Original code from: https://github.com/andrewseward/Any-.Net</remarks>
	public static class RandomData
	{

		/// <summary>
		/// The default maximum character for creating words.
		/// </summary>
		public const char DefaultMaxCharacter = 'z';

		/// <summary>
		/// The default maximum character random file name.
		/// </summary>
		public const char DefaultMaxCharacterRandomFile = 'Z';

		/// <summary>
		/// The default minimum character for creating words.
		/// </summary>
		public const char DefaultMinCharacter = 'A';

		/// <summary>
		/// The default minimum character random file name.
		/// </summary>
		public const char DefaultMinCharacterRandomFile = 'A';

		/// <summary>
		/// The domain extensions used to create random Url's.
		/// </summary>
		private static readonly string[] _domainExtensions = new string[] { ".com", ".co.uk", ".org", ".org.uk", ".net", ".us", ".com.au", ".es", ".fr", ".de", ".ly", ".gov", ".gov.uk", ".ac.uk", ".website", ".store", ".health", ".band" };

		/// <summary>
		/// The synchronize lock
		/// </summary>
		private static readonly object _lock = new object();

		/// <summary>
		/// The object used for retrieving a random number.
		/// </summary>
		private static readonly Random _random = new Random(Seed: (int)DateTime.Now.Ticks);

		/// <summary>
		/// Gets the long test string.
		/// </summary>
		/// <value>The long test string.</value>
		public static string LongTestString => Resources.LongTestString;

		/// <summary>
		/// Generates the byte array.
		/// </summary>
		/// <param name="sizeInKb">The size in kb.</param>
		/// <returns>System.Byte[].</returns>
		public static byte[] GenerateByteArray(double sizeInKb)
		{
			var size = Convert.ToInt32(sizeInKb * 1024);

			var bytes = new byte[size];
			_random.NextBytes(bytes);

			return bytes;
		}

		/// <summary>
		/// Creates a random character.
		/// </summary>
		/// <returns>System.Char.</returns>
		/// <example>82 'R'</example>
		public static char GenerateCharacter() => GenerateCharacter(DefaultMinCharacter, DefaultMaxCharacter);

		/// <summary>
		/// Creates a random character.
		/// </summary>
		/// <param name="minValue">The minimum character value.</param>
		/// <param name="maxValue">The maximum character value.</param>
		/// <returns>System.Char.</returns>
		/// <example>65 'A'</example>
		public static char GenerateCharacter(char minValue, char maxValue) => (char)GenerateInteger(minValue, maxValue);

		/// <summary>
		/// Creates a Coordinate with random values.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>T.</returns>
		/// <example>X: 178765551 Y: -2145952440</example>
		public static T GenerateCoordinate<T>() where T : ICoordinate, new()
		{
			var coordinate = new T
			{
				X = RandomData.GenerateInteger(int.MinValue, int.MaxValue),
				Y = RandomData.GenerateInteger(int.MinValue, int.MaxValue)
			};

			return coordinate;
		}

		/// <summary>
		/// Creates collection of coordinates.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="count">The collection count.</param>
		/// <returns>List&lt;T&gt;.</returns>
		/// <example>[0]: {2089369587--284215139} [1]: {244137335-1577361939}</example>
		public static IEnumerable<T> GenerateCoordinateCollection<T>(int count) where T : ICoordinate, new()
		{
			Encapsulation.TryValidateParam(count, 0, int.MaxValue, nameof(count));

			var coordinates = new List<T>(count);

			for (var personCount = 0; personCount < count; personCount++)
			{
				coordinates.Add(GenerateCoordinate<T>());
			}

			return coordinates;
		}

		/// <summary>
		/// Creates a random decimal value.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <param name="decimalPlaces">The decimal places.</param>
		/// <returns>System.Decimal.</returns>
		/// <example>95.15</example>
		public static decimal GenerateDecimal(decimal minValue, decimal maxValue, int decimalPlaces)
		{
			Encapsulation.TryValidateParam(decimalPlaces, 0, int.MaxValue, nameof(decimalPlaces));

			var multiplier = ( (decimal)decimalPlaces ) * 10;

			var result = GenerateInteger((int)( minValue * multiplier ), (int)( maxValue * multiplier )) / multiplier;

			return result;
		}

		/// <summary>
		/// Returns a random domain extension.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>".co.uk"</example>
		public static string GenerateDomainExtension() => Of(_domainExtensions);

		/// <summary>
		/// Creates a random email address.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>fbxpfvtanqysqmuqfh@kiuvf.fr</example>
		public static string GenerateEmailAddress()
		{
			return $"{GenerateWord(5, 25, 'a', 'z')}@{GenerateWord(5, 25, 'a', 'z')}{GenerateDomainExtension()}";
		}

		/// <summary>
		/// Generates the a test file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="fileLength">Length of the file. Minimum length=1</param>
		/// <returns>System.String.</returns>
		/// <example>c:\\temp\\UnitTest.test</example>
		public static string GenerateFile(string fileName, int fileLength = 1000)
		{
			Encapsulation.TryValidateParam(fileLength, 1, int.MaxValue, nameof(fileLength));

			var fakeText = GenerateWord(fileLength);

			File.WriteAllText(fileName, fakeText);

			return fileName;
		}

		/// <summary>
		/// Generates files.
		/// </summary>
		/// <param name="count">The file count.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>System.ValueTuple&lt;System.String, IEnumerable&lt;System.String&gt;&gt;.</returns>
		/// <example>Path: "C:\\Users\\dotNetDave\\AppData\\Local\\Temp\\" Files: Count = 100</example>
		public static (string Path, IEnumerable<string> Files) GenerateFiles(int count = 100, int fileLength = 1000)
		{
			Encapsulation.TryValidateParam(count, 1, int.MaxValue, nameof(count));
			Encapsulation.TryValidateParam(fileLength, 1, int.MaxValue, nameof(fileLength));

			var files = new List<string>(count);

			for (var fileCount = 0; fileCount < count; fileCount++)
			{
				files.Add(GenerateTempFile(fileLength));
			}


			return (Path.GetTempPath(), files.AsEnumerable());
		}

		/// <summary>
		/// Generates random files.
		/// </summary>
		/// <param name="count">The count.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <param name="fileExtension">The file extension.</param>
		/// <returns>System.ValueTuple&lt;System.String, IEnumerable&lt;System.String&gt;&gt;.</returns>
		/// <example>Path: "C:\\Users\\dotNetDave\\AppData\\Local\\Temp\\" Files: Count = 100</example>
		public static (string Path, IEnumerable<string> Files) GenerateFiles(int count = 100, int fileLength = 1000, string fileExtension = "temp")
		{
			Encapsulation.TryValidateParam(count, 1, int.MaxValue, nameof(count));
			Encapsulation.TryValidateParam(fileLength, 1, int.MaxValue, nameof(fileLength));
			Encapsulation.TryValidateParam(fileExtension, nameof(fileExtension));

			var files = new List<string>(count);

			for (var fileCount = 0; fileCount < count; fileCount++)
			{
				var fileName = GenerateRandomFileName(25, fileExtension);
				files.Add(GenerateFile(fileName, fileLength));
			}


			return (Path.GetTempPath(), files.AsEnumerable());
		}

		/// <summary>
		/// Generates random files.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="count">The count.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>IEnumerable&lt;System.String&gt;.</returns>
		/// <example>[0]: "c:\\temp\\dobybcyx.lj"  [1]: "c:\\temp\\zo2ggwub.3ro"</example>
		public static IEnumerable<string> GenerateFiles(string path, int count = 100, int fileLength = 1000)
		{
			Encapsulation.TryValidateParam(path, nameof(path));
			Encapsulation.TryValidateParam(count, 1, int.MaxValue, nameof(count));
			Encapsulation.TryValidateParam(fileLength, 1, int.MaxValue, nameof(fileLength));

			var files = new List<string>(count);

			Directory.CreateDirectory(path);

			for (var fileCount = 0; fileCount < count; fileCount++)
			{
				var fileName = GenerateRandomFileName(path);
				files.Add(GenerateFile(fileName, fileLength));
			}

			return files.AsEnumerable();
		}

		/// <summary>
		/// Creates a random integer value.
		/// </summary>
		/// <param name="min">The minimum int.</param>
		/// <param name="max">The maximum int.</param>
		/// <returns>System.Int32.</returns>
		public static int GenerateInteger(int min = int.MinValue, int max = int.MaxValue)
		{
			lock (_lock)
			{
				return _random.Next(min, max);
			}
		}

		/// <summary>
		/// Creates a random key.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>f7f0af78003d4ab194b5a4024d02112a</example>
		public static string GenerateKey()
		{
			return Guid.NewGuid().ToDigits();
		}

		/// <summary>
		/// Creates a random number string.
		/// </summary>
		/// <param name="length">The length.</param>
		/// <returns>System.String.</returns>
		/// <example>"446085072052112"</example>
		public static string GenerateNumber(int length)
		{
			Encapsulation.TryValidateParam(value: length, minimumValue: 1, maximumValue: int.MaxValue, paramName: nameof(length));

			var sb = new StringBuilder(length);

			for (var count = 0; count < length; count++)
			{
				sb.Append(_random.Next(0, 9));
			}

			return sb.ToString();
		}

		/// <summary>
		/// Creates a IPerson type with random values.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="addressLength">Length of the address.</param>
		/// <param name="cityLength">Length of the city.</param>
		/// <param name="countryLength">Length of the country.</param>
		/// <param name="firstNameLength">First length of the name.</param>
		/// <param name="lastNameLength">Last length of the name.</param>
		/// <param name="postalCodeLength">Length of the postal code.</param>
		/// <returns>T.</returns>
		public static T GeneratePerson<T>(int addressLength = 25, int cityLength = 15, int countryLength = 15, int firstNameLength = 15, int lastNameLength = 25, int postalCodeLength = 8) where T : IPerson, new()
		{
			var person = new T
			{
				Id = RandomData.GenerateKey(),
				Address1 = RandomData.GenerateWord(addressLength),
				Address2 = RandomData.GenerateWord(addressLength),
				BornOn = DateTimeOffset.Now.Subtract(new TimeSpan(365 * GenerateInteger(1, 75), 0, 0, 0)),
				CellPhone = GeneratePhoneNumberUSA(),
				City = RandomData.GenerateWord(cityLength),
				Country = RandomData.GenerateWord(countryLength),
				Email = RandomData.GenerateEmailAddress(),
				FirstName = RandomData.GenerateWord(firstNameLength),
				HomePhone = GeneratePhoneNumberUSA(),
				LastName = RandomData.GenerateWord(lastNameLength),
				PostalCode = RandomData.GenerateNumber(postalCodeLength)
			};

			return person;
		}

		/// <summary>
		/// Creates an IPerson collection.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="count">The collection count.</param>
		/// <returns>List&lt;PersonFixed&gt;.</returns>
		/// <example>[0]: "eemdqrbmgtypqxgjijsjmp@fpdgwbswvg.fr" [1]: "roxmoiksscmrixp@wdfgjorfxydcw.de"</example>
		public static PersonCollection<T> GeneratePersonCollection<T>(int count) where T : IPerson, new()
		{
			Encapsulation.TryValidateParam(count, 1, int.MaxValue, nameof(count));

			var people = new PersonCollection<T>(count);

			_ = Parallel.For(0, count, index =>
			  {
				  people.Add(RandomData.GeneratePerson<T>());
			  });

			return people;
		}

		/// <summary>
		/// Creates a US phone number.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>284-424-2216</example>
		public static string GeneratePhoneNumberUSA()
		{
			return $"{RandomData.GenerateNumber(3)}-{RandomData.GenerateNumber(3)}-{RandomData.GenerateNumber(4)}";
		}

		/// <summary>
		/// Generates a random file name with path (users temp folder).
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>C:\\Users\\dotNetDave\\AppData\\Local\\Temp\\3nvoblq5.lz1</example>
		public static string GenerateRandomFileName()
		{
			return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
		}

		/// <summary>
		/// Generates a random file name.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>System.String.</returns>
		/// <example>c:\\temp\\0yiv4iiu.uuv</example>
		public static string GenerateRandomFileName(string path)
		{
			Encapsulation.TryValidateParam(path, nameof(path));

			return Path.Combine(path, Path.GetRandomFileName());
		}

		/// <summary>
		/// Generates random file name.
		/// </summary>
		/// <param name="fileNameLength">Length of the file name.</param>
		/// <param name="extension">The extension.</param>
		/// <returns>System.String.</returns>
		/// <example>C:\\Users\\dotNetDave\\AppData\\Local\\Temp\\FOGWYNDRBM.dotnettips</example>
		public static string GenerateRandomFileName(int fileNameLength = 10, string extension = "tester.temp")
		{
			Encapsulation.TryValidateParam(fileNameLength, 1, 256, nameof(fileNameLength));
			Encapsulation.TryValidateParam(extension, nameof(extension));

			var fileName = GenerateWord(fileNameLength, DefaultMinCharacterRandomFile, DefaultMaxCharacterRandomFile) + "." + extension;
			var fullName = Path.Combine(Path.GetTempPath(), fileName);

			return fullName;
		}

		/// <summary>
		/// Generates a random file name.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="fileNameLength">Length of the file name.</param>
		/// <param name="extension">The extension.</param>
		/// <returns>System.String.</returns>
		/// <example>c:\\temp\\FFDHRBMDXP.dotnettips</example>
		public static string GenerateRandomFileName(string path, int fileNameLength = 10, string extension = "tester.temp")
		{
			Encapsulation.TryValidateParam(path, nameof(path));
			Encapsulation.TryValidateParam(fileNameLength, 1, 256, nameof(fileNameLength));
			Encapsulation.TryValidateParam(extension, nameof(extension));

			var fileName = GenerateWord(fileNameLength, DefaultMinCharacterRandomFile, DefaultMaxCharacterRandomFile) + "." + extension;
			var fullName = Path.Combine(path, fileName);

			return fullName;
		}

		/// <summary>
		/// Creates a random relative url.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>"/ljsylu/rsglcurkiylqld/wejdbuainlgjofnv/uwbrjftyt/"</example>
		public static string GenerateRelativeUrl()
		{
			var url = new StringBuilder();

			for (var i = 0; i < GenerateInteger(1, 10); i++)
			{
				url.Append(GenerateUrlPart());
			}

			url.Append('/');

			return url.ToString();
		}

		/// <summary>
		/// Generates a random file.
		/// </summary>
		/// <param name="fileLength">The length.</param>
		/// <returns>System.String.</returns>
		/// <example>C:\\Users\\dotNetDave\\AppData\\Local\\Temp\\klxpckpo.24h</example>
		public static string GenerateTempFile(int fileLength = 1000)
		{
			Encapsulation.TryValidateParam(fileLength, 1, int.MaxValue, nameof(fileLength));

			var fileName = GenerateRandomFileName();
			var fakeText = GenerateWord(fileLength);

			File.WriteAllText(fileName, fakeText);

			return fileName;
		}

		/// <summary>
		/// Creates a random Url.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>https://www.agngbgluhawxhnmoxvdogla.hdtmdjmiagwlx.com/r/ulhekwhqnicq/bxxmyq/owaqaqxvdvtae/</example>
		public static string GenerateUrl()
		{
			return $"{GenerateUrlHostName()}{GenerateRelativeUrl()}";
		}

		/// <summary>
		/// Creates a random url host name.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>https://www.ehvjnbhcpcivgiccugim.lfa.net</example>
		public static string GenerateUrlHostName()
		{
			return $"https://{GenerateUrlHostnameNoProtocol()}";
		}

		/// <summary>
		/// Creates a url without a protocol.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>www.wucqcapnybi.kejdwudpbstekhxic.co.uk</example>
		public static string GenerateUrlHostnameNoProtocol()
		{
			return $"www.{GenerateWord(1, 25, 'a', 'z')}.{GenerateUrlHostnameNoSubdomain()}";
		}

		/// <summary>
		/// Creates host name without a subdomain.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <example>elqqcw.org.uk</example>
		public static string GenerateUrlHostnameNoSubdomain()
		{
			return $"{GenerateWord(3, 25, 'a', 'z')}{GenerateDomainExtension()}";
		}

		/// <summary>
		/// Create a random url part.
		/// </summary>
		/// <returns>System.String.</returns>
		/// <remarks>/rregyyjxpjiats</remarks>
		public static string GenerateUrlPart()
		{
			return $"/{GenerateWord(1, 25, 'a', 'z')}";
		}

		/// <summary>
		/// Creates a random word.
		/// </summary>
		/// <param name="length">The length.</param>
		/// <returns>System.String.</returns>
		/// <example>mL_g[E_E_CsoJvjshI]CFjFKa</example>
		public static string GenerateWord(int length)
		{
			Encapsulation.TryValidateParam(length, minimumValue: 1, paramName: nameof(length));

			var returnValue = GenerateWord(length, DefaultMinCharacter, DefaultMaxCharacter);

			return returnValue;
		}

		/// <summary>
		/// Creates a random word.
		/// </summary>
		/// <param name="minLength">The minimum length.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <returns>System.String.</returns>
		/// <example>oMOYxlFvqclVQK</example>
		public static string GenerateWord(int minLength, int maxLength)
		{
			Encapsulation.TryValidateParam(minLength, minimumValue: 1, paramName: nameof(minLength));
			Encapsulation.TryValidateParam(maxLength, minimumValue: 1, paramName: nameof(maxLength));
			Encapsulation.TryValidateParam<ArgumentOutOfRangeException>(maxLength >= minLength, message: Resources.MinimumLenghthCannotBeGreaterThanMaximumLe);

			return GenerateWord(minLength, maxLength, DefaultMinCharacter, DefaultMaxCharacter);
		}

		/// <summary>
		/// Creates a random word.
		/// </summary>
		/// <param name="length">The length.</param>
		/// <param name="minCharacter">The minimum character.</param>
		/// <param name="maxCharacter">The maximum character.</param>
		/// <returns>System.String.</returns>
		/// <example>LBEEUMHHHK</example>
		public static string GenerateWord(int length, char minCharacter, char maxCharacter)
		{
			Encapsulation.TryValidateParam(length, 1, int.MaxValue, nameof(length));

			var word = new StringBuilder(length);

			for (var wordCount = 0; wordCount < length; wordCount++)
			{
				_ = word.Append(GenerateCharacter(minCharacter, maxCharacter));
			}

			return word.ToString();
		}

		/// <summary>
		/// Creates a random word.
		/// </summary>
		/// <param name="minLength">The minimum length.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <param name="minCharacter">The minimum character.</param>
		/// <param name="maxCharacter">The maximum character.</param>
		/// <returns>System.String.</returns>
		/// <example>ACRNFTPAE</example>
		public static string GenerateWord(int minLength, int maxLength, char minCharacter, char maxCharacter) => GenerateWord(GenerateInteger(minLength, maxLength), minCharacter, maxCharacter);

		/// <summary>
		/// Generates a list of words.
		/// </summary>
		/// <param name="count">The word count.</param>
		/// <param name="minLength">The minimum length.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <returns>ImmutableList&lt;System.String&gt;.</returns>
		public static ImmutableList<string> GenerateWords(int count, int minLength, int maxLength)
		{
			Encapsulation.TryValidateParam(count, minimumValue: 1, paramName: nameof(count));

			var strings = new List<string>();

			for (var wordCount = 0; wordCount < count; wordCount++)
			{
				strings.Add(GenerateWord(minLength, maxLength));
			}

			return strings.ToImmutableList();
		}

		/// <summary>
		/// Picks a random string from an array.
		/// </summary>
		/// <param name="words">The words.</param>
		/// <returns>System.String.</returns>
		private static string Of(params string[] words) => words[GenerateInteger(0, words.Length - 1)];

	}
}
