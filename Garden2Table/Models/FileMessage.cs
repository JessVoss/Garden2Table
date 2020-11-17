using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden2Table.Models
{
    public enum FileMessage
    {
        None,
        Complete,
        FileAccessError,
        RecordNotFound,
        NoRecordsFound
    }
}
