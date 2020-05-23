using EgtDemp.IRepo;
using EgtDemp.IServ;
using EgtDemp.Model;
using System;
using System.Collections.Generic;

namespace EgtDemp.Serv
{
    public class DemoServ : IDemoServ
    {
        private readonly IDemoRepo _demoRepo;

        public DemoServ(IDemoRepo demoRepo)
        {
            this._demoRepo = demoRepo;
        }

        public List<Demo> GetDemos()
        {
            return _demoRepo.GetDemos();
        }
    }
}
