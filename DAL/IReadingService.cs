using PruebaNivel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNivel.DAL
{
    public interface IReadingService
    {
        List<Measure> GetMeasures();
    }
}
