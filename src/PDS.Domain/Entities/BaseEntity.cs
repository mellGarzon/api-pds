using System;
using PDS.Domain.Interfaces;

namespace PDS.Domain.Entities
{
	public abstract class BaseEntity: IBaseInterface
	{
		public long Id { get; set; }
    }
}

