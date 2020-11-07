using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class DetallesLogs
    {
        public string IdLogs { get; set; }
        public DateTime AuditDatetimeUtc { get; set; }
        public string AuditType { get; set; }
        public string AuditUsername { get; set; }
        public string TableName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string ChangedColumns { get; set; }
    }
}
