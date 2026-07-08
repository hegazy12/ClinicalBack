using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{
    public interface classinter
    {
        public Task<List<Test>>GetAllTests();
    }
}
