using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FigureAreaCalculator.Library.Interfaces;

namespace FigureAreaCalculator.Library.Figures
{
	/// <summary>
	/// Фигура круг.
	/// </summary>
	public class Circle : IFigure, IValidatableObject
	{
		/// <summary>
		/// Радиус круга.
		/// </summary>
		public double Radius { get; set; }

		/// <inheritdoc />
		// Ссылка на вики https://ru.wikipedia.org/wiki/%D0%9F%D0%BB%D0%BE%D1%89%D0%B0%D0%B4%D1%8C_%D0%BA%D1%80%D1%83%D0%B3%D0%B0.
		public double GetArea(int accuracy)
		{
			var result = Math.PI * Math.Pow(Radius, 2);
			return Math.Round(result, accuracy, MidpointRounding.AwayFromZero);
		}

		/// <inheritdoc />
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();

			if (Radius <= 0)
			{
				results.Add(new ValidationResult("Радиус круга должен быть больше 0.", new[] { nameof(Radius) }));
			}

			return results;
		}
	}
}
