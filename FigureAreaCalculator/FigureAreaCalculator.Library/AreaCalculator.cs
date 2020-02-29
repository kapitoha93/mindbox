using FigureAreaCalculator.Library.Interfaces;

namespace FigureAreaCalculator.Library
{
	public class AreaCalculator
	{
		/// <summary>
		/// Возвращает площадь для любой фигуры.
		/// </summary>
		/// <param name="figure"><see cref="IFigure"/>.</param>
		/// <param name="accuracy">Точность вычисления площади (количество знаков после запятой).</param>
		public static double GetArea(
			IFigure figure,
			int accuracy = 2)
		{
			return figure.GetArea(accuracy);
		}
	}
}
