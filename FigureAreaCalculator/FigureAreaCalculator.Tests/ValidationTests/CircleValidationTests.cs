using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FigureAreaCalculator.Library.Figures;
using Xunit;

namespace FigureAreaCalculator.Tests.ValidationTests
{
	/// <summary>
	/// Тесты валидации для класса <see cref="Circle"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class CircleValidationTests : ValidationTests<Circle>
	{
		[Theory]
		[MemberData(nameof(ValidationCases))]
		public void CheckValidate(ValidationTestCase<Circle> testCase)
		{
			Validate(testCase);
		}

		public static IEnumerable<object[]> ValidationCases()
		{
			yield return new object[]
			{
				new ValidationTestCase<Circle>
				{
					Name = "Валидная модель",
					Model = new Circle
					{
						Radius = 1
					},
					ExpectedValidationResults = new List<ValidationResult>()
				}
			};

			yield return new object[]
			{
				new ValidationTestCase<Circle>
				{
					Name = "Радиус равен 0",
					Model = new Circle
					{
						Radius = 0
					},
					ExpectedValidationResults = new List<ValidationResult>
					{
						new ValidationResult("Радиус круга должен быть больше 0.")
					}
				}
			};

			yield return new object[]
			{
				new ValidationTestCase<Circle>
				{
					Name = "Радиус меньше 0",
					Model = new Circle
					{
						Radius = -1
					},
					ExpectedValidationResults = new List<ValidationResult>
					{
						new ValidationResult("Радиус круга должен быть больше 0.")
					}
				}
			};
		}
	}
}
