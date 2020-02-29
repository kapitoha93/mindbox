using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FigureAreaCalculator.Library.Interfaces;

namespace FigureAreaCalculator.Library.Figures
{
	/// <summary>
	/// Фигура треугольник.
	/// </summary>
	public class Triangle : IFigure, IValidatableObject
	{
		/// <summary>
		/// Первая сторона.
		/// </summary>
		public double Side1 { get; set; }

		/// <summary>
		/// Вторая сторона.
		/// </summary>
		public double Side2 { get; set; }

		/// <summary>
		/// Третья сторона.
		/// </summary>
		public double Side3 { get; set; }

		/// <inheritdoc />
		// Ссылка на вики https://ru.wikipedia.org/wiki/%D0%A2%D1%80%D0%B5%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA#%D0%9F%D0%BB%D0%BE%D1%89%D0%B0%D0%B4%D1%8C_%D1%82%D1%80%D0%B5%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA%D0%B0.
		// Вычисляем площадь по формуле Герона.
		public double GetArea(int accuracy)
		{
			var perimeter = Side1 + Side2 + Side3;
			var p = perimeter / 2;

			var result = Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
			return Math.Round(result, accuracy, MidpointRounding.AwayFromZero);
		}

		/// <summary>
		/// Проверяет, является ли треугольник прямоугольным.
		/// </summary>
		public bool IsRight()
		{
			return
				Math.Round(Math.Pow(Side1, 2), 2, MidpointRounding.AwayFromZero) ==
					Math.Round(Math.Pow(Side2, 2), 2, MidpointRounding.AwayFromZero) +
					Math.Round(Math.Pow(Side3, 2), 2, MidpointRounding.AwayFromZero) ||
				Math.Round(Math.Pow(Side2, 2), 2, MidpointRounding.AwayFromZero) ==
					Math.Round(Math.Pow(Side1, 2), 2, MidpointRounding.AwayFromZero) +
					Math.Round(Math.Pow(Side3, 2), 2, MidpointRounding.AwayFromZero) ||
				Math.Round(Math.Pow(Side3, 2), 2, MidpointRounding.AwayFromZero) ==
					Math.Round(Math.Pow(Side1, 2), 2, MidpointRounding.AwayFromZero) +
					Math.Round(Math.Pow(Side2, 2), 2, MidpointRounding.AwayFromZero);
		}

		/// <inheritdoc />
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();

			var wrongSideLengthMessage = "Длина стороны должна быть больше 0.";
			var wrongSidesLengthSum = "Сумма длин любых двух сторон треугольника должна быть больше длины третьей стороны.";

			if (Side1 <= 0)
			{
				results.Add(new ValidationResult(wrongSideLengthMessage, new[] { nameof(Side1) }));
			}

			if (Side2 <= 0)
			{
				results.Add(new ValidationResult(wrongSideLengthMessage, new[] { nameof(Side2) }));
			}

			if (Side3 <= 0)
			{
				results.Add(new ValidationResult(wrongSideLengthMessage, new[] { nameof(Side3) }));
			}

			if (Side1 >= Side2 + Side3)
			{
				results.Add(new ValidationResult(wrongSidesLengthSum, new[] { nameof(Side2), nameof(Side3) }));
			}

			if (Side2 >= Side1 + Side3)
			{
				results.Add(new ValidationResult(wrongSidesLengthSum, new[] { nameof(Side1), nameof(Side3) }));
			}

			if (Side3 >= Side1 + Side2)
			{
				results.Add(new ValidationResult(wrongSidesLengthSum, new[] { nameof(Side1), nameof(Side2) }));
			}

			return results;
		}
	}
}
