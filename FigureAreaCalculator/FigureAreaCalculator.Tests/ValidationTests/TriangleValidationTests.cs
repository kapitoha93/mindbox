using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FigureAreaCalculator.Library.Figures;
using Xunit;

namespace FigureAreaCalculator.Tests.ValidationTests
{
	/// <summary>
	/// Тесты валидации для класса <see cref="Triangle"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class TriangleValidationTests : ValidationTests<Triangle>
	{
		[Theory]
		[MemberData(nameof(ValidationCases))]
		public void CheckValidate(ValidationTestCase<Triangle> testCase)
		{
			Validate(testCase);
		}

		public static IEnumerable<object[]> ValidationCases()
		{
			yield return new object[]
			{
				new ValidationTestCase<Triangle>
				{
					Name = "Валидная модель",
					Model = new Triangle
					{
						Side1 = 3,
						Side2 = 4,
						Side3 = 5
					},
					ExpectedValidationResults = new List<ValidationResult>()
				}
			};

			yield return new object[]
			{
				new ValidationTestCase<Triangle>
				{
					Name = "Длина стороны равна 0",
					Model = new Triangle
					{
						Side1 = 0,
						Side2 = 4,
						Side3 = 5
					},
					ExpectedValidationResults = new List<ValidationResult>
					{
						new ValidationResult("Длина стороны должна быть больше 0."),
						new ValidationResult("Сумма длин любых двух сторон треугольника должна быть больше длины третьей стороны.")
					}
				}
			};

			yield return new object[]
			{
				new ValidationTestCase<Triangle>
				{
					Name = "Длина стороны меньше 0",
					Model = new Triangle
					{
						Side1 = -1,
						Side2 = 4,
						Side3 = 5
					},
					ExpectedValidationResults = new List<ValidationResult>
					{
						new ValidationResult("Длина стороны должна быть больше 0."),
						new ValidationResult("Сумма длин любых двух сторон треугольника должна быть больше длины третьей стороны."),
						new ValidationResult("Сумма длин любых двух сторон треугольника должна быть больше длины третьей стороны.")
					}
				}
			};
		}
	}
}
