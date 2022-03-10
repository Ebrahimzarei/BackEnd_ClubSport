using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSport.Domain.Enums
{
	public enum Provider : int
	{
		SqlServer = 0,
		MySql = 1,
		PostgreSQL = 2,
		Oracle = 3,
		InMemory = 4,
	}
}
