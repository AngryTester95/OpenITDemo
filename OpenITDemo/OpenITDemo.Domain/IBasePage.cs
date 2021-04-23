using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenITDemo.Domain
{
    public interface IBasePage
    {
        IBasePage WaitForPageLoad();
    }
}
