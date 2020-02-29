using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FigureAreaCalculator.Tests
{
	/// <summary>
	/// Модель для тестирования валидации.
	/// </summary>
	/// <typeparam name="T">Класс для тестирования валидации.</typeparam>
	public class ValidationTestCase<T> : TestCase<T>
	{
		public List<ValidationResult> ExpectedValidationResults { get; set; }
	}

	/// <summary>
	/// Модель для тестирования.
	/// </summary>
	/// <typeparam name="T">Класс для тестирования.</typeparam>
	public class TestCase<T>
	{
		public T Model { get; set; }

		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
