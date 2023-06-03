using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiciMax.Domain.MovementReports
{
	public class MovementReport
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public DateTime Day { get; set; }
		public DateTime? EntryTime { get; set; }
		public DateTime? ExitTime { get; set; }
		public string? DurationStr { get; set; }
		public TimeSpan? Duration { get; set; }
    }
}
