using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityToolbox.iTask.Domain.Entities;

namespace UtilityToolbox.iTask.Domain.Interface
{
    public interface IMileStoneRepository
    {
        IEnumerable<MileStone> MileStones { get; set; }
    }
}
