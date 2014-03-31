using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEndLayer
{
    public interface Mergeable
    {
        //merges the only the edited info of a Mergeable
        void mergeInfo(Mergeable m);

    }
}
