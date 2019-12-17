using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	class Vertex
	{
		public int x;
		public int y;
		public int name;

		public Vertext(int xCoor, int yCoor, int vertName)
		{
			x = xCoor;
			y = yCoor;
			name = vertName;

		}

		public int calcDistance(Vertex vertex)
		{
			return (int)Math.Sqrt((vertex.x - this.x) * (vertex.x - this.x) + (vertex.y - this.y) * (vertex.y - this.y));
		}
	}
}
