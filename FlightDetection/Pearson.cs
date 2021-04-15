//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System;

namespace FlightDetection
{
	public class Line
	{
		float a, b;
		public Line()
		{
			this.a = 0;
			this.b = 0;
		}
		public Line(float a, float b)
		{
			this.a = a;
			this.b = b;
		}
		public float f(float x)
		{
			return a * x + b;
		}
	}

	public class Point
	{
		float x, y;
		public Point(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		public float getX()
		{
			return x;
		}
		public float getY()
		{
			return y;
		}

	}
	public class Pearson
	{
		public static int bestCore(List<List<float>> myList, int index)
		{
			float max = 0;
			float currentCore;
			int best = 0;
			int row = myList[0].Count;
			int col = myList.Count;
			for (int i = 0; i < col; i++)
			{
				currentCore = Math.Abs(pearson(myList[index], myList[i], row));
				if (currentCore > max && i != index)
				{
					max = currentCore;
					best = i;
				}
			}
			return best;
		}
		public static float avg(List<float> x, int size)
		{
			float sum = 0;
			for (int i = 0; i < size; sum += x[i], i++) ;
			return sum / size;
		}

		// returns the variance of X and Y
		public static float var(List<float> x, int size)
		{
			float av = avg(x, size);
			float sum = 0;
			for (int i = 0; i < size; i++)
			{
				sum += x[i] * x[i];
			}
			return sum / size - av * av;
		}

		// returns the covariance of X and Y
		public static float cov(List<float> x, List<float> y, int size)
		{
			float sum = 0;
			for (int i = 0; i < size; i++)
			{
				sum += x[i] * y[i];
			}
			sum /= size;

			return sum - avg(x, size) * avg(y, size);
		}


		// returns the Pearson correlation coefficient of X and Y
		public static float pearson(List<float> x, List<float> y, int size)
		{
			float a = var(x, size);

			return ((float)(cov(x, y, size) / (Math.Sqrt(var(x, size)) * Math.Sqrt(var(y, size)))));
		}

		// performs a linear regression and returns the line equation
		public static Line linear_reg(Point[] points, int size)
		{
			List<float> x = new List<float>();
			List<float> y = new List<float>();
			for (int i = 0; i < size; i++)
			{
				x.Add(points[i].getX());
				y.Add(points[i].getY());
			}
			float a = cov(x, y, size) / var(x, size);
			float b = avg(y, size) - a * (avg(x, size));

			return new Line(a, b);
		}

		// returns the deviation between point p and the line equation of the points
		public static float dev(Point p, Point[] points, int size)
		{
			Line l = linear_reg(points, size);
			return dev(p, l);
		}

		// returns the deviation between point p and the line
		public static float dev(Point p, Line l)
		{
			return Math.Abs(p.getY() - l.f(p.getX()));
		}
	}
}