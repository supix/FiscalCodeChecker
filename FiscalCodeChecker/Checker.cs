using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FiscalCodeChecker
{
	public static class Checker
	{
		/// <summary>
		///		Checks formal validity of Italian fiscal code
		/// </summary>
		/// <param name="fiscalCode">The fiscal code to be checked</param>
		/// <returns>true if the fiscal code is formally valid</returns>
		public static bool IsFormallyValid(string fiscalCode)
		{
			const string regex = @"[\dLMNP-V]{2}(?:[A-EHLMPR-T](?:[04LQ][1-9MNP-V]|[1256LMRS][\dLMNP-V])|[DHPS][37PT][0L]|[ACELMRT][37PT][01LM])(?:[A-MZ][1-9MNP-V][\dLMNP-V]{2}|[A-M][0L][\dLMNP-V][1-9MNP-V])";
			if (!Regex.IsMatch(fiscalCode, regex))
				return false;

			#region static maps

			var oddMap = new Dictionary<char, int>() {
				{'0', 1},
				{'1', 0},
				{'2', 5},
				{'3', 7},
				{'4', 9},
				{'5', 13},
				{'6', 15},
				{'7', 17},
				{'8', 19},
				{'9', 21},
				{'A', 1},
				{'B', 0},
				{'C', 5},
				{'D', 7},
				{'E', 9},
				{'F', 13},
				{'G', 15},
				{'H', 17},
				{'I', 19},
				{'J', 21},
				{'K', 2},
				{'L', 4},
				{'M', 18},
				{'N', 20},
				{'O', 11},
				{'P', 3},
				{'Q', 6},
				{'R', 8},
				{'S', 12},
				{'T', 14},
				{'U', 16},
				{'V', 10},
				{'W', 22},
				{'X', 25},
				{'Y', 24},
				{'Z', 23}
			};

			var evenMap = new Dictionary<char, int>() {
				{'0', 0},
				{'1', 1},
				{'2', 2},
				{'3', 3},
				{'4', 4},
				{'5', 5},
				{'6', 6},
				{'7', 7},
				{'8', 8},
				{'9', 9},
				{'A', 0},
				{'B', 1},
				{'C', 2},
				{'D', 3},
				{'E', 4},
				{'F', 5},
				{'G', 6},
				{'H', 7},
				{'I', 8},
				{'J', 9},
				{'K', 10},
				{'L', 11},
				{'M', 12},
				{'N', 13},
				{'O', 14},
				{'P', 15},
				{'Q', 16},
				{'R', 17},
				{'S', 18},
				{'T', 19},
				{'U', 20},
				{'V', 21},
				{'W', 22},
				{'X', 23},
				{'Y', 24},
				{'Z', 25}
			};

			#endregion static maps

			int total = 0;
			try
			{
				for (int i = 0; i < 15; i += 2)
					total += oddMap[fiscalCode[i]];
				for (int i = 1; i < 15; i += 2)
					total += evenMap[fiscalCode[i]];
			}
			catch
			{
				return false;
			}

			return fiscalCode[15] == (char)('A' + total % 26);
		}
	}
}
