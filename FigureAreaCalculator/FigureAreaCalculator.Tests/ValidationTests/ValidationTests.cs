using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FigureAreaCalculator.Tests.ValidationTests
{
	public abstract class ValidationTests<T>
	{
		protected void Validate(ValidationTestCase<T> testCase)
		{
			var context = new ValidationContext(testCase.Model);
			var errors = new List<ValidationResult>();
			Validator.TryValidateObject(testCase.Model, context, errors);

			Assert.Equal(testCase.ExpectedValidationResults.Count, errors.Count);
			if (errors.Count > 0)
			{
				for (var i = 0; i < errors.Count; i++)
				{
					Assert.Equal(testCase.ExpectedValidationResults[i].ErrorMessage, errors[i].ErrorMessage);
				}
			}
		}
	}
}
