using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE450_Sleep_Tracker.Models
{
    public interface IDbConvertable<netType, dbType>
    {
        dbType ToDbObject(netType obj);
        netType ToNetObject(dbType obj);
    }
}
