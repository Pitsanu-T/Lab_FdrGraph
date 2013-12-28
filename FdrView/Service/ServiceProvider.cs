using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using FakeRepository;

namespace Service
{
    public static class ServiceProvider
    {
        private static IFdrRepository _fdrRepository;
        public static IFdrRepository GetFdrRepository()
        {
            if (_fdrRepository == null)
            {
                _fdrRepository = new FakeFdrRepository();
            }

            return _fdrRepository;
        }
    }
}
