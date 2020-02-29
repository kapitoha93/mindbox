using FigureAreaCalculator.Library.Figures;
using FluentAssertions;
using Xunit;

namespace FigureAreaCalculator.Tests.UnitTests
{
	/// <summary>
	/// Тесты для класса <see cref="Circle"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class CircleTests
	{
		[Theory]
		[InlineData(1, 3.14)]
		[InlineData(2, 12.57)]
		[InlineData(10, 314.16)]
		public void Get_area(
			double radius,
			double area)
		{
			var circle = new Circle
			{
				Radius = radius
			};
			var result = circle.GetArea(2);
			result.Should().Be(area);
		}
	}
}
