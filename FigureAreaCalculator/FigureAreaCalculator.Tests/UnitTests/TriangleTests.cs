using FigureAreaCalculator.Library.Figures;
using FluentAssertions;
using Xunit;

namespace FigureAreaCalculator.Tests.UnitTests
{
	/// <summary>
	/// Тесты для класса <see cref="Triangle"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class TriangleTests
	{
		[Theory]
		[InlineData(3, 4, 5, 6)]
		[InlineData(2, 4, 5, 3.8)]
		[InlineData(8, 11, 14, 43.91)]
		public void Get_area(
			double side1,
			double side2,
			double side3,
			double area)
		{
			var triangle = new Triangle
			{
				Side1 = side1,
				Side2 = side2,
				Side3 = side3
			};
			var result = triangle.GetArea(2);
			result.Should().Be(area);
		}

		[Theory]
		[InlineData(3, 4, 5, true)]
		[InlineData(2, 4, 5, false)]
		[InlineData(8, 11, 14, false)]
		public void Is_right(
			double side1,
			double side2,
			double side3,
			bool isRight)
		{
			var triangle = new Triangle
			{
				Side1 = side1,
				Side2 = side2,
				Side3 = side3
			};
			var result = triangle.IsRight();
			result.Should().Be(isRight);
		}
	}
}
