namespace FigureAreaCalculator.Library.Interfaces
{
	/// <summary>
	/// Интерфейс фигуры.
	/// </summary>
	public interface IFigure
	{
		/// <summary>
		/// Возвращает площадь фигуры.
		/// </summary>
		/// <param name="accuracy">Точность вычисления площади (количество знаков после запятой).</param>
		double GetArea(int accuracy = 2);
	}
}
